export async function getGymGoer(id) {
    const res = await fetch(`http://localhost:5206/api/GymGoer/${id}`)
    const data = await res.json()
    return data
}