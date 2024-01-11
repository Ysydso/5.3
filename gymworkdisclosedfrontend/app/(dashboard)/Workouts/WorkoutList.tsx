import React, { FC } from 'react';
import { getGymGoer } from '../../components/services/gymGoerService';

interface GymGoerProps {
    filtertype: string;
    filtervalue: string;
}

const GymGoer: FC<GymGoerProps> = async ({ filtertype, filtervalue }) => {
    const User: string = "875b0352-2ca1-4c7a-811e-433470cd7e56";
    const gymgoer = await getGymGoer(User, filtertype, filtervalue);
    return (
        <div>
            {/*<Filterbar gymgoer={gymgoer} />*/}
            {gymgoer.workouts.map((workout: any) => (
                <div key={workout.id}>
                    <h1>{workout.exercise.name} workout</h1>
                    <details>
                        <h3>Total time: {workout.time} seconds</h3>
                        <h3>Date of workout: {workout.date}</h3>
                        {workout.sets.map((set: any, index: number) => (
                            <div key={set.id}>
                                <h1>Set {index + 1}</h1>
                                <details>
                                    <h4>Reps: {set.reps}</h4>
                                    <h4>Weight: {set.weight}</h4>
                                    <h4>Time: {set.timeInSeconds} seconds</h4>
                                </details>
                            </div>
                        ))}
                    </details>
                </div>
            ))}
        </div>
    );
};

export default GymGoer;

