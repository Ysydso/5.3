'use client';
import {useEffect, useState} from 'react';import {getExerciseByGymGoerId, getExercises} from "../../components/services/exerciseService";
import GymGoer from "../../(dashboard)/Workouts/WorkoutList";
import React from "react";
import Radio from '@mui/material/Radio';
import RadioGroup from '@mui/material/RadioGroup';
import FormControlLabel from '@mui/material/FormControlLabel';
import FormControl from '@mui/material/FormControl';
import FormHelperText from '@mui/material/FormHelperText';
import FormLabel from '@mui/material/FormLabel';
import Button from '@mui/material/Button';


export default function WorkoutFilters(Gymgoer){
    const [selectedRadioButton, setSelectedRadioButton] = useState('');
    const [error, setError] = React.useState(false);
    const [filterType, setFilterType] = useState('');
    const [Workouts, setWorkouts] = useState([]);
    const [Exercises, setExercises] = useState([]);
    const handleRadioChange = (event) => {
        setSelectedRadioButton(event.target.value);
        setFilterType(event.target.name)
        setError(false);
    };

    const handleButtonClick = async () => {
        setWorkouts(await GymGoer(filterType, selectedRadioButton))
    };

    useEffect(() => {
        const fetchExercises = async () => {
            const response = await getExerciseByGymGoerId(Gymgoer);
            setExercises(response);
            
        };
        fetchExercises();
    }, []);
    return (
        <div>
            <FormControl component="fieldset" error={error}>
                <FormLabel component="legend">Exercises</FormLabel>
                <RadioGroup
                    aria-label="Exercises"
                    defaultValue="top"
                    name="radio-buttons-group"
                >
                    {Exercises.map((exercise) => (
                        <FormControlLabel key={exercise.guid} value={exercise.name} control={<Radio/>}
                                          label={exercise.name} onChange={handleRadioChange}/>
                    ))}
                </RadioGroup>
                <FormHelperText>You can display workouts by exercise</FormHelperText>
            </FormControl>
            <FormControl component="fieldset" error={error}>
                <FormLabel component="legend">Muscle Groups</FormLabel>
                <RadioGroup
                    aria-label="Muscle Groups"
                    defaultValue="top"
                    name="radio-buttons-group"
                >
                    {Exercises.map((exercise) => (
                        <div key={exercise.guid}>
                            {exercise.muscleGroups.map((musclegroups) => (
                                <FormControlLabel key={musclegroups.guid} value={musclegroups.name} control={<Radio/>}
                                                  label={musclegroups.name} onChange={handleRadioChange}/>
                            ))}
                        </div>
                    ))}
                </RadioGroup>
                <FormHelperText>You can display workouts by muscle group</FormHelperText>
            </FormControl>
            <FormControl component="fieldset" error={error}>
                <FormLabel component="legend">Body Parts</FormLabel>
                <RadioGroup
                    aria-label="Body Parts"
                    defaultValue="top"
                    name="radio-buttons-group"
                >
                    {Exercises.map((exercise) => (
                        <div key={exercise.guid}>
                            {exercise.muscleGroups.map((musclegroups) => (
                                <div key={musclegroups.bodypart.guid}>
                                    <FormControlLabel key={musclegroups.bodypart.guid}
                                                      value={musclegroups.bodypart.name} control={<Radio/>}
                                                      label={musclegroups.bodypart.name} onChange={handleRadioChange}/>
                                </div>
                            ))}
                        </div>
                    ))}
                </RadioGroup>
                <FormHelperText>You can display workouts by body part</FormHelperText>
            </FormControl>
            <Button variant="contained" onClick={handleButtonClick}>Filter</Button>
            {Workouts}
        </div>
    )
}