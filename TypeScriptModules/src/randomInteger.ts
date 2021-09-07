function randomInteger(min: number, max: number): number {
  min = Math.ceil(min)
  max = Math.floor(max)

  return Math.floor(Math.random() * (max - min)) + min
}

// Allow other parts of our code to IMPORT this
export default randomInteger
