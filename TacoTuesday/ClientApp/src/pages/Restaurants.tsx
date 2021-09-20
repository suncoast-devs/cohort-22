import React from 'react'
import tacoTuesday from '../images/taco-tuesday.svg'
import map from '../images/map.png'
import { CSSStarsProperties } from '../types'

export function Restaurants() {
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
        <li>
          <h2>Loli&apos;s Mexican Cravings</h2>
          <p>
            <span
              className="stars"
              style={{ '--rating': 4.7 } as CSSStarsProperties}
              aria-label="Star rating of this location is 4.7 out of 5."
            ></span>
            (2,188)
          </p>
          <address>8005 Benjamin Rd, Tampa, FL 33634</address>
        </li>
        <li>
          <h2>La Hacienda Mexicana</h2>
          <p>
            <span
              className="stars"
              style={{ '--rating': 2.3 } as CSSStarsProperties}
              aria-label="Star rating of this location is 2.3 out of 5."
            ></span>
            (245)
          </p>
          <address>5537 Sheldon Rd, Tampa, FL 33615</address>
        </li>
      </ul>
    </main>
  )
}
