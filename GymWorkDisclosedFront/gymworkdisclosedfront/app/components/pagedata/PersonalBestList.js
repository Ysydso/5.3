import {getPersonalBests} from "@/app/components/services/workoutService";

export default async function PersonalBestList() {
    const User = "d8ce900c-3c6e-444e-8f2e-7726773d08fc"
    const PersonalBests = await getPersonalBests(User)
    return (
        <div>
            {PersonalBests.exercises.map(personalbest => (
                <div key={personalbest.id}>
                    <h1>Best {personalbest.name} workouts</h1>
                        <h3>Best Time: {personalbest.bestTimeWorkout.timeInSeconds} seconds</h3>
                        <h3>Most Weight: {personalbest.bestWeightWorkout.maxWeight}</h3>
                        <h3>Total Reps: {personalbest.bestRepsWorkout.totalReps}</h3>
                </div>
            ))}
        </div>
    )
}