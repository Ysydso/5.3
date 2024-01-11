import { getPersonalBests } from "@/app/components/services/workoutService";
import React from "react";
import { AuthContextProps } from "../firebase/firebase";

 
    export default async function PersonalBestList(auth: any, user: any) {
      const User = "875b0352-2ca1-4c7a-811e-433470cd7e56";
  
      const PersonalBests = (await getPersonalBests(auth, user));
  
      return (
        <div>
          {PersonalBests.exercises.map((personalbest: any) => (
            <div key={personalbest.guid}>
              <h1>Best {personalbest.name} workouts</h1>
              <h3>Best Time: {personalbest.bestTimeWorkout.timeInSeconds} seconds</h3>
              <h3>Most Weight: {personalbest.bestWeightWorkout.maxWeight}</h3>
              <h3>Total Reps: {personalbest.bestRepsWorkout.totalReps}</h3>
            </div>
          ))}
        </div>
      );
    }
  
      
    