import { Inter } from 'next/font/google'
import './globals.css'

// components

import Navbar from './components/Navbar'


const inter = Inter({ subsets: ['latin'] })

export const metadata = {
    title: 'GymWorkDisclosed',
    description: 'Created to track workouts',
}

export default function RootLayout({ children }) {
    return (
        <html lang="en">
        <body className={inter.className}>
        <Navbar />
        {children}</body>
        </html>
    )
}
RootLayout.propTypes = {
    children: PropTypes.node.isRequired,
}
