import { auth } from "../../../app/components/firebase/firebase.config"
const base_url = "http://localhost:3000/"

describe("Personal Bests Page", () => {
  it("should display the personal bests of the user", () => {
    cy.visit(base_url)
    cy.wait(5000)
    cy.signInWithEmailAndPassword(auth, 'test@test.com', 'testpassword')
    
    cy.wait(1000)

    cy.get("a").contains("Personal Bests").click()
    cy.get("div").children().each((personalBest) => {

      const exerciseName = personalBest.find("h1").text("Best Arm Curls workouts")
      const bestTime = personalBest.find("h3").eq(0).text("Best Time: 300 seconds")
      const mostWeight = personalBest.find("h3").eq(1).text("Most Weight: 30")
      const totalReps = personalBest.find("h3").eq(2).text("Total Reps: 10")

      cy.log(`${exerciseName}: ${bestTime}, ${mostWeight}, ${totalReps}`)

      expect(exerciseName).to.not.be.empty
      expect(bestTime).to.not.be.empty
      expect(mostWeight).to.not.be.empty
      expect(totalReps).to.not.be.empty
    })
  })
})