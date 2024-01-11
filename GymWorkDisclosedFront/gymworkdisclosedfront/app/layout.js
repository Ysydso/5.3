"use client";
import { Inter } from 'next/font/google';
import './globals.css';

// components

import Navbar from './components/Navbar';
import { useState } from 'react';
import { AuthContextProps } from './components/firebase/firebase';
import {Providers} from "./components/providers/providers";


export default function RootLayout({ children }) {
    const [authContext, setAuthContext] = useState({
        logout: () => {},
        token: null,
    });

    return (
        <html lang="en" className="dark">
        <body>
        <Providers authContext={authContext}>
            <Navbar setAuthContext={setAuthContext} />
            {children}
        </Providers>
        </body>
        </html>
    );
}
