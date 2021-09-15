import React, { useEffect, useState } from 'react'

type Coin = {
  name: string
}

export function App() {
  const [coins, setCoins] = useState<Coin[]>([])

  useEffect(function () {
    async function loadCoins() {
      const response = await fetch('https://api.coincap.io/v2/assets')

      if (response.ok) {
        const { data } = await response.json()

        setCoins(data)
      }
    }

    loadCoins()
  })

  useEffect(function () {
    // If useEffect sets up something that consumes
    // a resource, like an interval identifier
    const timerInterval = setInterval(function () {
      console.log('Calling my interval')
    }, 1000)

    // ... then we near a teardown function to undo
    //     that resource
    function teardown() {
      console.log('clearing the interval')
      clearInterval(timerInterval)
    }

    // ... and we return that function!
    return teardown
  }, [])

  const header = `There are ${coins.length} coins`

  return (
    <div>
      <p>{header}</p>
      {coins.map((coin) => (
        <p key={coin.name}>{coin.name}</p>
      ))}{' '}
    </div>
  )
}
