using System;

namespace aide.ConsoleAssist.Sample
{
    internal class Program
    {
        private enum TransportType
        {
            Bus = 1,
            Train,
            Airplane,
            Ship
        }

        private static void Main(string[] args)
        {
            Output.WriteLineSuccess("Samples for Console Assist.");
            Output.WriteLineUsingTemplate("Template [red]based[/red] color output. [green]This is sample text[/green].");

            var userInput = Input.ReadInteger("Enter your favourite number ");

            Output.WriteInformation($"User Input : {userInput}");

            Console.WriteLine();

            Menu foodMenu = new Menu("Food Menu", true);

            foodMenu.Add("Burger", () => { Output.WriteLineSuccess($"Selected item is Burger"); });
            foodMenu.Add("Pizza", () => { Output.WriteLineSuccess($"Selected item is Pizza"); });
            foodMenu.Add("Sandwich", () => { Output.WriteLineSuccess($"Selected item is Sandwich"); });

            foodMenu.Display();

            var transportInput = Menu.EnumMenu<TransportType>("Transport Mode", true);

            Output.WriteLineInformation($"User Input : {transportInput}");

            var ynAns = Input.PromptYesOrNo("Do you like the console helping methods ?", true);

            Output.WriteLineInformation($"User Response : {ynAns}");
        }
    }
}