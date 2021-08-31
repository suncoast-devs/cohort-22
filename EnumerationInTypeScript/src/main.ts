import './style.css'

const colors = ['red', 'green', 'blue']

function logSomeColor(color: string, index: number) {
  console.log(`The color at position ${index} is ${color}`)
}

colors.forEach(logSomeColor)
