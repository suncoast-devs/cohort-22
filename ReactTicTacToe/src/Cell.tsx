import React from 'react'

export function Cell(props: CellProps) {
  const { cell, rowIndex, columnIndex, recordMove } = props

  function handleClickCell() {
    console.log(`You clicked on ${rowIndex} - ${columnIndex}`)

    // Now we can use props.recordMove
    recordMove(rowIndex, columnIndex)
  }

  return (
    <button
      className={cell === ' ' ? undefined : 'taken'}
      onClick={handleClickCell}
    >
      {cell}
    </button>
  )
}

type CellProps = {
  cell: string
  rowIndex: number
  columnIndex: number
  recordMove: (row: number, column: number) => void
}
