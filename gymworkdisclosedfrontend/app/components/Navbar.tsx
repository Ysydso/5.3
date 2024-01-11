import React, {Dispatch, SetStateAction} from 'react'
import Link from 'next/link'
import Login from "../components/auth/Login";
import {AuthContextProps} from "./firebase/firebase";

// const LoggedInUser = () => {
//     useEffect(() => {
//         auth.onAuthStateChanged((user) => {
//             if (user) {
//                 console.log("user is logged in")
//                 return(
//                     <div>
//                         <button onClick={GoogleLogoutUser}> Logout </button>
//                     </div>
//                 )
//             } else {
//                 console.log("user is not logged in")
//                 return(
//                     <div>
//                         <button onClick={GoogleLoginUser}> Login </button>
//                     </div>
//                 )
//             }
//         })
//     }, [])
// }
const Navbar = ({setAuthContext}: { setAuthContext:  Dispatch<SetStateAction<AuthContextProps>> }) => {
    return(
        <nav>
            <h2>GymWorkDisclosed</h2>
            <Link href='/'> Home </Link>
            <Link href="/Workouts"> Workouts </Link>
            <Link href="/Workouts/PersonalBests"> Personal Bests </Link>
            <Login setAuthContext={setAuthContext}/>
        </nav>)
}
export default Navbar;

