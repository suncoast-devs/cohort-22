import React from 'react'
import { CSSStarsProperties, RestaurantType } from '../types'

export function Stars({ restaurant }: { restaurant: RestaurantType }) {
  const totalStars = restaurant.reviews.reduce(
    (starRatingSum, review) => starRatingSum + review.stars,
    0
  )

  const averageStars =
    restaurant.reviews.length === 0 ? 0 : totalStars / restaurant.reviews.length

  const averageStarsToOneDecimalPlace = Number(averageStars.toFixed(1))

  return (
    <span
      className="stars"
      style={
        { '--rating': averageStarsToOneDecimalPlace } as CSSStarsProperties
      }
      aria-label={`Star rating of this location is ${averageStarsToOneDecimalPlace} out of 5.`}
    ></span>
  )
}
