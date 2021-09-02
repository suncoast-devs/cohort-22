import './style.css'

// Find all the elements we are going to work with
// either for adding event listeners *OR* updating

const teamOnePlusButton = document.querySelector('i')
const teamOneMinusButton = document.querySelector('i.subtract')
const teamOneScoreText = document.querySelector('h3')
let teamOneScore = 0

function handleClickOnTeamOnePlusButton() {
  teamOneScore++

  if (teamOneScoreText) {
    teamOneScoreText.textContent = `${teamOneScore}`
  }
}

teamOnePlusButton?.addEventListener('click', handleClickOnTeamOnePlusButton)

function handleClickOnTeamOneMinusButton() {
  // Guard clause here to protect the code below...
  if (teamOneScore === 0) {
    console.debug('Ooops, user tried to go less than 0')
    // GUARD, early return
    return
  }

  teamOneScore--

  if (teamOneScoreText) {
    teamOneScoreText.textContent = `${teamOneScore}`
  }
}

teamOneMinusButton?.addEventListener('click', handleClickOnTeamOneMinusButton)
