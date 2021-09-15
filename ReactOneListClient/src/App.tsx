import React from 'react'
import { Route, Switch } from 'react-router'
import logo from './images/sdg-logo.png'
import { TodoList } from './TodoList'

export type TodoItemType = {
  id: number
  text: string
  complete: boolean
  updated_at: Date
  completed_at: Date
}

export function App() {
  return (
    <div className="app">
      <header>
        <h1>One List</h1>
      </header>
      <main>
        <Switch>
          <Route exact path="/">
            <TodoList />
          </Route>
        </Switch>
      </main>
      <footer>
        <p>
          <img src={logo} height="42" alt="logo" />
        </p>
        <p>&copy; 2020 Suncoast Developers Guild</p>
      </footer>
    </div>
  )
}
