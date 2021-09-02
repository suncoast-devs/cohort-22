import './style.css'

const root = document.querySelector('#root')

type Team = {
  id: number
  name: string
  score: number
}

const teamOne: Team = {
  id: 1,
  name: 'Team 1',
  score: 0,
}

const teamTwo: Team = {
  id: 2,
  name: 'Team 2',
  score: 0,
}

function renderTeam(team: Team) {
  const html = `
  <section class="team${team.id}">
    <h2>${team.name}</h2>
    <h3>${team.score}</h3>
    <fieldset>
      <input type="text" placeholder="Name" value="${team.name}" />
    </fieldset>

    <fieldset>
      <i class="add fas fa-2x fa-plus-circle"></i>
      <i class="subtract fas fa-2x fa-minus-circle"></i>
    </fieldset>
  </section>
  `

  return html
}

function setupListeners(team: Team) {
  document
    .querySelector(`.team${team.id} .add`)
    ?.addEventListener('click', function () {
      team.score++
      render()
    })

  document
    .querySelector(`.team${team.id} .subtract`)
    ?.addEventListener('click', function () {
      team.score--
      render()
    })

  document
    .querySelector(`.team${team.id} input`)
    ?.addEventListener('input', function (event) {
      const target = event.target as HTMLInputElement

      team.name = target?.value
      render()
    })
}

function render() {
  const html = `
  <header>
    <h1>My Score Board</h1>
  </header>
  <main>
    ${renderTeam(teamOne)}
    ${renderTeam(teamTwo)}
  </main>
  `

  if (root) {
    root.innerHTML = html
  }

  setupListeners(teamOne)
  setupListeners(teamTwo)
}

render()
