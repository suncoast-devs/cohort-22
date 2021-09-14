import React, { useState } from 'react'
import logo from './images/sdg-logo.png'

export function App() {
  const [todoItems, setTodoItems] = useState([
    { id: 1, text: 'Do a thing', complete: false },
    { id: 2, text: 'Do something else', complete: false },
    { id: 3, text: 'Do a third thing', complete: false },
    { id: 4, text: 'Remind me about the important thing', complete: false },
    {
      id: 5,
      text: 'The important things are the important things',
      complete: false,
    },
    {
      id: 6,
      text: 'WOW',
      complete: true,
    },
  ])

  return (
    <div className="app">
      <header>
        <h1>One List</h1>
      </header>
      <main>
        <ul>
          {todoItems.map(function (todoItem) {
            return <li key={todoItem.id}>{todoItem.text}</li>
          })}
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
