import './style.css'

console.clear()

const colors = ['red', 'green', 'blue']
const lengths: number[] = []

function logSomeColor(color: string) {
  const lengthOfColor = color.length

  lengths.push(lengthOfColor)
}

colors.forEach(logSomeColor)
console.log(lengths)
