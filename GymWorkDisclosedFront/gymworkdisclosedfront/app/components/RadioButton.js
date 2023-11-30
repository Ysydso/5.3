const RadioButton = ({ label }) => {
    return (
        <div>
            <input type="radio" id="filter" name="filter" value={label} onChange={} checked />
            <label htmlFor="filter">{label}</label>
        </div>
    );
};
export default RadioButton;