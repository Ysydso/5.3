"use client";
import { Inter } from 'next/font/google';
import './globals.css';

// components

import Navbar from './components/Navbar';
import { useState } from 'react';
import { AuthContextProps } from './components/firebase/firebase';
import {Providers} from ".//providers";


export default function RootLayout({children}: { children: React.ReactNode }) {
    const [authContext, setAuthContext] = useState<AuthContextProps>({
        logout: () => {
        },
        email: null,
        token: null
    });

    return (
        <html lang="en">
        <body>
        <Providers authContext={authContext}>
            <Navbar setAuthContext={setAuthContext} />
            {children}
        </Providers>
        </body>
        </html>
    );
}
