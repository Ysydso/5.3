import React from 'react'
import GymGoer from './WorkoutList'

export default function Workouts() {
  return (
    <main>
      <nav>
        <div>
          <h2>Workouts</h2>
          <p><small>Workouts from user</small></p>
        </div>
      </nav>
        <GymGoer filtertype={"musclegroup"} filtervalue={"Chest"}/>
    </main>
  )
} 