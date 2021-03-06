import React from 'react'
import { Route, Switch } from 'react-router'
import { Link } from 'react-router-dom'
import logo from './images/sdg-logo.png'
import { TodoItemPage } from './pages/TodoItemPage'
import { TodoList } from './pages/TodoList'

export type TodoItemType = {
  id: number | undefined
  text: string
  complete: boolean
  updated_at: Date | undefined
  created_at: Date | undefined
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
          <Route path="/items/:id">
            <TodoItemPage />
          </Route>
          <Route path="*">
            <p>Ooops, that URL is unknown</p>
          </Route>
        </Switch>
      </main>
      <footer>
        <p>
          <Link to="/">
            <img src={logo} height="42" alt="logo" />
          </Link>
        </p>
        <p>&copy; 2020 Suncoast Developers Guild</p>
      </footer>
    </div>
  )
}
