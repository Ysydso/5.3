import { Inter } from 'next/font/google'
import './globals.css'
import { getServerSession} from "next-auth";
import Navbar from './components/Navbar'
import SessionProvider from "./components/SessionProvider"


const inter = Inter({ subsets: ['latin'] })

export const metadata = {
  title: 'GymWorkDisclosed',
  description: 'Created to track workouts',
}

export default async function RootLayout({children}) {
  const session = await getServerSession()
  return (
      <html lang="en">
        <body className={inter.className}>
          <SessionProvider session={session}>
              <main>
                  <Navbar/>
                  {children}
              </main>
          </SessionProvider>
        </body>
      </html>
  )
}
