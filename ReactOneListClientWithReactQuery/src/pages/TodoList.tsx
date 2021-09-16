import axios from 'axios'
import React, { useState } from 'react'
import { TodoItem } from '../components/TodoItem'
import { TodoItemType } from '../App'
import { useQuery } from 'react-query'

async function getTodos() {
  //                               This describes the format of `data`
  //                               vvvvvvvvvvvvvv
  const response = await axios.get<TodoItemType[]>(
    'https://one-list-api.herokuapp.com/items?access_token=cohort22'
  )

  return response.data
}

export function TodoList() {
  // prettier-ignore
  //
  //    The data returned from axios
  //       |
  //       |                   Function to let us reload the data (renamed)
  //       |                      |
  //       |                      |                  Unique identifier for this query
  //       |                      |                     |
  //       |                      |                     |     Function that returns a Promise
  //       |                      |                     |       |
  //       v                      v                     v       v
  const { data: todoItems = [], refetch } = useQuery('todos', () => getTodos())

  const [newTodoText, setNewTodoText] = useState('')

  async function handleCreateNewTodoItem() {
    const body = {
      item: { text: newTodoText },
    }

    const response = await axios.post(
      'https://one-list-api.herokuapp.com/items?access_token=cohort22',
      body
    )

    if (response.status === 201) {
      refetch()
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
              reloadItems={() => refetch()}
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
