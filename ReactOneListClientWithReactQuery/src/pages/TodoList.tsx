import axios from 'axios'
import React, { useState } from 'react'
import { TodoItem } from '../components/TodoItem'
import { TodoItemType } from '../App'
import { useMutation, useQuery } from 'react-query'

async function getTodos() {
  //                               This describes the format of `data`
  //                               vvvvvvvvvvvvvv
  const response = await axios.get<TodoItemType[]>(
    'https://one-list-api.herokuapp.com/items?access_token=cohort22'
  )

  return response.data
}

async function createNewTodoItem(newTodoText: string) {
  const response = await axios.post(
    'https://one-list-api.herokuapp.com/items?access_token=cohort22',
    { item: { text: newTodoText } }
  )

  return response
}

export function TodoList() {
  // prettier-ignore
  //
  //    The data returned from axios
  //       |
  //       |                   Function to let us reload the data (renamed)
  //       |                      |
  //       |                      |                                Unique identifier for this query
  //       |                      |                                   |
  //       |                      |                                   |     Function that returns a Promise
  //       |                      |                                   |       |
  //       v                      v                                   v       v
  const { data: todoItems = [], refetch: refetchTodos } = useQuery('todos', () => getTodos())

  const todoItemMutation = useMutation(
    (newTodoText: string) => createNewTodoItem(newTodoText),
    {
      // options
      onSuccess: function () {
        refetchTodos()

        setNewTodoText('')
      },
    }
  )

  // or function style
  //
  // const todoItemMutation = useMutation(function (newTodoText: string) {
  //   return createNewTodoItem(newTodoText)
  // })

  const [newTodoText, setNewTodoText] = useState('')

  return (
    <>
      <ul>
        {todoItems.map(function (todoItem) {
          return (
            <TodoItem
              key={todoItem.id}
              todoItem={todoItem}
              reloadItems={() => refetchTodos()}
            />
          )
        })}
      </ul>
      <form
        onSubmit={function (event) {
          // Please form, don't do your usual behavior
          // *I* will tell you what to do
          event.preventDefault()

          todoItemMutation.mutate(newTodoText)
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
