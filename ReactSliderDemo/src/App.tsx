import React from 'react'

export function App() {
  return (
    <main>
      <section className="gauge">
        <figure>
          <i className="fas fa-circle-notch" />
          <span>78&deg;</span>
        </figure>
        <input type="range" min="50" max="120" value="78" />
      </section>
    </main>
  )
}
