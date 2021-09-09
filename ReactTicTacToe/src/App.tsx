import React, { useState } from 'react'

export function App() {
  const [game, setGame] = useState({
    board: [
      [' ', ' ', ' '],
      [' ', ' ', ' '],
      [' ', ' ', ' '],
    ],
    id: null,
    winner: null,
  })

  async function handleClickCell(row: number, column: number) {
    // console.log(`You clicked on row ${row} and column ${column}`)
    console.log({ row, column })

    // Generate the URL we need
    const url = `https://sdg-tic-tac-toe-api.herokuapp.com/game/${game.id}`

    // Make an object to send as JSON
    const body = { row, column }

    // Make a POST request to make a move
    const response = await fetch(url, {
      method: 'POST',
      headers: { 'content-type': 'application/json' },
      body: JSON.stringify(body),
    })

    if (response.ok) {
      // Get the response as JSON
      const newGameState = await response.json()

      // Make that the new state!
      setGame(newGameState)
    }
  }

  async function handleNewGame() {
    // Make a POST request to ask for a new game
    const response = await fetch(
      'https://sdg-tic-tac-toe-api.herokuapp.com/game',
      {
        method: 'POST',
        headers: { 'content-type': 'application/json' },
      }
    )

    if (response.ok) {
      // Get the response as JSON
      const newGameState = await response.json()
      setGame(newGameState)
    }
  }

  const header = game.winner ? `${game.winner} is the winner` : 'Tic Tac Toe'

  return (
    <div>
      <h1>
        {header} - {game.id} <button onClick={handleNewGame}>New</button>
      </h1>
      <ul>
        {game.board.map((row, rowIndex) =>
          row.map((column, columnIndex) => (
            <li
              key={columnIndex}
              onClick={() => handleClickCell(rowIndex, columnIndex)}
            >
              {game.board[rowIndex][columnIndex]}
            </li>
          ))
        )}
      </ul>
    </div>
  )
}
