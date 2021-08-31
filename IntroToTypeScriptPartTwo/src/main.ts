import './style.css'

console.clear()

const employees: string[] = []

employees[0] = 'Rivest, Ron'
employees[1] = 'Shamir, Adi'
employees[2] = 'Adleman, Leonard'

// const betterEmployees = ['Rivest, Ron', 'Shamir, Adi', 'Adleman, Leonard']

// const cantChangeTheseValues: ReadonlyArray<number> = [42, 100, 52]
// cantChangeTheseValues[0] = 12
// console.log(cantChangeTheseValues)

const colors = ['red', 'green', 'blue']
// for (let index = 0; index < colors.length; index++) {
//   const color = colors[index]

//   console.log(color)
// }
colors.forEach((color) => console.log(color))

let favoriteNumber: number = 42

if (favoriteNumber > 12 && favoriteNumber < 100) {
  console.log('Wow')
} else {
  console.log('boooo!')
}

const someInput = '42'

if (favoriteNumber === Number(someInput)) {
  console.log('ok, whatever')
}

switch (favoriteNumber) {
  case 42:
    console.log('Great')
    break
  case 100:
    console.log('Other')
    break
  case 101:
    console.log('Other')
    break
}

// function keyword
// |
// |     name of the function
// |     |
// |     |    required parenthesis where arguments will go
// |     |    |
// |     |    |  opening scope of the function
// |     |    |  |
// |     |    |  |
// v     v    v  v
function greet() {
  console.log('Hello there programmer!')
}

/*  C# style
public int square(int valueToSquare)
*/

//                             argument type
//                             |
//                             |        function return type (optional)
//                             |        |
//                             |        |
//                             v        v
// function square(valueToSquare: number): number {
//   return valueToSquare * valueToSquare
// }

const square = function (valueToSquare: number): number {
  return valueToSquare * valueToSquare
}

function double(valueToDouble: number): number {
  return valueToDouble * 2
}

function makeSomeThing(value: number): string {
  return `WOW ${value}`
}

function makeSomeThingElse(value: string): number {
  return Number(value) + 100
}

function upperCase(value: string): string {
  return value.toUpperCase()
}

// Defines a new type that is a FUNCTION (by the =>) that takes a number and returns a number
type PrintItFunction = (tacoTuesdayCanBeAnything: number) => number

function printIt(numbers: number[], func: PrintItFunction) {
  for (let index = 0; index < numbers.length; index++) {
    const value = numbers[index]
    const result = func(value)

    console.log(`Turned ${value} into ${result}`)
  }
}

const numbers = [1, 2, 3, 4, 5]
printIt(numbers, square)
printIt(numbers, double)
// These would be errors
// printIt(numbers, makeSomeThing)
// printIt(numbers, makeSomeThingElse)

// const words = ['hello', 'there']
// printIt(words, upperCase)

const variableFromOuterScope = "Wow, I'm from the outer scope"

function thisFunctionActsLikeAClosure() {
  const variableFromInnerScope = 42
  console.log(
    `I'm a closure! I have access to the variable "${variableFromOuterScope}" and the variable "${variableFromInnerScope}"`
  )
  // Have the debugger stop the program so we can look around
  debugger
}

thisFunctionActsLikeAClosure()
