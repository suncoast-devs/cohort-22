import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { TodoItem } from '../components/TodoItem'
import { TodoItemType } from '../App'

export function TodoList() {
  const [todoItems, setTodoItems] = useState<TodoItemType[]>([])
  const [newTodoText, setNewTodoText] = useState('')

  function loadAllTheItems() {
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
  }

  // useEffect has a non-async function
  useEffect(loadAllTheItems, [])

  async function handleCreateNewTodoItem() {
    const body = {
      item: { text: newTodoText },
    }

    const response = await axios.post(
      'https://one-list-api.herokuapp.com/items?access_token=cohort22',
      body
    )

    if (response.status === 201) {
      loadAllTheItems()
    }
  }

  return (
    <>
      <ul>
        {todoItems.map(function (todoItem) {
          return (
            <TodoItem
              key={todoItem.id}
              todoItem={todoItem}
              reloadItems={loadAllTheItems}
            />
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
    </>
  )
}
