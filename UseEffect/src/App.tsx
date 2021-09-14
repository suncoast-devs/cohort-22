import React, { useState } from 'react'

export function App() {
  const [count, setCount] = useState(0)

  function handleClickButton() {
    setCount(count + 1)
  }

  return (
    <div>
      <p>
        Count: {count} <button onClick={handleClickButton}>Click Me</button>
      </p>
    </div>
  )
}
