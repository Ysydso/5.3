import { signInWithEmailAndPassword } from "firebase/auth"
import { getUser } from "../../app/components/services/userService"

Cypress.Commands.add('signInWithEmailAndPassword', (auth, email, password) => {
    return cy.wrap(signInWithEmailAndPassword(auth, email, password));
  });

Cypress.Commands.add('GetUser', (email, idToken) => {
  return cy.get(getUser(email, idToken))
  });