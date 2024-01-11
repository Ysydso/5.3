"use client";
import PersonalBestList from "../../../components/pagedata/PersonalBestList";
import {auth} from "../../../components/firebase/firebase.Config";
import {getUser} from "../../../components/services/userService";


export default function PersonalBests(){
    const email = auth.currentUser.email;
    const token = auth.currentUser.getIdToken();
    const user = getUser(email, token)

    const data = {userObj, token};
    console.log("user after retrieval", user);

    return (
        <main>
            <nav>
                <div>
                    <h2>Personal Bests</h2>
                    <p><small>Personal Bests from user</small></p>
                </div>
            </nav>
            <PersonalBestList data={data}/>
        </main>
    )
}

