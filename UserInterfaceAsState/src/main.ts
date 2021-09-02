import './style.css'

const root = document.querySelector('#root')

type Team = {
  id: number
  name: string
  score: number
}

let teams: Team[] = [
  {
    id: 1,
    name: 'Team 1',
    score: 0,
  },
  {
    id: 2,
    name: 'Team 2',
    score: 12,
  },
  {
    id: 3,
    name: 'Team 3',
    score: 90,
  },
  {
    id: 4,
    name: 'SDG Coders',
    score: 9001,
  },
]

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
  ${teams
    .map(function (team) {
      return renderTeam(team)
    })
    .join('')}
  </main>
  <footer>
    <button>Reset</button>
  </footer>
  `

  if (root) {
    root.innerHTML = html
  }

  teams.forEach(function (team) {
    setupListeners(team)
  })

  document
    .querySelector('footer button')
    ?.addEventListener('click', function () {
      teams = [
        {
          id: 1,
          name: 'Team 1',
          score: 0,
        },
        {
          id: 2,
          name: 'Team 2',
          score: 0,
        },
        {
          id: 3,
          name: 'Team 3',
          score: 0,
        },
        {
          id: 4,
          name: 'SDG Coders',
          score: 0,
        },
      ]

      render()
    })
}

render()
