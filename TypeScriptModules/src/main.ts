import './style.css'

// import the thing exported from the file `./randomInteger.ts`
import randomInteger from './randomInteger'

const role = randomInteger(0, 6) + 1
console.log(`You just rolled a ${role}!`)
