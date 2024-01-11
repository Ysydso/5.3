'use client';
import PersonalBestList from "../../../components/pagedata/PersonalBestList";
import AuthContext from "@/app/components/firebase/firebase";
import { useContext } from "react";
import getUser from "@/app/components/services/userService";
import { useQuery } from "react-query";

export default function PersonalBests(){
    const auth = useContext(AuthContext)
    console.log("auth after usecontext", auth)
    const query = useQuery(["profile", auth.token], async () => {
        const response = await getUser(auth)
        console.log("email", auth.email)
        return response.json();
    })
    return (
        <main>
            <nav>
                <div>
                    <h2>Personal Bests</h2>
                    <p><small>Personal Bests from user</small></p>
                </div>
            </nav>
            <PersonalBestList auth={auth} user={query.data}/>
        </main>
    )
}