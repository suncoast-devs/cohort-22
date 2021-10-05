import { authHeader } from './auth'
import {
  LoginSuccess,
  LoginUserType,
  NewRestaurantType,
  NewReviewType,
  NewUserType,
  RestaurantType,
} from './types'

// Null Object Pattern
export const NullRestaurant: RestaurantType = {
  id: undefined,
  userId: 0,
  name: '',
  address: '',
  description: '',
  telephone: '',
  latitude: 0,
  longitude: 0,
  photoURL: '',
  reviews: [],
}

export async function loadOneRestaurant(id: string) {
  const response = await fetch(`/api/restaurants/${id}`)

  if (response.ok) {
    return response.json()
  } else {
    throw await response.json()
  }
}

// Takes a review object and submits it to the API
//
// Returns a promise of the JSON response of the API
// when successful, throws the JSON response of the API
// when there is a failure.
export async function submitNewReview(review: NewReviewType) {
  // Calls fetch
  const response = await fetch(`/api/Reviews`, {
    method: 'POST',
    headers: {
      'content-type': 'application/json',
      Authorization: authHeader(),
    },
    body: JSON.stringify(review),
  })

  if (response.ok) {
    return response.json()
  } else {
    throw await response.json()
  }
}

export async function handleDelete(id: number | undefined) {
  // If we don't know the id, don't do anything.
  // This could happen because the restaurant might
  // have an undefined id before it is loaded. In that
  // case we don't want to call the API since the URL
  // won't be correct.
  if (id === undefined) {
    return
  }

  const response = await fetch(`/api/Restaurants/${id}`, {
    method: 'DELETE',
    headers: {
      'content-type': 'application/json',
      Authorization: authHeader(),
    },
  })

  if (response.ok) {
    return response.json()
  } else {
    throw await response.json()
  }
}

export async function submitEditedRestaurant(
  restaurantToUpdate: NewRestaurantType
) {
  const response = await fetch(`/api/Restaurants/${restaurantToUpdate.id}`, {
    method: 'PUT',
    headers: {
      'content-type': 'application/json',
      Authorization: authHeader(),
    },
    body: JSON.stringify(restaurantToUpdate),
  })

  if (response.ok) {
    return response.json()
  } else {
    throw await response.json()
  }
}

export async function submitNewRestaurant(
  restaurantToCreate: NewRestaurantType
) {
  const response = await fetch('/api/Restaurants', {
    method: 'POST',
    headers: {
      'content-type': 'application/json',
      Authorization: authHeader(),
    },
    body: JSON.stringify(restaurantToCreate),
  })

  if (response.ok) {
    return response.json()
  } else {
    throw await response.json()
  }
}

export async function loginUser(user: LoginUserType): Promise<LoginSuccess> {
  const response = await fetch('/api/Sessions', {
    method: 'POST',
    headers: { 'content-type': 'application/json' },
    body: JSON.stringify(user),
  })

  if (response.ok) {
    return response.json()
  } else {
    throw await response.json()
  }
}

export async function submitNewUser(newUser: NewUserType) {
  const response = await fetch('/api/Users', {
    method: 'POST',
    headers: { 'content-type': 'application/json' },
    body: JSON.stringify(newUser),
  })

  if (response.ok) {
    return response.json()
  } else {
    throw await response.json()
  }
}
