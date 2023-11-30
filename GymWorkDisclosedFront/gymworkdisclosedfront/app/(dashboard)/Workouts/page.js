import React from 'react'
import GymGoer from './WorkoutList'
import WorkoutFilters from "@/app/components/filters/Workoutfilters";


export default function Workouts() {
  return (
    <main>
      <nav>
        <div>
          <h2>Workouts</h2>
          <p><small>Workouts from user</small></p>
           
        </div>
      </nav>
      <WorkoutFilters gymgoer={"82e1b165-7baf-49c2-868f-7e45b2750d19"}/>
        <GymGoer filtertype={"bodypart"} filtervalue={"Front"}/>
       
    </main>
  )
} 