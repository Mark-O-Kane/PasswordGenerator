﻿using System;
using System.Threading;
using System.Windows.Forms;

namespace PasswordGenerator
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            DisplayInformation();
            
            bool keepGenerating = true;
            while (keepGenerating)
            {
                Console.WriteLine("****Warming the genny up****\n");
                Console.Write("Enter Word to be included at end of password: ");
                string specialWord = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(specialWord))
                {
                    Console.WriteLine("Nothing entered.\n");
                    string password = GenerateRandomPassword("");
                    Console.WriteLine("--------------------------------------------------------");
                    Console.WriteLine($"|               Password: {password}                 |");
                    Console.WriteLine("--------------------------------------------------------\n");
                    Clipboard.SetText(password);
                }
                else
                {
                    if (specialWord.ToUpper() == "QUIT")
                        Quit();
                    else
                    {
                        Console.WriteLine();
                        string password = GenerateRandomPassword(specialWord);
                        Console.WriteLine("--------------------------------------------------------");
                        Console.WriteLine($"|               Password: {password}                 |");
                        Console.WriteLine("--------------------------------------------------------\n");
                        Clipboard.SetText(password);
                    }
                }
            }
        }

        private static void Quit()
        {
            Console.WriteLine();
            Console.WriteLine("****Cooling the genny down****");
            Thread.Sleep(1500);
            Environment.Exit(-1);
        }

        private static void DisplayInformation()
        {
            Console.WriteLine("\t\t\t|****************************Password Generator***************************|\n\t\t\t|                                                                         |");
            Console.WriteLine("\t\t\t|****************Password will be 12 characters in length*****************|\n\t\t\t|                                                                         |");
            Console.WriteLine("\t\t\t|**************************Word is not required***************************|\n\t\t\t|                                                                         |");
            Console.Write("\t\t\t|***************************type \"quit\" to exit***************************|\t\t\t");
            Console.WriteLine("\t\t¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯\n\n");
        }

        private static string GenerateRandomPassword(string v)
        {
            char[] characters = new char[] { 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M',
                                             'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm',
                                             '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '!', '@', ':', '#', ';', '<', '>', '?', '*', '&', '$', '(', ')', '/', '\\', '.' };
            int passwordLength = 12;
            int randomChar;
            Random random = new Random();

            if (String.IsNullOrWhiteSpace(v))
            {
                char[] buffer = new char[passwordLength];
                for (int i = 0; i < passwordLength; i++)
                {
                    randomChar = random.Next(0, characters.Length);
                    buffer[i] = (char)characters[randomChar];
                }
                v = new string(buffer);
            }
            else
            {
                string concat = v;
                int subtract = v.Length;
                char[] buffer = new char[passwordLength - subtract];
                for (int i = 0; i < passwordLength - subtract; i++)
                {
                    randomChar = random.Next(0, characters.Length);
                    buffer[i] = (char)characters[randomChar];
                }
                v = new string(buffer);
                v += concat;
            }
            return v;
        }
    }
}