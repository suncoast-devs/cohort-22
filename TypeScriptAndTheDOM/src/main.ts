import './style.css'

// Generic and works for ANY `li`
//
// Because the event tells us the target
// and the target is the thing we clicked on!
function handleClickSquare(event) {
  const thingClickedOn = event.target

  thingClickedOn.textContent = 'X'
}

const allSquares = document.querySelectorAll('li')

allSquares.forEach((square) =>
  square.addEventListener('click', handleClickSquare)
)
