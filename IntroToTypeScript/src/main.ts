import './style.css'

// Just like C#  var score = 98;
let score = 98
const answer = 42

// : string
//
// ^^^^ this is TypeScript specific, it is NOT valid JavaScript
//      since this is me teaching TypeScript the type of the variable
const personName: string = 'Mary'

let students = ['Mary', 'Steven', 'Paulo', 'Sophia']
let scores = [98, 100, 55, 100]
const differentKindsOfThings: (string | number | boolean)[] = [
  42,
  'Ice Cream',
  100,
  'Tacos',
]

differentKindsOfThings.push(3.14159265)
differentKindsOfThings.push('Tim')
differentKindsOfThings.push(true)

if (score == 42) {
  let thisVariableExistsOnlyHere = 'Sue'

  thisVariableExistsOnlyHere = 'Bob'
}

// thisVariableExistsOnlyHere = 'Bob'

const x = 'The answer is ' + 42

const y = 42 + ' is the answer'

// Console.WriteLine
console.log(x)
console.log(y)

let z: string

z = '37' - 7
z = '37' + 7

console.log(z)

{
  const score = 98

  const answer = 42

  // var message = $"Congratulations, {answer} is correct..."
  const message = `Congratulations ${answer} is correct. You have ${score} points`
  console.log(message)
}

type Car = {
  make: string
  model: string
  year: number
}

// This defines a variable of type object
const myCar: Car = {
  make: 'Ford',
  model: 'Mustang',
  year: 1969,
}

console.log(`My car is a ${myCar.make}`)
myCar.model = 'Fiesta'

// These are the same
myCar.make
myCar['make']
console.log(`My car, using brackets, is a ${myCar['make']}`)

const theirCar: Car = {
  make: 'Jeep',
  model: 'Wranger',
  year: 2021,
}

const otherCar: Car = {
  make: 'Honda',
  model: 'Fit',
  year: 2020,
}

console.log(`the other car is a ${otherCar.model}`)

// const myOtherCar: Car = {
//   make: myCar.make,
//   model: myCar.model,
//   year: 1971,
// }
const myOtherCar: Car = {
  // This is the same as the following code
  // make: myCar.make,
  // model: myCar.model,
  // year: myCar.year,
  ...myCar,
  year: 1971,
}
console.table(myOtherCar)

const myName = window.prompt('What is your name')
