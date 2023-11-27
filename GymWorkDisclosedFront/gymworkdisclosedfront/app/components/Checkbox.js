const Checkbox = ({ label }) => {
    return (
        <div className="checkbox">
            <label>
                <input type="checkbox" />
                <span>{label}</span>
            </label>
        </div>
    );
};
export default Checkbox;