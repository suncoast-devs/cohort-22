import axios from 'axios'
import React, { useEffect, useState } from 'react'
import logo from './images/sdg-logo.png'

type TodoItemType = {
  id: number
  text: string
  complete: boolean
  updated_at: Date
  completed_at: Date
}

export function App() {
  const [todoItems, setTodoItems] = useState<TodoItemType[]>([])
  const [newTodoText, setNewTodoText] = useState('')

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

  async function handleCreateNewTodoItem() {
    const body = {
      item: { text: newTodoText },
    }

    const response = await axios.post(
      'https://one-list-api.herokuapp.com/items?access_token=cohort22',
      body
    )

    if (response.status === 201) {
      console.log(response.data)
    }
  }

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
        <form
          onSubmit={function (event) {
            // Please form, don't do your usual behavior
            // *I* will tell you what to do
            event.preventDefault()

            handleCreateNewTodoItem()
          }}
        >
          <input
            type="text"
            placeholder="Whats up?"
            value={newTodoText}
            onChange={function (event) {
              setNewTodoText(event.target.value)
            }}
          />
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
