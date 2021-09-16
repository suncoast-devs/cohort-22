import React from 'react'
import { useHistory, useParams } from 'react-router'
import { Link } from 'react-router-dom'
import { useDeleteItemMutation, useLoadOneItem } from '../api'

export function TodoItemPage() {
  const history = useHistory()
  const params = useParams<{ id: string }>()

  const { todoItem, isTodoItemLoading } = useLoadOneItem(params.id)

  const deleteMutation = useDeleteItemMutation(params.id, function () {
    history.push('/')
  })

  if (isTodoItemLoading) {
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
          deleteMutation.mutate()
        }}
      >
        Delete
      </button>
    </div>
  )
}
