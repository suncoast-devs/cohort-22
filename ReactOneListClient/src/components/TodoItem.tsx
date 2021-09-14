import axios from 'axios'
import React from 'react'
import { TodoItemType } from '../App'

type TodoItemProps = {
  todoItem: TodoItemType
  reloadItems: () => void
}

export function TodoItem({
  todoItem: { id, text, complete },
  reloadItems,
}: TodoItemProps) {
  // Destructuring the props, allows me to treat them like local variables
  async function toggleCompleteStatus() {
    const response = await axios.put(
      `https://one-list-api.herokuapp.com/items/${id}?access_token=cohort22`,
      { item: { complete: !complete } }
    )

    if (response.status === 200) {
      reloadItems()
    }
  }

  return (
    <li
      className={complete ? 'completed' : undefined}
      onClick={toggleCompleteStatus}
    >
      {text}
    </li>
  )
}
