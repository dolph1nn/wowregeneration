﻿using System;
using System.IO;
using System.Reflection;

namespace WoWRegeneration
{
    internal class Program
    {
        public static string ExecutionPath { get; set; }

        /// <summary>
        ///     Program start point
        ///     Allows command-line arguments - for example "WoWRegeneration.exe enUS Win"
        /// </summary>
        private static void Main(string[] args)
        {
            string inLocale = null, inOs = null;
            if (args.Length == 1) inLocale = args[0]; else if (args.Length == 2) inOs = args[1];
            InitConsole();

            WoWRegeneration.Process(inLocale, inOs);

            WaitUntilEnd();
        }

        /// <summary>
        ///     Print an empty line on console
        /// </summary>
        public static void Log()
        {
            Log("", ConsoleColor.White);
        }

        /// <summary>
        ///     Print a value on console, with default color (white)
        /// </summary>
        /// <param name="value">value to print on console</param>
        public static void Log(string value)
        {
            Log(value, ConsoleColor.White);
        }

        /// <summary>
        ///     Print a value on console, with specified color
        /// </summary>
        /// <param name="value">value to print on console</param>
        /// <param name="color">forecolor to use</param>
        public static void Log(string value, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        /// <summary>
        ///     Initialize console
        /// </summary>
        private static void InitConsole()
        {
            Console.Clear();
            Version version = Assembly.GetEntryAssembly().GetName().Version;
            Console.Title = "WoW Regeneration - " + version;
            ExecutionPath = Environment.CurrentDirectory;
            if (ExecutionPath != null && !ExecutionPath.EndsWith(Path.DirectorySeparatorChar.ToString()))
                ExecutionPath = ExecutionPath + Path.DirectorySeparatorChar;
        }

        /// <summary>
        ///     Fonction to avoid console close
        /// </summary>
        private static void WaitUntilEnd()
        {
            Log("Press enter to exit program.");
            Console.ReadLine();
        }
    }
}