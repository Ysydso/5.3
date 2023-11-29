export async function getExercises() {
    const res = await fetch(`http://localhost:5206/api/Exercise`)
    const data = await res.json()
    return data
}
export async function getExerciseByGymGoerId(id) {
    const res = await fetch(`http://localhost:5206//api/Exercise/GetExercisesByGymGoer/${id}`)
    const data = await res.json()
    return data
}