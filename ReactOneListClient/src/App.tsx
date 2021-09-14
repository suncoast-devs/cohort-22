import axios from 'axios'
import React, { useEffect, useState } from 'react'
import logo from './images/sdg-logo.png'

export function App() {
  const [todoItems, setTodoItems] = useState([])

  // useEffect has a non-async function
  useEffect(function () {
    //
    //
    // Our async function inside!
    async function fetchListOfItems() {
      const response = await axios.get(
        'https://one-list-api.herokuapp.com/items?access_token=cohort22'
      )

      if (response.status === 200) {
        setTodoItems(response.data)
      }
    }
    //
    //
    fetchListOfItems()
  }, [])

  return (
    <div className="app">
      <header>
        <h1>One List</h1>
      </header>
      <main>
        <ul>
          {todoItems.map(function (todoItem) {
            return (
              <li
                key={todoItem.id}
                className={todoItem.complete ? 'completed' : undefined}
              >
                {todoItem.text}
              </li>
            )
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
