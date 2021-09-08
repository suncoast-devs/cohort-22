import React, { useState } from 'react'

export function Counter() {
  // const valueAndSetMethod /* <- array */ = useState(0 /* initial state */)

  // const counter = valueAndSetMethod[0]
  // const setCounter = valueAndSetMethod[1]

  const [counter, setCounter] = useState(0)

  return (
    <div>
      <p>The count is {counter}</p>
      <button>Increment</button>
    </div>
  )
}
