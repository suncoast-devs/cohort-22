import React from 'react'
import { Link } from 'react-router-dom'
import { RestaurantType } from '../types'
import { Stars } from './Stars'

export function SingleRestaurantFromList(props: SingleRestaurantFromListProps) {
  return (
    <li style={{ backgroundColor: props.selectedOnMap ? 'green' : undefined }}>
      <h2>
        <Link to={`/restaurants/${props.restaurant.id}`}>
          {props.restaurant.name}
        </Link>
      </h2>
      <p>
        <Stars restaurant={props.restaurant} />(
        {props.restaurant.reviews.length})
      </p>
      <address>{props.restaurant.address}</address>
    </li>
  )
}
type SingleRestaurantFromListProps = {
  restaurant: RestaurantType
  selectedOnMap: boolean
}
