import React, { useState } from 'react'
import { useQuery } from 'react-query'
import ReactMapGL, { Marker, NavigationControl, Popup } from 'react-map-gl'

import tacoTuesday from '../images/taco-tuesday.svg'
import { RestaurantType } from '../types'
import { SingleRestaurantFromList } from '../components/SingleRestaurantFromList'
import { Link } from 'react-router-dom'

export function Restaurants() {
  const [filterText, setFilterText] = useState('')

  // selectedMapRestaurant will either be `null` (meaning nothing selected)
  // ... or it will be the full details of the restaurant that is selected
  const [selectedMapRestaurant, setSelectedMapRestaurant] =
    useState<RestaurantType | null>(null)

  const [viewport, setViewport] = useState({
    latitude: 27.77101804911986,
    longitude: -82.66090611749074,
    zoom: 9.8,
  })

  const { data: restaurants = [] } = useQuery<RestaurantType[]>(
    ['restaurants', filterText],
    async function () {
      const response = await fetch(
        filterText.length === 0
          ? '/api/restaurants'
          : `/api/restaurants?filter=${filterText}`
      )

      // Do not await here... We want to return the promise
      return response.json()
    }
  )

  const MAPBOX_TOKEN = import.meta.env.VITE_APP_MAPBOX_TOKEN as string

  return (
    <main className="home">
      <h1>
        <img src={tacoTuesday} alt="Taco Tuesday" />
      </h1>
      <form className="search">
        <input
          type="text"
          placeholder="Search..."
          value={filterText}
          onChange={function (event) {
            setFilterText(event.target.value)
          }}
        />
      </form>

      <section className="map">
        <ReactMapGL
          {...viewport}
          style={{ position: 'absolute' }}
          width="100%"
          height="100%"
          mapboxApiAccessToken={MAPBOX_TOKEN}
          onViewportChange={setViewport}
        >
          <div style={{ position: 'absolute', left: 10 }}>
            <NavigationControl />
          </div>

          {selectedMapRestaurant ? (
            <Popup
              latitude={selectedMapRestaurant.latitude}
              longitude={selectedMapRestaurant.longitude}
              closeButton={true}
              closeOnClick={false}
              onClose={() => setSelectedMapRestaurant(null)}
              offsetTop={-5}
            >
              <div className="map-popup-restaurant">
                <p>
                  <Link to={`/restaurants/${selectedMapRestaurant.id}`}>
                    {selectedMapRestaurant.name}
                  </Link>
                </p>
                <p>{selectedMapRestaurant.description}</p>
              </div>
            </Popup>
          ) : null}

          {restaurants.map((restaurant) => (
            <Marker
              key={restaurant.id}
              latitude={restaurant.latitude}
              longitude={restaurant.longitude}
            >
              <i
                className="fa-2x fas fa-house-user"
                style={{ color: 'green' }}
                onClick={() => setSelectedMapRestaurant(restaurant)}
              />
            </Marker>
          ))}
        </ReactMapGL>
      </section>

      <ul className="results">
        {restaurants.map(function (restaurant) {
          return (
            <SingleRestaurantFromList
              key={restaurant.id}
              restaurant={restaurant}
              selectedOnMap={selectedMapRestaurant?.id === restaurant.id}
            />
          )
        })}
      </ul>
    </main>
  )
}
