using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Pdb;

namespace Conceptual
{
    public class CodeNameLister
    {
        private readonly string _assemblyFilePath;

        public CodeNameLister(string assemblyFilePath)
        {
            _assemblyFilePath = assemblyFilePath;
        }

        public string[] List()
        {
            List<string> names = new List<string>();
            AddTypeNames(LoadModule(_assemblyFilePath), names);
            return names.ToArray();
        }

        private AssemblyDefinition LoadModule(string fileName)
        {
            return AssemblyDefinition.ReadAssembly( fileName, 
                                                    new ReaderParameters
                                                    {
                                                        ReadSymbols = true, 
                                                        SymbolReaderProvider = new PdbReaderProvider()
                                                    }); // need .pdb symbols file to name variables
        }

        private void AddTypeNames(AssemblyDefinition module, List<string> names)
        {
            foreach (TypeDefinition type in module.Modules.First().Types)
            {
                if (type.Name != "<Module>") // compiler-generated type name
                {
                    names.Add(type.Name);
                    AddMemberNames(names, type);
                }
            }
        }

        private void AddMemberNames(List<string> names, TypeDefinition type)
        {
            AddMethodNames(names, type);
            AddFieldNames(names, type);
        }

        private void AddFieldNames(List<string> names, TypeDefinition type)
        {
            foreach (FieldDefinition field in type.Fields)
            {
                names.Add(field.Name);
            }
        }

        private void AddMethodNames(List<string> names, TypeDefinition type)
        {
            List<string> properties = new List<string>();

            foreach (MethodDefinition method in type.Methods)
            {
                var name = method.Name;

                if (IsProperty(name))
                {
                    name = CropPropertyName(name);

                    // de-dupe property get/set pairs
                    if (properties.Contains(name))
                    {
                        break;
                    }
                    properties.Add(name);
                }

                names.Add(name);

                AddParameterNames(names, method);
                AddVariableNames(names, method);
            }
        }

        private void AddVariableNames(List<string> names, MethodDefinition method)
        {
            if (method.HasBody)
            {
                names.AddRange(method.Body.Variables.Select(variable => variable.Name));
            }
        }

        private string CropPropertyName(string name)
        {
            return name.Substring(4, name.Length - 4);
        }

        private void AddParameterNames(List<string> names, MethodDefinition method)
        {
            names.AddRange(method.Parameters.Select(parameter => parameter.Name));
        }

        private bool IsProperty(string name)
        {
            return name.StartsWith("get_") || name.StartsWith("set_");
        }
    }
}