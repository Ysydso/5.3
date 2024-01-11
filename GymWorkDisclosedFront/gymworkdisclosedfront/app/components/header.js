import {useEffect, useState} from "react";
import {useRouter} from "next/router";

function useUserSession(initialUser) {
    // The initialUser comes from the server through a server component
    const [user, setUser] = useState(initialUser);
    const router = useRouter();

    useEffect(() => {
        const unsubscribe = onAuthStateChanged(authUser => {
            setUser(authUser);
        });
        return () => {
            unsubscribe();
        };
    }, []);

    useEffect(() => {
        onAuthStateChanged(authUser => {
            if (user === undefined) return;
            if (user?.email !== authUser?.email) {
                router.refresh();
            }
        });
    }, [user]);

    return user;
}
