import React, { useState } from 'react'

export function App() {
  const [temperature, setTemperature] = useState(72)

  function handleChangeTemperature(event: React.ChangeEvent<HTMLInputElement>) {
    setTemperature(Number(event.target.value))
  }

  const turnAmount = temperature / 120.0

  let color = '#5a9090'

  if (temperature > 90) {
    color = 'red'
  } else if (temperature < 70) {
    color = 'blue'
  }

  const transform = `rotate(${turnAmount}turn)`

  return (
    <main>
      <section>
        <figure className="temperature">
          <i
            className="dial fas fa-circle-notch"
            style={{ transform, color }}
          />
          <span className="temperature-container">
            <span className="temperature-number">{temperature}</span>
          </span>
        </figure>
        <input
          className="slider"
          type="range"
          min="0"
          max="120"
          value={temperature}
          onChange={handleChangeTemperature}
        />
      </section>
    </main>
  )
}
