# Plak-lang
## Programming language for making text games super easily.

![image](https://github.com/SuperTavor/G-lang/assets/111663937/89333559-7c5e-4f93-829f-077d1cd30a6b)


*I made this logo in ms paint.*

# Syntax:
### Headers.
a Plak header is a print statement that has to be followed by choices.
`-` + `[Your_text]`

Example:
```-Welcome to this text game! Would you like to be a warrior, or a wizard?```
### Add choices to your header.
In a new line, press `tab` to add a whitespace (for indentation).
You can add a choice like this:
`--` + `[Your_choice]`

Example:
```
-Welcome to this text game! Would you like to be a warrior, or a wizard?
  --Warrior
  --Wizard
```
### Choice branching
after defining a choice, you can click enter to go to a new line. indent it so it's your choice's child.
Here you can define a header, a syscall or a jump statement. You can't have a choice as a direct child of another choice.
Example:
```
-Welcome to this text game! Would you like to be a warrior, or a wizard?
  --Warrior
    -Awesome!
  --Wizard
    -That's cool!
```
### SYSCalls
syscalls are just built in functions you can use. They are wrapped with `[]` and can be used as a normal child for any choice.
Here are all the syscalls so far:

`END_NORMAL` - Exits the game

`END_MSG + your_message` - Exits the game with a custom message to replace "exiting game.."

Example:
```
-Welcome to this text game! Would you like to be a warrior, or a wizard?
  --Warrior
    -Awesome!
      [END]
  --Wizard
    -That's cool!
      [END]
```
### Labels and jumps
Labels and jumps are like any programming language. you define a label like this:

`==label_name`

and you can jump to it like this:

`!label_name`

# This should be about it! Have fun making text games! New features coming soon 👀
