import { CSSProperties } from 'react'

export interface CSSStarsProperties extends CSSProperties {
  '--rating': number
}

export type RestaurantType = {
  id: number | undefined
  name: string
  description: string
  address: string
  telephone: string
}
