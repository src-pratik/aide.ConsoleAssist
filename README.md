## aide.ConsoleAssist ##

Helper library for console input and output.

# T:aide.ConsoleAssist.Input

 Helper to take console input. 



---
##### M:aide.ConsoleAssist.Input.PromptYesOrNo(System.String,System.Boolean)

 Displays a message for which a yes or no response is expected. 

|Name | Description |
|-----|------|
|message: |Message to be displayed.|
|Name | Description |
|-----|------|
|defaultAnswer: |Default answer.|
Returns: Selected answer



---
##### M:aide.ConsoleAssist.Input.ReadInteger(System.String,System.Int32,System.Int32)

 Reads an integer value as input. 

|Name | Description |
|-----|------|
|message: |Message to be displayed.|
|Name | Description |
|-----|------|
|min: |Minimum value of integer expected.|
|Name | Description |
|-----|------|
|max: |Maximum value of integer expected.|
Returns: Value provided as input.



---
##### M:aide.ConsoleAssist.Input.ReadInteger(System.String)

 Reads an integer value as input. 

|Name | Description |
|-----|------|
|message: |Message to be displayed.|
Returns: Value provided as input.



---
# T:aide.ConsoleAssist.Menu

 Helper to display menu and take input from user based upon the menu. 



---
##### P:aide.ConsoleAssist.Menu.Name

 Name of the menu. 



---
##### P:aide.ConsoleAssist.Menu.Header

 To display the menu name as header in wrapped line. 



---
##### M:aide.ConsoleAssist.Menu.#ctor(System.String,System.Boolean)

 Constructor 

|Name | Description |
|-----|------|
|name: |Name of the menu.|
|Name | Description |
|-----|------|
|header: |To display the menu name as header in wrapped line.|


---
##### M:aide.ConsoleAssist.Menu.Add(System.String,System.Action)

 Add option to menu list. 

|Name | Description |
|-----|------|
|name: |Name of the option.|
|Name | Description |
|-----|------|
|action: |Action assigned to be invoked on selection of the option.|


---
##### M:aide.ConsoleAssist.Menu.Add(aide.ConsoleAssist.Option)

 Add option to menu list. 

|Name | Description |
|-----|------|
|option: |Option object.|


---
##### M:aide.ConsoleAssist.Menu.Display

 Display the menu. 



---
##### M:aide.ConsoleAssist.Menu.Contains(System.String)

 Check if the option with given name exist. 

|Name | Description |
|-----|------|
|name: |Name of the option to be searched.|
Returns: True or False whether the option exists.



---
##### M:aide.ConsoleAssist.Menu.ToString

 String representation of the object. 

Returns: Name of the menu.



---
##### M:aide.ConsoleAssist.Menu.EnumMenu``1(System.String,System.Boolean)

 Displays an menu from an Enum. 

|Name | Description |
|-----|------|
|TEnum: |Enum type|
|Name | Description |
|-----|------|
|name: |Name of the menu.|
|Name | Description |
|-----|------|
|header: |To display the menu name as header in wrapped line.|
Returns: Selected enum value based upon selected option.



---
# T:aide.ConsoleAssist.Option

 Display option. 



---
##### P:aide.ConsoleAssist.Option.Name

 Name of the option. 



---
##### P:aide.ConsoleAssist.Option.Action

 Action assigned to be invoked on selection of the option. 



---
##### M:aide.ConsoleAssist.Option.#ctor(System.String,System.Action)

 Constructor. 

|Name | Description |
|-----|------|
|name: |Name of the option.|
|Name | Description |
|-----|------|
|action: |Action assigned to be invoked on selection of the option.|


---
##### M:aide.ConsoleAssist.Option.ToString

 String representation of the object. 

Returns: Name of the option



---
# T:aide.ConsoleAssist.Output

 Helper to display console output. 



---
##### P:aide.ConsoleAssist.Output.Success

 Color set for Sucess. Default Green. 



---
##### P:aide.ConsoleAssist.Output.Error

 Color set for Error. Default Red. 



---
##### P:aide.ConsoleAssist.Output.Warning

 Color set for Warning. Default Dark Yellow. 



---
##### P:aide.ConsoleAssist.Output.Information

 Color set for Information. Default Dark Cyan. 



---
##### P:aide.ConsoleAssist.Output.MinimumWrapCharacters

 Minimum number of characters used in the wrap line. Default 10 characters. 



---
##### P:aide.ConsoleAssist.Output.EnableColor

 Enable or Disable color output. Default True. 



---
##### M:aide.ConsoleAssist.Output.WriteLine(System.String,System.Nullable{System.ConsoleColor})

 Write text line on the console. 

|Name | Description |
|-----|------|
|text: |Text to be displayed.|
|Name | Description |
|-----|------|
|color: |Foreground color in which the text will be displayed.|


---
##### M:aide.ConsoleAssist.Output.Write(System.String,System.Nullable{System.ConsoleColor})

 Write text on the console. 

|Name | Description |
|-----|------|
|text: |Text to be displayed.|
|Name | Description |
|-----|------|
|color: |Foreground color in which the text will be displayed.|


---
##### M:aide.ConsoleAssist.Output.Write(System.String,System.String)

 Write text on the console. 

|Name | Description |
|-----|------|
|text: |Text to be displayed.|
|Name | Description |
|-----|------|
|color: |Foreground color in which the text will be displayed. The color name should be a valid ConsoleColor.|


---
##### M:aide.ConsoleAssist.Output.WriteLine(System.String,System.String)

 Write text line on the console. 

|Name | Description |
|-----|------|
|text: |Text to be displayed.|
|Name | Description |
|-----|------|
|color: |Foreground color in which the text will be displayed. The color name should be a valid ConsoleColor..|


---
##### M:aide.ConsoleAssist.Output.WriteLineWithWrap(System.String,System.Char,System.ConsoleColor,System.ConsoleColor)

 Write text line on the console and wrap the line with characters ==================== Demo Text ==================== 

|Name | Description |
|-----|------|
|text: |Text to be displayed.|
|Name | Description |
|-----|------|
|wrapChar: |Character used in the wrap line.|
|Name | Description |
|-----|------|
|textColor: |Foreground color in which the text will be displayed.|
|Name | Description |
|-----|------|
|wrapColor: |Foreground color in which the wrap line will be displayed.|


---
##### M:aide.ConsoleAssist.Output.WriteLineUsingTemplate(System.String,System.Nullable{System.ConsoleColor})

 Writes line of text using template. The template tag allows to set color to substring of text which is in between of the tags. e.g. Hello [green]World[/green] !!! Welcome to [red]Console Assist[/red]. The word "World" will be displayed in green color, similarly "Console Assist" in red. The rest of the text will be displayed with the param value of defaultTextColor (default is the existing foreground color). 

|Name | Description |
|-----|------|
|text: |Text to be displayed with template placehodlers.|
|Name | Description |
|-----|------|
|defaultTextColor: |Default foreground color for text.|


---
##### M:aide.ConsoleAssist.Output.WriteUsingTemplate(System.String,System.Nullable{System.ConsoleColor})

 Writes text using template. The template tag allows to set color to substring of text which is in between of the tags. e.g. Hello [green]World[/green] !!! Welcome to [red]Console Assist[/red]. The word "World" will be displayed in green color, similarly "Console Assist" in red. The rest of the text will be displayed with the param value of defaultTextColor (default is the existing foreground color). 

|Name | Description |
|-----|------|
|text: |Text to be displayed with template placehodlers.|
|Name | Description |
|-----|------|
|defaultTextColor: |Default foreground color for text.|


---
##### M:aide.ConsoleAssist.Output.ResetColor

 Resets the console foreground color to the default color. 



---
##### M:aide.ConsoleAssist.Output.WriteLineSuccess(System.String)

 Write line with foreground color Success. 

|Name | Description |
|-----|------|
|text: |Text to be displayed.|


---
##### M:aide.ConsoleAssist.Output.WriteLineError(System.String)

 Write line with foreground color Error. 

|Name | Description |
|-----|------|
|text: |Text to be displayed.|


---
##### M:aide.ConsoleAssist.Output.WriteLineWarning(System.String)

 Write line with foreground color Warning. 

|Name | Description |
|-----|------|
|text: |Text to be displayed.|


---
##### M:aide.ConsoleAssist.Output.WriteLineInformation(System.String)

 Write line with foreground color Information. 

|Name | Description |
|-----|------|
|text: |Text to be displayed.|


---
##### M:aide.ConsoleAssist.Output.WriteSuccess(System.String)

 Write line with foreground color Sucess. 

|Name | Description |
|-----|------|
|text: |Text to be displayed.|


---
##### M:aide.ConsoleAssist.Output.WriteError(System.String)

 Write line with foreground color Error. 

|Name | Description |
|-----|------|
|text: |Text to be displayed.|


---
##### M:aide.ConsoleAssist.Output.WriteWarning(System.String)

 Write line with foreground color Warning. 

|Name | Description |
|-----|------|
|text: |Text to be displayed.|


---
##### M:aide.ConsoleAssist.Output.WriteInformation(System.String)

 Write line with foreground color Information. 

|Name | Description |
|-----|------|
|text: |Text to be displayed.|


---


