import './style.css'

// import the thing exported from the file `./randomInteger.ts`
import giveMeRandomNumber from './randomInteger'

// Named exports get named imports
// imports the named export 'diagonalLength'
// imports the named export 'square'
import { diagonalLength as pythagoreanLength, square } from './util'

const role = giveMeRandomNumber(0, 6) + 1
console.log(`You just rolled a ${role}!`)

console.log(pythagoreanLength(4, 3))

console.log(`The square of 12 is ${square(12)}`)
