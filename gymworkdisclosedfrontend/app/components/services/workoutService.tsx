import { useContext } from "react";
import AuthContext, { AuthContextProps } from "../../components/firebase/firebase";

export async function getPersonalBests(auth: any, user: any) {

  console.log("token", auth);
  console.log("user", user);

  const res = await fetch(`http://localhost:5206/api/Workout/${user.guid}`, {
    next: { revalidate: 0 },
    headers: {
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${auth.token}`
    }
  });
  const data = await res.json();
  return data;
}