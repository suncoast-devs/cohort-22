import React from 'react'
import { NewsArticle } from './components/NewsArticle'

export function App() {
  return (
    <div className="all-main-content">
      <main>
        <NewsArticle
          title="SDG Announces Hackathon!"
          body="SDG announces the 2020 Summer Hackathon. Join us for an exciting weekend"
        />
        <NewsArticle
          title="Student Graduation is Right Around the Corner"
          body="Our next cohort of students will be graduating in just over a week."
        />
        <NewsArticle
          title="SDG Standardizes on React"
          body="React is the best library for learning front end Web"
        />
        <NewsArticle
          title="Wow, so cool"
          body="This makes repeating code so easy!"
        />
      </main>
    </div>
  )
}
