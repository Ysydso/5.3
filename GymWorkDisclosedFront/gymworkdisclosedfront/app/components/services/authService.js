import {useSession} from "next-auth/react";

export async function login(){
    const { data: session, status } = useSession()
    const res = await fetch(`http://localhost:5206/api/Gymgoer`,  {
        next: { revalidate: 10 } })
}