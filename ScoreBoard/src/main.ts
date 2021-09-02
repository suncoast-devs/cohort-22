import './style.css'

// Find all the elements we are going to work with
// either for adding event listeners *OR* updating

const teamOnePlusButton = document.querySelector('i')
const teamOneMinusButton = document.querySelector('i.subtract')
const teamOneScoreText = document.querySelector('h3')
let teamOneScore = 0

function handleClickOnTeamOnePlusButton() {
  teamOneScore++

  console.log(teamOneScore)
}

teamOnePlusButton?.addEventListener('click', handleClickOnTeamOnePlusButton)

function handleClickOnTeamOneMinusButton() {
  teamOneScore--
  console.log(teamOneScore)
}

teamOneMinusButton?.addEventListener('click', handleClickOnTeamOneMinusButton)
