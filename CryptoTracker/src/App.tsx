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

  return (
    <div>
      {coins.map((coin) => (
        <p key={coin.name}>{coin.name}</p>
      ))}{' '}
    </div>
  )
}
