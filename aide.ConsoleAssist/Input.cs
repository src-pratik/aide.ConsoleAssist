using System;

namespace aide.ConsoleAssist
{
    /// <summary>
    /// Helper to take console input.
    /// </summary>
    public static class Input
    {
        /// <summary>
        /// Displays a message for which a yes or no response is expected.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        /// <param name="defaultAnswer">Default answer.</param>
        /// <returns>Selected answer</returns>
        public static bool PromptYesOrNo(string message, bool defaultAnswer)
        {
            Output.Write(message, ConsoleColor.Yellow);
            Output.Write(defaultAnswer ? " (y*/n)" : " (y/n*)", ConsoleColor.Green);
            while (true)
            {
                var response = Console.ReadKey(true);

                switch (response.Key)
                {
                    case ConsoleKey.Y:
                        Output.WriteLine(" - Yes");
                        return true;

                    case ConsoleKey.N:
                        Output.WriteLine(" - No");
                        return false;

                    case ConsoleKey.Enter:
                        Output.WriteLine($" - {(defaultAnswer ? "Yes" : "No")}");
                        return defaultAnswer;
                }
            }
        }
        /// <summary>
        /// Reads an integer value as input.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        /// <param name="min">Minimum value of integer expected.</param>
        /// <param name="max">Maximum value of integer expected.</param>
        /// <returns>Value provided as input.</returns>
        public static int ReadInteger(string message, int min, int max)
        {
            int value = ReadInteger(message);

            while (value < min || value > max)
            {
                Output.WriteLineError($"Please enter an integer between {min} and {max} (inclusive).");
                value = ReadInteger(message);
            }

            return value;
        }
        /// <summary>
        /// Reads an integer value as input.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        /// <returns>Value provided as input.</returns>
        public static int ReadInteger(string message)
        {
            Output.Write(message);
            string input = Console.ReadLine();
            int value;

            while (!int.TryParse(input, out value))
            {
                Output.WriteLineWarning("Please enter an valid integer value.");
                Output.Write(message);
                input = Console.ReadLine();
            }

            return value;
        }
    }
}