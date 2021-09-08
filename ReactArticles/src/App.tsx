import React from 'react'
import { NewsArticle } from './components/NewsArticle'
import articles from './articles.json'
import logo from './images/banner.png'

export function App() {
  /* code here */

  // const yelling = words.map(word => word.toUpperCase())

  // console.log(logo)
  const newsArticlesFromData = articles.map((article) => (
    <NewsArticle key={article.id} title={article.title} body={article.body} />
  ))

  return (
    <div className="all-main-content">
      <img width={250} src={logo} alt="SDG" />
      <main>{newsArticlesFromData}</main>
    </div>
  )
}
