# FirstBankOfSuncoast

## QUESTIONS / THINGS YOU'D LIKE REVIEW

- Hide text for password
- public private methods
- classes re: overview
- LINQ
- extract code and simplify
- CSV

# Two ways of calling methods

# _INSTANCE_ METHOD

# - Typically USE properties of the object

# - Shared behavior, unique data per object

var riley = new Dog();
riley.Name = "Riley";
riley.Bark(); // "Riley says Woof"

var roscoe = new Dog();
roscoe.Name = "Roscoe";
roscoe.Bark(); // "Roscoe says Woof"

var thing = new Program();
thing.Main();

# STATIC METHOD

# - Entry point for programs

# - "Factory" functions (methods that make instances)

# - Constants (Math.PI)

# - Methods that talk about the class itself

Program.Main();
