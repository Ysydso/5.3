import PersonalBestList from "../../../components/pagedata/PersonalBestList";

export default async function PersonalBests(){
    return (
        <main>
            <nav>
                <div>
                    <h2>Personal Bests</h2>
                    <p><small>Personal Bests from user</small></p>
                </div>
            </nav>
            <PersonalBestList/>
        </main>
    )
}