# Plak
## A Simple Programming Language Designed for Creating Text Games Effortlessly

![image](https://github.com/SuperTavor/Plak/assets/111663937/5ddaf243-dbed-4a64-8485-cd8790e516cd)

*credit to kingu, he made the logo*

# Syntax for Plak 0.1:
### Headers
In Plak-lang, a header represents a print statement that must be accompanied by choices.
To create a header, use `-` followed by `[Your_text]`.

Example:
```-Welcome to this text game! Would you prefer to be a warrior, or a wizard?```

### Adding Choices to Headers
To include choices within a header, press `tab` for indentation on a new line.
To add a choice, use `--` followed by `[Your_choice]`.

Example:
```
-Welcome to this text game! Would you prefer to be a warrior, or a wizard?
--Warrior
--Wizard
```

### Choice Branching
Once a choice is defined, you can press enter to move to a new line and indent it to make it a child of the choice.
You can define a header or a syscall at this level. Note that a choice cannot be a direct child of another choice.

Example:
```
-Welcome to this text game! Would you prefer to be a warrior, or a wizard?
--Warrior
  -Awesome!
--Wizard
  -That's cool!
```

### Syscalls
Syscalls are predefined functions you can use, wrapped in `[]`. They can be used as a normal child for any choice. Syscalls are not case sensitive, but it's advisable to write them in all caps.

Currently available syscalls:
- `END` - Terminates the process.
(that's it for now, I will add more)

Example:
```
-Welcome to this text game! Would you prefer to be a warrior, or a wizard?
--Warrior
  -Awesome!
    [END]
--Wizard
  -That's cool!
    [END]
```
# What will be added in the next update:
- [WAIT] syscall
- free-write responses
