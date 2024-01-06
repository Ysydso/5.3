import {
    GetServerSidePropsContext,
    NextApiRequest,
    NextApiResponse,
} from 'next'
import { NextAuthOptions, getServerSession } from 'next-auth'
import AzureADProvider from 'next-auth/providers/azure-ad'
import GoogleProvider from "next-auth/providers/google";
import {env} from "@/next.config";

const authOptions = {
    providers: [
        GoogleProvider ({
            clientId: env.GOOGLE_CLIENT_ID,
            clientSecret: env.GOOGLE_CLIENT_SECRET
        })
    ],
    session: {
        strategy: 'jwt',
        maxAge: 30 * 24 * 60 * 60, // 30 days
    },
    callbacks: {
        jwt: async ({ token, user, account }) => {
            if (account && account.access_token) {
                // set access_token to the token payload
                token.accessToken = account.access_token
            }

            return token
        },
        redirect: async ({ url, baseUrl }) => {
            return baseUrl
        },
        session: async ({ session, token, user }) => {
            // If we want to make the accessToken available in components, then we have to explicitly forward it here.
            return { ...session, token: token.accessToken }
        },
    },
    pages: {
        signIn: '/',
    },
    secret: env.NEXTAUTH_SECRET,
}

function auth(  // <-- use this function to access the jwt from React components
    ...args:
        | [GetServerSidePropsContext['req'], GetServerSidePropsContext['res']]
        | [NextApiRequest, NextApiResponse]
        | []
) {
    return getServerSession(...args, authOptions)
}

export { authOptions, auth }