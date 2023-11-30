import { getGymGoer } from '../../components/services/gymGoerService'
import {getExerciseByGymGoerId} from "@/app/components/services/exerciseService";
export default async function GymGoer(filtertype, filtervalue) {
    const User = "82e1b165-7baf-49c2-868f-7e45b2750d19"
    const gymgoer = await getGymGoer(User, filtertype, filtervalue)
    console.log(gymgoer)
    return (
        <div>
            {/*<Filterbar gymgoer={gymgoer} />*/}
            {gymgoer.workouts.map(workout => (
                <div key={workout.id}>
                    <h1>{workout.exercise.name} workout</h1>
                    <details>
                        <h3>Total time: {workout.time} seconds</h3>
                        <h3>Date of workout: {workout.date}</h3>
                        {workout.sets.map((set, index) => (
                            <div key={set.id}>
                                <h1>Set {index + 1}</h1>
                                <details>
                                    <h4>Reps: {set.reps}</h4>
                                    <h4>Weight: {set.weight}</h4>
                                    <h4>Time: {set.timeInSeconds} seconds</h4>
                                </details>
                            </div>
                        ))}
                    </details>
                </div>
            ))}
        </div>
    )
}


