'use client';
import { getAuth, signInWithPopup, GoogleAuthProvider } from "firebase/auth";
import {Dispatch, SetStateAction, useContext} from "react";
import AuthContext, {AuthContextProps} from "../../components/firebase/firebase";
import {initializeApp} from "firebase/app";
import firebaseConfig from "@/app/components/firebase/firebase.Config";

const provider = new GoogleAuthProvider();

export default function Login({setAuthContext}: { setAuthContext:  Dispatch<SetStateAction<AuthContextProps>> }) {
    const auth = useContext(AuthContext);
    return (
        <main>
            {auth.token==null?<button onClick={async () => {
                const app = initializeApp(firebaseConfig);
                const auth = getAuth(app);

                try {
                    const result = await signInWithPopup(auth, provider);

                    const credential = GoogleAuthProvider.credentialFromResult(result);
                    const token: string = await result.user.getIdToken();

                    setAuthContext({
                        logout: () => {
                            setAuthContext({
                                logout: () => {

                                },
                                email: null,
                                token: null
                            })
                        },
                        email: result.user.email,
                        token: token
                    });
                } catch (e: any){
                    console.log("error", e)
                }
            }}
            >Login</button>:<button onClick={auth.logout}>Logout</button>}
        </main>
    )
}