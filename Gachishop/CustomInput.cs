﻿using System.Text.RegularExpressions;

namespace Gachishop;

class CustomInput
{
    public static string ReadText()
    { 
        string enteredValue = "";

        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key != ConsoleKey.Backspace 
                && key.Key != ConsoleKey.Enter)
            {
                enteredValue += key.KeyChar;
                Console.Write(key.KeyChar);
                continue;
            }

            if (key.Key == ConsoleKey.Backspace 
                && enteredValue.Length != 0)
            {
                enteredValue = enteredValue.Substring(0, (enteredValue.Length - 1));
                Console.Write("\b \b");
                continue;
            }

            if (key.Key == ConsoleKey.Enter 
                && !string.IsNullOrWhiteSpace(enteredValue))
            {
                Console.WriteLine("");
                return enteredValue;
            }
        }
    }

    public static string ReadPassword()
    {
        string enteredValue = "";

        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key != ConsoleKey.Backspace 
                && key.Key != ConsoleKey.Enter)
            {
                enteredValue += key.KeyChar;
                Console.Write("*");
                continue;
            }

            if (key.Key == ConsoleKey.Backspace 
                && enteredValue.Length != 0)
            {
                enteredValue = enteredValue.Substring(0, (enteredValue.Length - 1));
                Console.Write("\b \b");
                continue;
            }

            if (key.Key == ConsoleKey.Enter 
                && !string.IsNullOrWhiteSpace(enteredValue))
            {
                Console.WriteLine("");
                return enteredValue;
            }
        }
    }

    public static int ReadNumber()
    {
        string enteredValue = "";
        string regexp = @"D[0-9]";
        
        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            
            if (Regex.IsMatch(key.Key.ToString(), regexp))
            {
                enteredValue += key.KeyChar;
                Console.Write(key.KeyChar);
            }
            if (key.Key == ConsoleKey.Backspace 
                && enteredValue.Length != 0)
            {
                enteredValue = enteredValue.Substring(0, (enteredValue.Length - 1));
                Console.Write("\b \b");
                continue;
            }
            if (key.Key == ConsoleKey.Enter 
                && !string.IsNullOrWhiteSpace(enteredValue))
            {
                Console.WriteLine("");
                return int.Parse(enteredValue);
            }
        }
    }

    public static string ReadCardNumber()
    {
        string enteredValue = "";
        string regexp = @"D[0-9]";
        
        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            
            if (Regex.IsMatch(key.Key.ToString(), regexp) 
                && enteredValue.Length < 16)
            {
                enteredValue += key.KeyChar;
                Console.Write(key.KeyChar);
            }
            if (key.Key == ConsoleKey.Backspace 
                && enteredValue.Length != 0)
            {
                enteredValue = enteredValue.Substring(0, (enteredValue.Length - 1));
                Console.Write("\b \b");
                continue;
            }
            if (key.Key == ConsoleKey.Enter 
                && enteredValue.Length == 16)
            {
                Console.WriteLine("");
                return enteredValue;
            }
        }
    }

    public static int ReadSecurityCode()
    {
        string enteredValue = "";
        string regexp = @"D[0-9]";
        
        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            
            if (Regex.IsMatch(key.Key.ToString(), regexp) 
                && enteredValue.Length < 3)
            {
                enteredValue += key.KeyChar;
                Console.Write(key.KeyChar);
            }
            if (key.Key == ConsoleKey.Backspace 
                && enteredValue.Length != 0)
            {
                enteredValue = enteredValue.Substring(0, (enteredValue.Length - 1));
                Console.Write("\b \b");
                continue;
            }
            if (key.Key == ConsoleKey.Enter 
                && enteredValue.Length == 3)
            {
                Console.WriteLine("");
                return int.Parse(enteredValue);
            }
        }
    }

    public static string ReadPhoneNumber()
    {
        string enteredValue = "";
        string regexp = @"D[0-9]";
        
        Console.Write("+380");
        
        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            
            if (Regex.IsMatch(key.Key.ToString(), regexp) 
                && enteredValue.Length < 9)
            {
                enteredValue += key.KeyChar;
                Console.Write(key.KeyChar);
            }
            if (key.Key == ConsoleKey.Backspace 
                && enteredValue.Length != 0)
            {
                enteredValue = enteredValue.Substring(0, (enteredValue.Length - 1));
                Console.Write("\b \b");
                continue;
            }
            if (key.Key == ConsoleKey.Enter 
                && enteredValue.Length == 9)
            {
                Console.WriteLine("");
                return "+380" + enteredValue;
            }
        }
    }

    public static string ReadYesOrNo()
    {
        string enteredValue = "";

        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key != ConsoleKey.Backspace 
                && key.Key != ConsoleKey.Enter)
            {
                enteredValue += key.KeyChar;
                Console.Write(key.KeyChar);
                continue;
            }

            if (key.Key == ConsoleKey.Backspace 
                && enteredValue.Length != 0)
            {
                enteredValue = enteredValue.Substring(0, (enteredValue.Length - 1));
                Console.Write("\b \b");
                continue;
            }

            if (key.Key == ConsoleKey.Enter 
                && ( (enteredValue == "yes") || (enteredValue == "no") ) )
            {
                Console.WriteLine("");
                return enteredValue;
            }
        }
    }

    public static string ReadValidity()
    {
        string enteredValue = "";
        string regex = @"^(0[1-9]|1[0-2])\/?([0-9]{2})$";
        
        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key != ConsoleKey.Backspace 
                && key.Key != ConsoleKey.Enter)
            {
                enteredValue += key.KeyChar;
                Console.Write(key.KeyChar);
                continue;
            }

            if (key.Key == ConsoleKey.Backspace 
                && enteredValue.Length != 0)
            {
                enteredValue = enteredValue.Substring(0, (enteredValue.Length - 1));
                Console.Write("\b \b");
                continue;
            }

            if (key.Key == ConsoleKey.Enter 
                && Regex.IsMatch(enteredValue, regex) )
            {
                Console.WriteLine("");
                return enteredValue;
            }
        }
    }
}