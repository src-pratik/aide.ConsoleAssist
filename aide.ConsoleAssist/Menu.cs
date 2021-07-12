using System;
using System.Collections.Generic;
using System.Linq;

namespace aide.ConsoleAssist
{
    /// <summary>
    /// Helper to display menu and take input from user based upon the menu.
    /// </summary>
    public class Menu
    {
        private IList<Option> _options { get; set; }

        /// <summary>
        /// Name of the menu.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// To display the menu name as header in wrapped line.
        /// </summary>
        public bool Header { get; private set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the menu.</param>
        /// <param name="header">To display the menu name as header in wrapped line.</param>
        public Menu(string name, bool header = false)
        {
            Name = name;
            Header = header;
            _options = new List<Option>();
        }

        /// <summary>
        /// Add option to menu list.
        /// </summary>
        /// <param name="name">Name of the option.</param>
        /// <param name="action">Action assigned to be invoked on selection of the option.</param>
        public void Add(string name, Action action)
        {
            _options.Add(new Option(name, action));
        }

        /// <summary>
        /// Add option to menu list.
        /// </summary>
        /// <param name="option">Option object.</param>
        public void Add(Option option)
        {
            _options.Add(option);
        }

        /// <summary>
        /// Display the menu.
        /// </summary>
        public void Display()
        {
            if (Header)
                Output.WriteLineWithWrap(Name);

            for (int i = 0; i < _options.Count; i++)
                Output.WriteLine($"{i + 1}. {_options[i].Name}");

            int choice = Input.ReadInteger("Choose an option: ", 1, _options.Count);

            _options[choice - 1].Action();
        }

        /// <summary>
        /// Check if the option with given name exist.
        /// </summary>
        /// <param name="name">Name of the option to be searched.</param>
        /// <returns>True or False whether the option exists.</returns>
        public bool Contains(string name)
        {
            return _options.Where(x => x.Name.Equals(name)).Any();
        }
        /// <summary>
        /// String representation of the object.
        /// </summary>
        /// <returns>Name of the menu.</returns>
        public override string ToString()
        {
            return Name;
        }
        /// <summary>
        /// Displays an menu from an Enum.
        /// </summary>
        /// <typeparam name="TEnum">Enum type</typeparam>
        /// <param name="name">Name of the menu.</param>
        /// <param name="header">To display the menu name as header in wrapped line.</param>
        /// <returns>Selected enum value based upon selected option.</returns>
        public static TEnum EnumMenu<TEnum>(string name, bool header = false) where TEnum : struct
        {
            Type type = typeof(TEnum);

            if (!type.IsEnum)
                throw new ArgumentException("TEnum must be an enumerated type");

            Menu menu = new Menu(name, header);

            TEnum choice = default;
            foreach (var value in Enum.GetValues(type))
                menu.Add(Enum.GetName(type, value), () => { choice = (TEnum)value; });
            menu.Display();

            return choice;
        }
    }
}