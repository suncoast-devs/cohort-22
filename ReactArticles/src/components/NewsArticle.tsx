// Tells the editor AND `vite` that this file deals with React and JSX
import React from 'react'

// type Car = {
//   make: string
//   model: string
//   year: number
// }

type NewsArticleProps = {
  title: string
  body: string
}

// export -- is so we can use the outside of this file
export function NewsArticle(props: NewsArticleProps) {
  // must return JSX

  return (
    <article className="intro-article">
      <h2 className="article-title">{props.title}</h2>
      <p>{props.body}</p>
      <a className="read-more" href="#here">
        read more about {props.title}
      </a>
    </article>
  )
}
