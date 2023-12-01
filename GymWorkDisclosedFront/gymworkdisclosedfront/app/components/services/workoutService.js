export async function getPersonalBests(id) {
    const res = await fetch(`http://localhost:5206/api/Workout/${id}`,  {
        next: { revalidate: 0 } })
    const data = await res.json()
    return data
}