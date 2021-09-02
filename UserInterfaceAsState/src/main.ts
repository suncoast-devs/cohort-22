import './style.css'

// State
let counter = 0

const root = document.querySelector('#root')

function render() {
  const html = `
  <p>${counter + 0}</p>
  <p>${counter + 1}</p>
  <p>${counter + 2}</p>
  <p>${counter + 3}</p>
  <p>${counter + 4}</p>
  <p>${counter + 5}</p>
  <p>${counter + 6}</p>
  <button>Increment This</button>
  `

  if (root) {
    root.innerHTML = html
  }

  // After we create the HTML we can
  // now setup our listener for clicks
  const button = document.querySelector('button')

  function handleButtonClick() {
    counter++

    render()
  }

  button?.addEventListener('click', handleButtonClick)
}

render()
