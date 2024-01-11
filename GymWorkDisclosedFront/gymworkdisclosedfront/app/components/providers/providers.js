'use client';

import { NextUIProvider } from '@nextui-org/react';
import { QueryClient, QueryClientProvider } from 'react-query';
import AuthContext, { AuthContextProps } from '../firebase/firebase';

const queryClient = new QueryClient();

export function Providers({ children, authContext }) {
    return (
        <QueryClientProvider client={queryClient}>
            <NextUIProvider>
                <AuthContext.Provider value={authContext}>
                    {children}
                </AuthContext.Provider>
            </NextUIProvider>
        </QueryClientProvider>
    );
}
