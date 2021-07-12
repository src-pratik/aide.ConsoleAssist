using System;
using System.Text.RegularExpressions;

namespace aide.ConsoleAssist
{
    /// <summary>
    /// Helper to display console output.
    /// </summary>
    public static partial class Output
    {
        #region "Private"

        private static readonly ConsoleColor _initialForeColor = System.Console.ForegroundColor;

        private static Lazy<Regex> _templateColorTagRegex = new Lazy<Regex>(() => new Regex("\\[(?<color>.*?)\\](?<text>[^[]*)\\[/\\k<color>\\]", RegexOptions.IgnoreCase),
                                                                isThreadSafe: true);

        #endregion "Private"

        #region "Color Config"

        /// <summary>
        /// Color set for Sucess. Default Green.
        /// </summary>
        public static ConsoleColor Success { get; set; } = ConsoleColor.Green;
        /// <summary>
        /// Color set for Error. Default Red.
        /// </summary>
        public static ConsoleColor Error { get; set; } = ConsoleColor.Red;
        /// <summary>
        /// Color set for Warning. Default Dark Yellow.
        /// </summary>
        public static ConsoleColor Warning { get; set; } = ConsoleColor.DarkYellow;
        /// <summary>
        /// Color set for Information. Default Dark Cyan.
        /// </summary>
        public static ConsoleColor Information { get; set; } = ConsoleColor.DarkCyan;

        #endregion "Color Config"

        #region "General Config"
        /// <summary>
        /// Minimum number of characters used in the wrap line. 
        /// Default 10 characters.
        /// </summary>
        public static int MinimumWrapCharacters { get; set; } = 10;
        /// <summary>
        /// Enable or Disable color output. Default True.
        /// </summary>
        public static bool EnableColor { get; set; } = true;

        #endregion "General Config"

        /// <summary>
        /// Write text line on the console.
        /// </summary>
        /// <param name="text">Text to be displayed.</param>
        /// <param name="color">Foreground color in which the text will be displayed.</param>
        public static void WriteLine(this string text, ConsoleColor? color = null)
        {
            if (!color.HasValue)
            {
                Console.WriteLine(text);
                return;
            }

            var oldColor = System.Console.ForegroundColor;

            if (color == oldColor)
            {
                Console.WriteLine(text);
                return;
            }

            Console.ForegroundColor = color.Value;
            Console.WriteLine(text);
            Console.ForegroundColor = oldColor;
        }

        /// <summary>
        ///  Write text on the console.
        /// </summary>
        /// <param name="text">Text to be displayed.</param>
        /// <param name="color">Foreground color in which the text will be displayed.</param>
        public static void Write(this string text, ConsoleColor? color = null)
        {
            if (!color.HasValue)
            {
                Console.Write(text);
                return;
            }

            var oldColor = System.Console.ForegroundColor;

            if (color == oldColor)
            {
                Console.Write(text);
                return;
            }

            Console.ForegroundColor = color.Value;
            Console.Write(text);
            Console.ForegroundColor = oldColor;
        }

        /// <summary>
        /// Write text on the console.
        /// </summary>
        /// <param name="text">Text to be displayed.</param>
        /// <param name="color">Foreground color in which the text will be displayed. The color name should be a valid ConsoleColor.</param>
        public static void Write(string text, string color)
        {
            if (string.IsNullOrEmpty(color))
            {
                Write(text);
                return;
            }
            if (!Enum.TryParse(color, true, out ConsoleColor textColor))
                Write(text);
            else
                Write(text, textColor);
        }
        /// <summary>
        /// Write text line on the console.
        /// </summary>
        /// <param name="text">Text to be displayed.</param>
        /// <param name="color">Foreground color in which the text will be displayed. The color name should be a valid ConsoleColor..</param>
        public static void WriteLine(string text, string color)
        {
            if (string.IsNullOrEmpty(color))
            {
                WriteLine(text);
                return;
            }
            if (!Enum.TryParse(color, true, out ConsoleColor textColor))
                WriteLine(text);
            else
                Write(text, textColor);
        }
        /// <summary>
        /// Write text line on the console and wrap the line with characters
        /// ====================
        /// Demo Text
        /// ====================
        /// </summary>
        /// <param name="text">Text to be displayed.</param>
        /// <param name="wrapChar">Character used in the wrap line.</param>
        /// <param name="textColor">Foreground color in which the text will be displayed.</param>
        /// <param name="wrapColor">Foreground color in which the wrap line will be displayed.</param>
        public static void WriteLineWithWrap(this string text, char wrapChar = '=',
            ConsoleColor textColor = ConsoleColor.Yellow, ConsoleColor wrapColor = ConsoleColor.Gray)
        {
            if (string.IsNullOrEmpty(text))
                return;

            string wrapLine = new string(wrapChar, text.Length > MinimumWrapCharacters ? text.Length : MinimumWrapCharacters);

            WriteLine(wrapLine, wrapColor);
            WriteLine(text, textColor);
            WriteLine(wrapLine, wrapColor);
        }
        /// <summary>
        /// Writes line of text using template. 
        /// The template tag allows to set color to substring of text which is in between of the tags. 
        /// e.g. Hello [green]World[/green] !!! Welcome to [red]Console Assist[/red].
        /// The word "World" will be displayed in green color, similarly "Console Assist" in red.
        /// The rest of the text will be displayed with the param value of defaultTextColor (default is the existing foreground color).
        /// </summary>
        /// <param name="text">Text to be displayed with template placehodlers.</param>
        /// <param name="defaultTextColor">Default foreground color for text.</param>
        public static void WriteLineUsingTemplate(this string text, ConsoleColor? defaultTextColor = null)
        {
            if (defaultTextColor == null)
                defaultTextColor = Console.ForegroundColor;

            if (string.IsNullOrEmpty(text))
            {
                WriteLine(text);
                return;
            }

            while (true)
            {
                var match = _templateColorTagRegex.Value.Match(text);

                if (match.Length < 1)
                {
                    WriteLine(text, defaultTextColor);
                    break;
                }

                Write(text.Substring(0, match.Index), defaultTextColor);

                string highlightText = match.Groups["text"].Value;
                string colorVal = match.Groups["color"].Value;

                Write(highlightText, colorVal);

                text = text.Substring(match.Index + match.Value.Length);
            }
        }
        /// <summary>
        /// Writes text using template. 
        /// The template tag allows to set color to substring of text which is in between of the tags. 
        /// e.g. Hello [green]World[/green] !!! Welcome to [red]Console Assist[/red].
        /// The word "World" will be displayed in green color, similarly "Console Assist" in red.
        /// The rest of the text will be displayed with the param value of defaultTextColor (default is the existing foreground color).
        /// </summary>
        /// <param name="text">Text to be displayed with template placehodlers.</param>
        /// <param name="defaultTextColor">Default foreground color for text.</param>
        public static void WriteUsingTemplate(this string text, ConsoleColor? defaultTextColor = null)
        {
            if (defaultTextColor == null)
                defaultTextColor = Console.ForegroundColor;

            if (string.IsNullOrEmpty(text))
            {
                WriteLine(text);
                return;
            }

            while (true)
            {
                var match = _templateColorTagRegex.Value.Match(text);

                if (match.Length < 1)
                {
                    Write(text, defaultTextColor);
                    break;
                }

                Write(text.Substring(0, match.Index), defaultTextColor);

                string highlightText = match.Groups["text"].Value;
                string colorVal = match.Groups["color"].Value;

                Write(highlightText, colorVal);

                text = text.Substring(match.Index + match.Value.Length);
            }
        }

        /// <summary>
        /// Resets the console foreground color to the default color.
        /// </summary>
        public static void ResetColor()
        {
            Console.ForegroundColor = _initialForeColor;
        }
    }

    public static partial class Output
    {
        #region "Wrappers"

        /// <summary>
        /// Write line with foreground color Success.
        /// </summary>
        /// <param name="text">Text to be displayed.</param>
        public static void WriteLineSuccess(this string text)
        {
            WriteLine(text, Success);
        }

        /// <summary>
        /// Write line with foreground color Error.
        /// </summary>
        /// <param name="text">Text to be displayed.</param>
        public static void WriteLineError(this string text)
        {
            WriteLine(text, Error);
        }

        /// <summary>
        /// Write line with foreground color Warning.
        /// </summary>
        /// <param name="text">Text to be displayed.</param>
        public static void WriteLineWarning(this string text)
        {
            WriteLine(text, Warning);
        }

        /// <summary>
        /// Write line with foreground color Information.
        /// </summary>
        /// <param name="text">Text to be displayed.</param>
        public static void WriteLineInformation(this string text)
        {
            WriteLine(text, Information);
        }

        /// <summary>
        /// Write line with foreground color Sucess.
        /// </summary>
        /// <param name="text">Text to be displayed.</param>
        public static void WriteSuccess(this string text)
        {
            Write(text, Success);
        }

        /// <summary>
        /// Write line with foreground color Error.
        /// </summary>
        /// <param name="text">Text to be displayed.</param>
        public static void WriteError(this string text)
        {
            Write(text, Error);
        }

        /// <summary>
        /// Write line with foreground color Warning.
        /// </summary>
        /// <param name="text">Text to be displayed.</param>
        public static void WriteWarning(this string text)
        {
            Write(text, Warning);
        }

        /// <summary>
        /// Write line with foreground color Information.
        /// </summary>
        /// <param name="text">Text to be displayed.</param>
        public static void WriteInformation(this string text)
        {
            Write(text, Information);
        }

        #endregion "Wrappers"
    }
}