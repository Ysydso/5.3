
import {useContext} from "react";
import AuthContext from "../../components/firebase/firebase";

export async function getPersonalBests(id) {
    const auth = useContext(AuthContext)
    console.log("token", auth)
    
    const res = await fetch(`http://localhost:5206/api/Workout/${id}`,  {
        next: { revalidate: 0 },
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${auth.token}`
        }})
    const data = await res.json()
    return data
}