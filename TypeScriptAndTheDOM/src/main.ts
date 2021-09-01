import './style.css'

let currentPlayer: 'X' | 'O' = 'X'

// Generic and works for ANY `li`
//
// Because the event tells us the target
// and the target is the thing we clicked on!
function handleClickSquare(event: MouseEvent) {
  const thingClickedOn = event.target

  // If the thing clicked on is an LI Element
  // - This does several things:
  // - 1. Checks that the target isn't null
  // - 2. Let's TypeScript know that *inside* this if statement
  //      the thingClickedOn is an LI element, and thus we can
  //      change its textContent
  if (thingClickedOn instanceof HTMLLIElement) {
    // If the element ALREADY has `taken` we shouldn't
    // let them click again! We do this by ENDING (returning)
    // from the function RIGHT AWAY
    if (thingClickedOn.classList.contains('taken')) {
      console.log('NOPES')
      return
    }

    thingClickedOn.textContent = currentPlayer

    // Adds the taken class so that we SHOW the user
    // they can't select this item!
    thingClickedOn.classList.add('taken')

    if (currentPlayer === 'X') {
      currentPlayer = 'O'
    } else {
      currentPlayer = 'X'
    }
  }
}

const allSquares = document.querySelectorAll('li')

allSquares.forEach((square) =>
  square.addEventListener('click', handleClickSquare)
)
