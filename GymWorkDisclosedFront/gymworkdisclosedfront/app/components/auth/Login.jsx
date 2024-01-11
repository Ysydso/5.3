'use client';
import {signInWithPopup, GoogleAuthProvider} from "firebase/auth";
import {auth} from "../firebase/firebase.Config";
// Initialize Firebase Auth provider
const provider = new GoogleAuthProvider();

// whenever a user interacts with the provider, we force them to select an account
provider.setCustomParameters({
    prompt : "select_account"
});

const Login = async () => {

    await signInWithPopup(auth, provider);
}

export default Login;