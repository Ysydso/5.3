export async function getGymGoer(id, filter) {
    const res = await fetch(`http://localhost:5206/api/GymGoer/${id}?filterproperty=${filter.filtertype}&filtervalue=${filter.filtervalue}`,  {
        next: { revalidate: 10 } })
    return await res.json()
}