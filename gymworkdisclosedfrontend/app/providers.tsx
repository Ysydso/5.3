'use client';

import { NextUIProvider } from '@nextui-org/react';
import { QueryClient, QueryClientProvider } from 'react-query';
import AuthContext, { AuthContextProps } from '@/app/components/firebase/firebase';

const queryClient = new QueryClient()

export function Providers({children, authContext}: { children: React.ReactNode, authContext: AuthContextProps }) {
    return (
        <QueryClientProvider client={queryClient}>
            <NextUIProvider>
                <AuthContext.Provider value={authContext}>
                    {children}
                </AuthContext.Provider>
            </NextUIProvider>
        </QueryClientProvider>
    )
}