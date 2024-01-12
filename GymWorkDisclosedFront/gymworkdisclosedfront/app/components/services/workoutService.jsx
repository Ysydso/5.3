export async function getPersonalBests(data) {
    try {
        console.log("data", data)
        console.log("data.user.guid", data.data.user)
        const res = await fetch(`http://localhost:5206/api/Workout/${data.data.user.guid}`,  {
            next: { revalidate: 0 },
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${data.data.token}`
            }})
        // Check the status of the response
        if (res.ok) {
            // Parse the response as JSON
            const workouts = await res.json()
            // Log the value of workouts
            console.log("workouts", workouts)
            return workouts
        } else {
            // Throw an error if the response is not ok
            throw new Error(`Fetch request failed: ${res.status}`)
        }
    } catch (error) {
        // Handle the error here
        console.error(error)
    }
}