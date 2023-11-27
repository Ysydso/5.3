export default function WorkoutFilters(gymgoer) {
       return <div>
              {gymgoer.workouts.map((workout) => (
                <Checkbox label={workout.exercise.name} />
              ))}
       </div>;
}