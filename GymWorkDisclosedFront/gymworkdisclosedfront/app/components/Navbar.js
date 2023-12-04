import React from 'react'
import Link from 'next/link'

export default function Navbar() {
  return (
    <nav>
        <h2>GymWorkDisclosed</h2>
        <Link href='/'> Home </Link>
        <Link href="/Workouts"> Workouts </Link>
        <Link href="/Workouts/PersonalBests"> Personal Bests </Link>
    </nav>
    )
}
