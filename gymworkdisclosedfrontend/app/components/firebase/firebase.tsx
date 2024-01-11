'use client'

import {createContext} from 'react';

const AuthContext = createContext<AuthContextProps>({
    logout: () => {},
    email: null,
    token: null
});

export interface AuthContextProps {
    logout: () => void;
    email: string|null;
    token: string|null;
}

export default AuthContext;