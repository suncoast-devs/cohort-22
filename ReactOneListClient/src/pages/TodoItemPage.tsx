import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router'
import { TodoItemType } from '../App'

export function TodoItemPage() {
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

  return (
    <div>
      <p className={todoItem.complete ? 'completed' : ''}>{todoItem.text}</p>
      <p>Created: {todoItem.created_at}</p>
      <p>Updated: {todoItem.updated_at}</p>
      <button>Delete</button>
    </div>
  )
}
