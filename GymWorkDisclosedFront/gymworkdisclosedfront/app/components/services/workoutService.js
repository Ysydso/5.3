import {auth} from "@/app/api/auth/auth";

export async function getPersonalBests(id) {
    
    
    const session = await auth()
    console.log("session", session)
    const res = await fetch(`http://localhost:5206/api/Workout/${id}`, {
        next: { revalidate: 10 },
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            authorization: `Bearer ${session.token}`
        }          
    })
    console.log("res", res)
    return <></>
}