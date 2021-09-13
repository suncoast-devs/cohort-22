import React, { useState } from 'react'

export function App() {
  const [game, setGame] = useState({
    id: 1,
    board: [
      [' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '],
      [' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '],
      [' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '],
      [' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '],
      [' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '],
      [' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '],
      [' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '],
      [' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '],
    ],
    state: 'new',
    mines: 10,
  })

  return (
    <main>
      <h1>Mine Sweeper</h1>
      <h2>
        <button>New Easy Game</button>
        <button>New Intermediate Game</button>
        <button>New Difficult Game</button>
      </h2>
      <h3>Mines: {game.mines}</h3>
      <h3>Game #: {game.id}</h3>
      <h3></h3>

      <ul className="difficulty-0">
        {game.board.map(function (gameRow) {
          return gameRow.map(function (square, squareIndex) {
            return <li key={squareIndex}>{square}</li>
          })
        })}
      </ul>
    </main>
  )
}
