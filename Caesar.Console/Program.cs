namespace Caesar.Console;

using System;
using Caesar.Cipher.lib;
public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Error: No parameters were passed.");
            return;
        }
        string? command = null;
        int? key = null;
        string? text = null;
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "-command" && i + 1 < args.Length)
            {
                command = args[i + 1];
                i++;
            }
            else if (args[i] == "-key" && i + 1 < args.Length)
            {
                if (int.TryParse(args[i + 1], out int parsedKey))
                {
                    key = parsedKey;
                    i++;
                }
                else
                {
                    Console.WriteLine("Error: Key must be a valid integer.");
                    return;
                }
            }
            else if (args[i] == "-text" && i + 1 < args.Length)
            {
                text = args[i + 1];
                i++;
            }
        }
        if (command == null || key == null || text == null)
        {
            Console.WriteLine("Error: Use the correct syntax: Caesar.exe -command crypt or decrypt -key 3 -text \"test\"");
            return;
        }
        if (command == "crypt")
        {
            Console.WriteLine(Cipher.Crypt((int)key, text));
        }
        else if (command == "decrypt")
        {
            Console.WriteLine(Cipher.DeCrypt((int)key, text));
        }
        else
        {
            Console.WriteLine($"-command {command} not found!");
        }

    }
}
