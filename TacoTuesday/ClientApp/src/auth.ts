// Returns an object that can be included in `fetch`
// headers to include the required bearer token
// for authentication
//
// Example usage:
//
// fetch('/api/Thing', {
//    method: 'POST',
//    headers: { 'content-type': 'application/json', ...authHeader() },
//    body: JSON.stringify(thing)
// })

import { LoginSuccess } from './types'

// Returns the Authorization header for the the currently logged in in user.
// If there is no authorization data, we'll return an empty object
export function authHeader() {
  const auth = authFromStorage()

  return auth.token ? `Bearer ${auth.token}` : null
}

// Save the authentication received from the API
//
// This method stores the authentication data as
// a JSON string in local storage. Local storage
// requires everything to be in a string.
//
// This is typically called from a login component
//
export function recordAuthentication(auth: LoginSuccess) {
  localStorage.setItem('auth', JSON.stringify(auth))
}

// Returns a boolean if the user is logged in.
//
// Returns TRUE if there is an active user id, FALSE otherwise
//
export function isLoggedIn() {
  return getUserId() !== undefined
}

// Returns the user id if the logged in user, null otherwise
export function getUserId() {
  const auth = authFromStorage()

  return auth.user && auth.user.id
}

// Returns the user details retrieved from the authentication data
//
// Example:
//
// const user = getUser()
// console.log(user.fullName)
//
export function getUser() {
  const auth = authFromStorage()

  return auth.user
}

// Removes the authentication data, effectively "forgetting" the
// session information and logging the user out.
export function logout() {
  localStorage.removeItem('auth')
}

// Local method to fetch and decode the auth data from local storage
// If there is no local storage value, returns an empty object
function authFromStorage(): LoginSuccess {
  const auth = localStorage.getItem('auth')

  return auth ? JSON.parse(auth) : {}
}
