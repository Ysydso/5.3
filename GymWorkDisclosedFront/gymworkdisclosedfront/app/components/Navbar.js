"use client";
import React from 'react'
import Link from 'next/link'
import { signIn, signOut, useSession } from 'next-auth/react'
import {usePathname} from "next/navigation";

export default function Navbar() {
    const { data: session, status } = useSession()
    
    if (session) {
        return(
        <nav>
                <h2>GymWorkDisclosed</h2>
                <Link href='/'> Home </Link>
                <Link href="/Workouts"> Workouts </Link>
                <Link href="/Workouts/PersonalBests"> Personal Bests </Link>
                {session.user.name}
                <button className="btn-primary" onClick={() => signOut()}>Sign Out</button>
        </nav>
        )
    }
    return (
        <nav>
            <h2>GymWorkDisclosed</h2>
            <Link href='/'> Home </Link>
            <Link href="/Workouts"> Workouts </Link>
            <Link href="/Workouts/PersonalBests"> Personal Bests </Link>
            <div>
                <button className="btn-primary" onClick={() => signIn()}>Sign In</button>
            </div>
            
        </nav>
    )
}
