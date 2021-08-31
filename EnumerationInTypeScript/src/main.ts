import './style.css'

console.clear()

const colors = ['red', 'green', 'blue']
const numbers = [10, 20, 30]
// const arrayOfStringsAndNumbers = [10, 'Gavin', 42]

// const turnsStringIntoLength = function (someString: string): number {
//   return someString.length
// }

// map is exactly like SELECT from C#
// const lengths = colors.map(function (color: string): number {
//   return color.length
// })

// C#:  var lengths = colors.Select(color => color.Length)
// const lengths = colors.map((color: string): number => color.length)
const lengths = colors.map((color) => color.length)

// array.map(function (element, index, theArrayItself) {
//  returns SOMETHING
// }

const uppercased = colors.map(function (color) {
  return color.toUpperCase()
})

const doubled = numbers.map(function (someNumber: number): string {
  return `The number doubled is ${someNumber * 2}`
})

// const sentences = arrayOfStringsAndNumbers.map(function (someThing) {
//   if (someThing instanceof string) {
//     return someThing.length
//   } else {
//     return someThing * 2
//   }
// })

console.log(doubled)
console.log(lengths)
console.log(uppercased)

// C#:    colors.Where(color => color.Length > 3)
const longColors = colors.filter((color) => color.length > 3)
console.log(longColors)

let initialValue = 0

const total = numbers.reduce(
  /* reduction function */
  (currentTotal, currentNumber) => currentTotal + currentNumber,
  /* initial value*/
  initialValue
)

const product = numbers.reduce(
  (currentProduct, currentNumber) => currentProduct * currentNumber,
  1
)

console.log(product)
console.log(total)
