import React from 'react'
import { Link } from 'react-router-dom'
import { CSSStarsProperties, RestaurantType } from '../types'

export function SingleRestaurantFromList(props: SingleRestaurantFromListProps) {
  return (
    <li>
      <h2>
        <Link to={`/restaurants/${props.restaurant.id}`}>
          {props.restaurant.name}
        </Link>
      </h2>
      <p>
        <span
          className="stars"
          style={{ '--rating': 4.7 } as CSSStarsProperties}
          aria-label="Star rating of this location is 4.7 out of 5."
        ></span>
        (2,188)
      </p>
      <address>{props.restaurant.address}</address>
    </li>
  )
}
type SingleRestaurantFromListProps = {
  restaurant: RestaurantType
}
