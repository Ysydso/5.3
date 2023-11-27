import { getGymGoer } from '../../components/services/gymGoerService'
import WorkoutFilters from "@/app/components/filters/Workoutfilters";
import User from "@/app/components/User";
export default async function GymGoer(filtertype, filtervalue) {
    const User = "d8ce900c-3c6e-444e-8f2e-7726773d08fc"
    const gymgoer = await getGymGoer(User, filtertype, filtervalue)
    WorkoutFilters(gymgoer)
    console.log(filtertype)
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


