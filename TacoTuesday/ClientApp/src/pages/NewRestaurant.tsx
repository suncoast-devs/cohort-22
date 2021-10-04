import React, { useState } from 'react'
import { useMutation } from 'react-query'
import { useHistory } from 'react-router'
import { Link } from 'react-router-dom'
import { useDropzone } from 'react-dropzone'

import { authHeader } from '../auth'
import { APIError, RestaurantType } from '../types'

async function submitNewRestaurant(restaurantToCreate: RestaurantType) {
  const response = await fetch('/api/Restaurants', {
    method: 'POST',
    headers: {
      'content-type': 'application/json',
      Authorization: authHeader(),
    },
    body: JSON.stringify(restaurantToCreate),
  })

  if (response.ok) {
    return response.json()
  } else {
    throw await response.json()
  }
}

export function NewRestaurant() {
  const history = useHistory()
  const [newRestaurant, setNewRestaurant] = useState<RestaurantType>({
    id: undefined,
    name: '',
    description: '',
    address: '',
    telephone: '',
    photoURL: '',
    reviews: [],
  })
  const [errorMessage, setErrorMessage] = useState('')
  const [isUploading, setIsUploading] = useState(false)

  const createNewRestaurant = useMutation(submitNewRestaurant, {
    onSuccess: function () {
      // This happens if we successfully update the restaurant
      history.push('/')
    },
    onError: function (apiError: APIError) {
      const newMessage = Object.values(apiError.errors).join(' ')

      setErrorMessage(newMessage)
    },
  })

  function handleStringFieldChange(
    event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) {
    const value = event.target.value
    const fieldName = event.target.name

    const updatedRestaurant = { ...newRestaurant, [fieldName]: value }

    setNewRestaurant(updatedRestaurant)
  }

  async function uploadFile(fileToUpload: File) {
    // Create a formData object so we can send this
    // to the API that is expecting some form data.
    const formData = new FormData()

    // Append a field that is the form upload itself
    formData.append('file', fileToUpload)

    // Use fetch to send an authorization header and
    // a body containing the form data with the file
    const response = await fetch('/api/Uploads', {
      method: 'POST',
      headers: {
        Authorization: authHeader(),
      },
      body: formData,
    })

    if (response.ok) {
      return response.json()
    } else {
      throw 'Unable to upload image!'
    }
  }

  function onDropFile(acceptedFiles: File[]) {
    // Do something with the files
    const fileToUpload = acceptedFiles[0]
    console.log(fileToUpload)

    setIsUploading(true)

    uploadFileMutation.mutate(fileToUpload)
  }

  const { getRootProps, getInputProps, isDragActive } = useDropzone({
    onDrop: onDropFile,
  })

  const uploadFileMutation = useMutation(uploadFile, {
    onSuccess: function (apiResponse: UploadResponse) {
      const url = apiResponse.url

      setNewRestaurant({ ...newRestaurant, photoURL: url })
    },

    onError: function (error: string) {
      setErrorMessage(error)
    },

    onSettled: function () {
      setIsUploading(false)
    },
  })

  let dropZoneMessage = 'Drag a picture of the restaurant here to upload!'

  if (isUploading) {
    dropZoneMessage = 'Uploading...'
  }

  if (isDragActive) {
    dropZoneMessage = 'Drop the files here ...'
  }

  return (
    <main className="page">
      <nav>
        <Link to="/">
          <i className="fa fa-home"></i>
        </Link>
        <h2>Add a Restaurant</h2>
      </nav>
      <form
        onSubmit={(event) => {
          event.preventDefault()
          createNewRestaurant.mutate(newRestaurant)
        }}
      >
        {errorMessage ? <p className="form-error">{errorMessage}</p> : null}
        <p className="form-input">
          <label htmlFor="name">Name</label>
          <input
            type="text"
            name="name"
            value={newRestaurant.name}
            onChange={handleStringFieldChange}
          />
        </p>
        <p className="form-input">
          <label htmlFor="description">Description</label>
          <textarea
            name="description"
            value={newRestaurant.description}
            onChange={handleStringFieldChange}
          ></textarea>
          <span className="note">
            Enter a brief description of the restaurant.
          </span>
        </p>
        <p className="form-input">
          <label htmlFor="name">Address</label>
          <textarea
            name="address"
            value={newRestaurant.address}
            onChange={handleStringFieldChange}
          ></textarea>
        </p>
        <p className="form-input">
          <label htmlFor="name">Telephone</label>
          <input
            type="tel"
            name="telephone"
            value={newRestaurant.telephone}
            onChange={handleStringFieldChange}
          />
        </p>

        {newRestaurant.photoURL ? (
          <p>
            <img
              alt="Restaurant Photo"
              width={200}
              src={newRestaurant.photoURL}
            />
          </p>
        ) : null}

        <p className="form-input">
          <div className="file-drop-zone">
            <div {...getRootProps()}>
              <input {...getInputProps()} />
              {dropZoneMessage}
            </div>
          </div>
        </p>
        <p>
          <input type="submit" value="Submit" />
        </p>
      </form>
    </main>
  )
}
