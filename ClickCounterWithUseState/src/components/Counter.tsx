import React, { useState } from 'react'

export function Counter() {
  // const valueAndSetMethod /* <- array */ = useState(0 /* initial state */)

  // const counter = valueAndSetMethod[0]
  // const setCounter = valueAndSetMethod[1]

  const [counter, setCounter] = useState(0)

  function handleClickCounter(event: React.MouseEvent) {
    event.preventDefault()

    console.log('CLICKED!')
  }

  return (
    <div>
      <p>The count is {counter}</p>
      <button onClick={handleClickCounter}>Increment</button>
    </div>
  )
}
