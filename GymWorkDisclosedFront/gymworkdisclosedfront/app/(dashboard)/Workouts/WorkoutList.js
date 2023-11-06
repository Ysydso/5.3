async function getGymGoer(id) {
    const res = await fetch(`http://localhost:5206/api/GymGoer/${id}`)
    const data = await res.json()
    return data
}

export default async function GymGoer(){
    const gymgoer = await getGymGoer("82e1b165-7baf-49c2-868f-7e45b2750d19")
    return(
        
        <div>
            {gymgoer.workouts.map(workout => {
                console.log(workout)
                return (
                    <>
                        <p key={workout.id}>
                            <h1>{workout.exercise.name} workout</h1>
                            <details>
                                <h3>Total time: {workout.time} seconds</h3>
                                <h3>Date of workout: {workout.date}</h3>
                                {workout.sets.map((set, index) => (
                                    <p key={set.id}>
                                        Set {index + 1} <details>
                                        <h4>Reps: {set.reps}</h4>
                                        <h4>Weight: {set.weight}</h4>
                                        <h4>Time: {set.time} seconds</h4>
                                    </details>
                                    </p>
                                ))}
                            </details>
                            
                        </p>
                    </>
                )
                })
            }
        </div>
    )
}


