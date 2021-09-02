import './style.css'

// Find all the elements we are going to work with
// either for adding event listeners *OR* updating

const teamOnePlusButton = document.querySelector('i')
const teamOneMinusButton = document.querySelector('i.subtract')
const teamOneScore = document.querySelector('h3')

function handleClickOnTeamOnePlusButton() {
  console.log('I clicked on team one plus button')
}

teamOnePlusButton?.addEventListener('click', handleClickOnTeamOnePlusButton)

function handleClicikOnTeamOneMinusButton() {
  console.log('I clicked on team one minus button')
}

teamOneMinusButton?.addEventListener('click', handleClicikOnTeamOneMinusButton0)
