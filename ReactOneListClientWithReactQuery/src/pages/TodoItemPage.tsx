import React from 'react'
import { useMutation, useQuery } from 'react-query'
import { useHistory, useParams } from 'react-router'
import { Link } from 'react-router-dom'
import { deleteOneTodo, getOneTodo } from '../api'
import { TodoItemType } from '../App'

// Null Object Pattern
const EmptyTodoItem: TodoItemType = {
  id: undefined,
  text: '',
  complete: false,
  updated_at: undefined,
  created_at: undefined,
}

export function TodoItemPage() {
  const history = useHistory()
  //                       Define the structure
  //                       of our params. It is
  //                       an object with one
  //                       key, named "id" that
  //                       is a string.
  const params = useParams<{ id: string }>()

  const { data: todoItem = EmptyTodoItem, isLoading } = useQuery(
    ['todo', params.id],
    () => getOneTodo(params.id)
  )

  const deleteMutation = useMutation((id: string) => deleteOneTodo(id), {
    onSuccess: function () {
      // Send user back to the homepage
      history.push('/')
    },
  })

  if (isLoading) {
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
      <button
        onClick={function () {
          deleteMutation.mutate(params.id)
        }}
      >
        Delete
      </button>
    </div>
  )
}
