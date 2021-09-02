import './style.css'

const root = document.querySelector('#root')

type Team = {
  name: string
  score: number
}

const teamOne: Team = {
  name: 'Team 1',
  score: 0,
}

const teamTwo: Team = {
  name: 'Team 2',
  score: 0,
}

function render() {
  const html = `
  <header>
    <h1>My Score Board</h1>
  </header>
  <main>
    <section class="team1">
      <h2>${teamOne.name}</h2>
      <h3>${teamOne.score}</h3>
      <fieldset>
        <input type="text" placeholder="Name" value="${teamOne.name}" />
      </fieldset>

      <fieldset>
        <i class="add fas fa-2x fa-plus-circle"></i>
        <i class="subtract fas fa-2x fa-minus-circle"></i>
      </fieldset>
    </section>

    <section class="team2">
      <h2>${teamTwo.name}</h2>
      <h3>${teamTwo.score}</h3>
      <fieldset>
        <input type="text" placeholder="Name" value="${teamTwo.name}" />
      </fieldset>

      <fieldset>
        <i class="add fas fa-2x fa-plus-circle"></i>
        <i class="subtract fas fa-2x fa-minus-circle"></i>
      </fieldset>
    </section>
  </main>
  `

  if (root) {
    root.innerHTML = html
  }

  document.querySelector('.team1 .add')?.addEventListener('click', function () {
    teamOne.score++
    render()
  })

  document
    .querySelector('.team1 .subtract')
    ?.addEventListener('click', function () {
      teamOne.score--
      render()
    })

  document
    .querySelector('.team1 input')
    ?.addEventListener('input', function (event) {
      const target = event.target as HTMLInputElement

      teamOne.name = target?.value
      render()
    })

  document.querySelector('.team2 .add')?.addEventListener('click', function () {
    teamTwo.score++
    render()
  })
  document
    .querySelector('.team2 .subtract')
    ?.addEventListener('click', function () {
      teamTwo.score--
      render()
    })
  document
    .querySelector('.team2 input')
    ?.addEventListener('input', function (event) {
      const target = event.target as HTMLInputElement

      teamTwo.name = target?.value
      render()
    })
}

render()
