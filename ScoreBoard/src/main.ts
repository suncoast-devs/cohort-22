import './style.css'

console.clear()

// Find all the elements we are going to work with
// either for adding event listeners *OR* updating

const teamOnePlusButton = document.querySelector('.team1 i.add')
const teamOneMinusButton = document.querySelector('.team1 i.subtract')
const teamOneScoreText = document.querySelector('.team1 h3')
const teamOneNameInput = document.querySelector('.team1 input')
const teamOneNameText = document.querySelector('.team1 h2')
let teamOneScore = 0

const teamTwoPlusButton = document.querySelector('.team2 i.add')
const teamTwoMinusButton = document.querySelector('.team2 i.subtract')
const teamTwoScoreText = document.querySelector('.team2 h3')
const teamTwoNameInput = document.querySelector('.team2 input')
const teamTwoNameText = document.querySelector('.team2 h2')
let teamTwoScore = 0

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

function teamOneNameInputChanged(event: Event) {
  const inputThatWasChanged = event.target

  if (inputThatWasChanged instanceof HTMLInputElement) {
    const textThatWasInput = inputThatWasChanged.value

    if (teamOneNameText) {
      teamOneNameText.textContent = textThatWasInput
    }
  }
}
teamOneNameInput?.addEventListener('input', teamOneNameInputChanged)

// Starts Team Two

function handleClickOnTeamTwoPlusButton() {
  teamTwoScore++

  if (teamTwoScoreText) {
    teamTwoScoreText.textContent = `${teamTwoScore}`
  }
}

teamTwoPlusButton?.addEventListener('click', handleClickOnTeamTwoPlusButton)

function handleClickOnTeamTwoMinusButton() {
  // Guard clause here to protect the code below...
  if (teamTwoScore === 0) {
    console.debug('Ooops, user tried to go less than 0')
    // GUARD, early return
    return
  }

  teamTwoScore--

  if (teamTwoScoreText) {
    teamTwoScoreText.textContent = `${teamTwoScore}`
  }
}

teamTwoMinusButton?.addEventListener('click', handleClickOnTeamTwoMinusButton)
