import React from 'react'
import { useQuery } from 'react-query'

import tacoTuesday from '../images/taco-tuesday.svg'
import map from '../images/map.png'
import { RestaurantType } from '../types'
import { SingleRestaurantFromList } from '../components/SingleRestaurantFromList'

export function Restaurants() {
  const { data: restaurants = [] } = useQuery<RestaurantType[]>(
    'restaurants',
    async function () {
      const response = await fetch('/api/restaurants')

      // Do not await here... We want to return the promise
      return response.json()
    }
  )

  return (
    <main className="home">
      <h1>
        <img src={tacoTuesday} alt="Taco Tuesday" />
      </h1>
      <form className="search">
        <input type="text" placeholder="Search..." />
      </form>

      <section className="map">
        <img alt="Example Map" src={map} />
      </section>

      <ul className="results">
        {restaurants.map(function (restaurant) {
          return (
            <SingleRestaurantFromList
              key={restaurant.id}
              restaurant={restaurant}
            />
          )
        })}
      </ul>
    </main>
  )
}
