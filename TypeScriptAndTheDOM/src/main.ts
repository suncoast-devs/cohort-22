import './style.css'

const firstListItem = document.querySelector('li')

function handleClickSquare(event) {
  const thingClickedOn = event.target

  thingClickedOn.textContent = 'X'
}

firstListItem?.addEventListener('click', handleClickSquare)
