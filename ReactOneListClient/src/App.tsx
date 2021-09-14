import React from 'react'
import logo from './images/sdg-logo.png'

export function App() {
  return (
    <div className="app">
      <header>
        <h1>One List</h1>
      </header>
      <main>
        <ul>
          <li>Do a thing</li>
          <li>Do something else</li>
          <li>Do a third thing</li>
          <li>Remind me about the important thing</li>
          <li>The important things are the important things</li>
        </ul>
        <form>
          <input type="text" placeholder="Whats up?" />
        </form>
      </main>
      <footer>
        <p>
          <img src={logo} height="42" alt="logo" />
        </p>
        <p>&copy; 2020 Suncoast Developers Guild</p>
      </footer>
    </div>
  )
}
