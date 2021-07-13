# aide.ConsoleAssist

Helper library for console input and output. It includes some regular functions to display text with color on the console, generate menus from enums etc.


## Example 

Template based color output, where the [red],[green] are console colors. The text between the tags get displayed with the relevant color.

```Output.WriteLineUsingTemplate("Template [red]based[/red] color output. [green]This is sample text[/green].");```

![image](https://user-images.githubusercontent.com/22835808/125418293-47d8f106-fa20-4d41-bb86-b06480943527.png)


### Menu
Menu is built up based on the enum definition.

```
        private enum TransportType
        {
            Bus = 1,
            Train,
            Airplane,
            Ship
        }

        Menu.EnumMenu<TransportType>("Transport Mode", true);
```
![image](https://user-images.githubusercontent.com/22835808/125442721-f0a87aff-8751-48a1-8616-9001471fb395.png)

General menu

```     
        Menu foodMenu = new Menu("Food Menu", true);
        foodMenu.Add("Burger", () => { Output.WriteLineSuccess($"Selected item is Burger"); });
        foodMenu.Add("Pizza", () => { Output.WriteLineSuccess($"Selected item is Pizza"); });
        foodMenu.Add("Sandwich", () => { Output.WriteLineSuccess($"Selected item is Sandwich"); });
        foodMenu.Display();
```
![image](https://user-images.githubusercontent.com/22835808/125442806-c349f20f-66d2-4315-be19-3f76c298c27c.png)




