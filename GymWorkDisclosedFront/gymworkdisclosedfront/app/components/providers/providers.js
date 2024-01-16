'use client';

import { NextUIProvider } from '@nextui-org/react';
import { QueryClient, QueryClientProvider } from 'react-query';
import AuthContext from '../firebase/firebase';
import PropTypes from 'prop-types';
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

Providers.propTypes = {
    children: PropTypes.node.isRequired,
    authContext: PropTypes.object.isRequired,
};
