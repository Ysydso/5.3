"use client";
import {getAuth, signOut} from "firebase/auth";

export default function Logout() {
    return(
        <main>
            <button onClick={ async () => {
                const auth = getAuth();
                await signOut(auth)
                console.log("logout")}}>
                
                Logout
            </button>
        </main>
    )
}

