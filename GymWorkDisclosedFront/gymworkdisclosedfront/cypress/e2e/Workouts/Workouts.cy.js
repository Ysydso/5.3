import { auth } from "../../../app/components/firebase/firebase.config"
const base_url = "http://localhost:3000/"

describe("Personal Bests Page", () => {
    it("should display the personal bests of the user", () => {
        cy.visit(base_url)
        cy.wait(5000)
        cy.signInWithEmailAndPassword(auth, 'test@test.com', 'testpassword')
        
        cy.wait(1000)

        cy.get("a").contains("Workouts").click()
        cy.get('.workoutDetails').invoke('attr', 'open', ' ')
        cy.get(".setDetails").invoke('attr', 'open', ' ')
        cy.get("div").children().each((workouts) => { 
            const WorkoutName = workouts.find("h1").text("Arm Curls workout")
            const timeInSeconds = workouts.find("h3").text("Total time: 500 seconds")

            cy.log(`${WorkoutName}: ${timeInSeconds}`)
            expect(WorkoutName).to.not.be.empty
            expect(timeInSeconds).to.not.be.empty
        })
    })
})