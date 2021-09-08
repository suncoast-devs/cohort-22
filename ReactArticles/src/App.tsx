import React from 'react'
import { NewsArticle } from './components/NewsArticle'
import articles from './articles.json'

export function App() {
  /* code here */

  // const yelling = words.map(word => word.toUpperCase())

  const newsArticlesFromData = articles.map((article) => (
    <NewsArticle key={article.id} title={article.title} body={article.body} />
  ))

  return (
    <div className="all-main-content">
      <main>{newsArticlesFromData}</main>
    </div>
  )
}
