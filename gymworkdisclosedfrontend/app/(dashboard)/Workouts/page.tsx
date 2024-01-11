'use client';
import React from 'react'
import GymGoer from './WorkoutList'
import AuthContext from "@/app/components/firebase/firebase";


export default function Workouts() {
    const context = React.useContext(AuthContext);
    console.log("context", context)
  return (
    <main>
      <nav>
        <div>
          <h2>Workouts</h2>
          <p><small>Workouts from user</small></p>
           
        </div>
      </nav>
        <GymGoer filtertype={"bodypart"} filtervalue={"Arm"}/>
        
       
    </main>
  )
} 