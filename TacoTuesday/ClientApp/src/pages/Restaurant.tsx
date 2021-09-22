import React from 'react'
import { useQuery } from 'react-query'
import { useParams } from 'react-router'
import { Link } from 'react-router-dom'
import { CSSStarsProperties, RestaurantType } from '../types'

async function loadOneRestaurant(id: string) {
  const response = await fetch(`/api/restaurants/${id}`)

  if (response.ok) {
    return response.json()
  } else {
    throw await response.json()
  }
}

// Null Object Pattern
const NullRestaurant: RestaurantType = {
  id: undefined,
  name: '',
  address: '',
  description: '',
  telephone: '',
  reviews: [],
}

export function Restaurant() {
  const { id } = useParams<{ id: string }>()

  const { data: restaurant = NullRestaurant } = useQuery<RestaurantType>(
    ['one-restaurant', id],
    () => loadOneRestaurant(id)
  )

  // Guard clause approach
  // if (restaurant === undefined) {
  //   return null
  // }

  return (
    <main className="page">
      <nav>
        <Link to="/">
          <i className="fa fa-home"></i>
        </Link>
        <h2>{restaurant.name}</h2>
      </nav>
      <p>
        <span
          className="stars"
          style={{ '--rating': 4.7 } as CSSStarsProperties}
          aria-label="Star rating of this location is 4.7 out of 5."
        ></span>
        ({restaurant.reviews.length})
      </p>
      <address>{restaurant.address}</address>
      <hr />
      <h3>Reviews for {restaurant.name} </h3>
      <ul className="reviews">
        {restaurant.reviews.map((review) => (
          <li key={review.id}>
            <div className="author">
              Gavin said: <em>{review.summary}</em>
            </div>
            <div className="body">
              <p>{review.body}</p>
            </div>
            <div className="meta">
              <span
                className="stars"
                style={{ '--rating': review.stars } as CSSStarsProperties}
                aria-label={`Star rating of this location is ${review.stars} out of 5.`}
              ></span>
              <time>{review.createdAt}</time>
            </div>
          </li>
        ))}
      </ul>
      <h3>Enter your own review</h3>
      <form action="#">
        <p className="form-input">
          <label htmlFor="summary">Summary</label>
          <input type="text" name="summary" />
          <span className="note">
            Enter a brief summary of your review. Example:{' '}
            <strong>Great food, good prices.</strong>
          </span>
        </p>
        <p className="form-input">
          <label htmlFor="body">Review</label>
          <textarea name="body"></textarea>
        </p>
        <div className="rating">
          <input id="star-rating-1" type="radio" name="stars" value="1" />
          <label htmlFor="star-rating-1">1 star</label>
          <input id="star-rating-2" type="radio" name="stars" value="2" />
          <label htmlFor="star-rating-2">2 stars</label>
          <input id="star-rating-3" type="radio" name="stars" value="3" />
          <label htmlFor="star-rating-3">3 stars</label>
          <input id="star-rating-4" type="radio" name="stars" value="4" />
          <label htmlFor="star-rating-4">4 stars</label>
          <input id="star-rating-5" type="radio" name="stars" value="5" />
          <label htmlFor="star-rating-5">5 stars</label>

          <div className="star-rating">
            <label
              htmlFor="star-rating-1"
              aria-label="1 star"
              title="1 star"
            ></label>
            <label
              htmlFor="star-rating-2"
              aria-label="2 stars"
              title="2 stars"
            ></label>
            <label
              htmlFor="star-rating-3"
              aria-label="3 stars"
              title="3 stars"
            ></label>
            <label
              htmlFor="star-rating-4"
              aria-label="4 stars"
              title="4 stars"
            ></label>
            <label
              htmlFor="star-rating-5"
              aria-label="5 stars"
              title="5 stars"
            ></label>
          </div>
        </div>
        <p>
          <input type="submit" value="Submit" />
        </p>
      </form>
    </main>
  )
}
