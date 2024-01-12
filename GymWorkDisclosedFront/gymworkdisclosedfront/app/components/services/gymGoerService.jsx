export async function getGymGoer(filter) {
    const res = await fetch(`http://localhost:5206/api/GymGoer/${filter.filter[2].guid}?filterproperty=${filter.filter[1]}&filtervalue=${filter.filter[0]}`,  {
        next: { revalidate: 10 } })
    const data = await res.json()
    return data
}