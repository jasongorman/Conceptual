## Conceptual - A Tool For Checking Whose Language Our Code's Speaking - Ours or our customer's

This is a proof of concept for calculating the Conceptual Correlation (overlap) between words used in identifiers in .NET code and requirements stored in a plain text file

To use at the command line, run the Conceptual.exe console application, providing the name of the DLL to analyse and the name of the .txt file that contains the requirements raw text.

e.g.

> Conceptual "myproject.dll" "requirements.txt"

It will need a corresponding .pdb for the assembly in the same folder to read the names in the original source code.
