import React from 'react'
import { useMutation } from 'react-query'
import { Link } from 'react-router-dom'
import { toggleItemComplete } from '../api'
import { TodoItemType } from '../App'

type TodoItemProps = {
  todoItem: TodoItemType
  reloadItems: () => void
}

export function TodoItem({
  todoItem: { id, text, complete },
  reloadItems,
}: TodoItemProps) {
  const toggleMutation = useMutation(() => toggleItemComplete(id, complete), {
    onSuccess: function () {
      reloadItems()
    },
  })

  return (
    <li className={complete ? 'completed' : undefined}>
      <span
        onClick={function () {
          toggleMutation.mutate()
        }}
      >
        {text}
      </span>
      <Link to={`/items/${id}`}>Show</Link>
    </li>
  )
}
