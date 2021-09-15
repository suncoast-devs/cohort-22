import React from 'react'
import { useParams } from 'react-router'

export function TodoItemPage() {
  //                       Define the structure
  //                       of our params. It is
  //                       an object with one
  //                       key, named "id" that
  //                       is a string.
  const params = useParams<{ id: string }>()

  return <p>This would be the details of item {params.id}!</p>
}
