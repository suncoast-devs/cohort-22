import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useHistory, useParams } from 'react-router'
import { Link } from 'react-router-dom'
import { TodoItemType } from '../App'

export function TodoItemPage() {
  const history = useHistory()
  //                       Define the structure
  //                       of our params. It is
  //                       an object with one
  //                       key, named "id" that
  //                       is a string.
  const params = useParams<{ id: string }>()

  const [todoItem, setTodoItem] = useState<TodoItemType>({
    id: undefined,
    text: '',
    complete: false,
    created_at: undefined,
    updated_at: undefined,
  })

  useEffect(
    function () {
      async function loadItems() {
        const response = await axios.get(
          `https://one-list-api.herokuapp.com/items/${params.id}?access_token=cohort22`
        )

        if (response.status === 200) {
          setTodoItem(response.data)
        }
      }

      loadItems()
    },
    [params.id]
  )

  async function deleteTodoItem() {
    const response = await axios.delete(
      `https://one-list-api.herokuapp.com/items/${params.id}?access_token=cohort22`
    )

    if (response.status === 204) {
      // Redirect back to the home page!
      history.push('/')
    }
  }

  // Since the default state has an id that is undefined
  // render NOTHING until there is an id -- that only happens
  // once we load from the API
  if (!todoItem.id) {
    return null
  }

  return (
    <div>
      <p>
        <Link to="/">Home</Link>
      </p>
      <p className={todoItem.complete ? 'completed' : ''}>{todoItem.text}</p>
      <p>Created: {todoItem.created_at}</p>
      <p>Updated: {todoItem.updated_at}</p>
      <button onClick={deleteTodoItem}>Delete</button>
    </div>
  )
}
