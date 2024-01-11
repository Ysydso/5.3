"use client";
import { initializeApp } from "firebase/app";
import { getAuth, signInWithPopup, GoogleAuthProvider } from "firebase/auth";
import {useContext} from "react";
import AuthContext from "../../components/firebase/firebase";
import firebaseConfig from "../../components/firebase/firebase.Config";

const provider = new GoogleAuthProvider();

export default function Login({setAuthContext}) {
    const app = initializeApp(firebaseConfig)
    const auth = getAuth(app);
    return (
        <main>
            {auth.token==null?<button onClick={async () => {

                try {
                    const result = await signInWithPopup(auth, provider);

                    const credential = GoogleAuthProvider.credentialFromResult(result);
                    const token = await result.user.getIdToken();

                    setAuthContext({
                        logout: () => {
                            setAuthContext({
                                logout: () => {

                                },
                                token: null
                            })
                        },
                        token: token
                    });
                } catch (any){

                }
            }}
            >Login</button>:<button onClick={auth.logout}>Logout</button>}
        </main>
    )
}