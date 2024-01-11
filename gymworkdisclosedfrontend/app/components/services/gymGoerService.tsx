export async function getGymGoer(id: string, filtertype: string, filtervalue: string): Promise<any> {
    const res = await fetch(`http://localhost:5206/api/GymGoer/${id}?filterproperty=${filtertype}&filtervalue=${filtervalue}`,  {
        next: { revalidate: 10 } })
    const data = await res.json()
    return data
}

