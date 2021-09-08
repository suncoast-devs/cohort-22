import React, { useState } from 'react'

export function Counter() {
  // const valueAndSetMethod /* <- array */ = useState(0 /* initial state */)

  // const counter = valueAndSetMethod[0]
  // const setCounter = valueAndSetMethod[1]

  const [counter, setCounter] = useState(0)
  const [name, setName] = useState('')

  // function handleClickCounter() {
  //   setCounter(counter + 1)
  // }

  // function handleChangeInput(event: React.ChangeEvent<HTMLInputElement>) {
  //   // I need the event here...
  //   setName(event.target.value)
  // }

  return (
    <div>
      <p>
        Hi there {name} the count is {counter}
      </p>
      <p>{name.toLowerCase()}</p>
      <p>{name.toUpperCase()}</p>
      <button onClick={() => setCounter(counter + 1)}>Increment</button>
      <p>
        <input
          type="text"
          value={name}
          onChange={(event) => setName(event.target.value)}
        />
      </p>
    </div>
  )
}
