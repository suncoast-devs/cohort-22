import React, { useState } from 'react'
import words from './words.json'

const ALPHABET = [
  'A',
  'B',
  'C',
  'D',
  'E',
  'F',
  'G',
  'H',
  'I',
  'J',
  'K',
  'L',
  'M',
  'N',
  'O',
  'P',
  'Q',
  'R',
  'S',
  'T',
  'U',
  'V',
  'W',
  'X',
  'Y',
  'Z',
]

export function App() {
  const [guessedLetters, setGuessedLetters] = useState(['G', 'A', 'V'])
  const secretWord = words[0]

  console.log(secretWord)

  function clickOnLetter(letter: string) {
    // Make a new state USING the old state plus the information
    const newValueForGuessedLetters = [...guessedLetters, letter]

    setGuessedLetters(newValueForGuessedLetters)
  }

  return (
    <div>
      <div>Your guessed letters are: {guessedLetters}</div>
      {ALPHABET.map(function (letter) {
        return (
          <button
            key={letter}
            onClick={function () {
              clickOnLetter(letter)
            }}
            disabled={guessedLetters.includes(letter)}
          >
            {letter}
          </button>
        )
      })}
    </div>
  )
}
