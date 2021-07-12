using System;

namespace aide.ConsoleAssist
{
    /// <summary>
    /// Display option.
    /// </summary>
    public class Option
    {
        /// <summary>
        /// Name of the option.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Action assigned to be invoked on selection of the option.
        /// </summary>
        public Action Action { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name of the option.</param>
        /// <param name="action">Action assigned to be invoked on selection of the option.</param>
        public Option(string name, Action action)
        {
            Name = name;
            Action = action;
        }
        /// <summary>
        /// String representation of the object.
        /// </summary>
        /// <returns>Name of the option</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}