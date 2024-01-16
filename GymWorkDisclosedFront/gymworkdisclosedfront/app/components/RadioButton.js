import PropTypes from 'prop-types';
const RadioButton = ({ label }) => {
    return (
        <div>
            <input type="radio" id="filter" name="filter" value={label} onChange={} checked />
            <label htmlFor="filter">{label}</label>
        </div>
    );
};

RadioButton.propTypes = {
    label: PropTypes.string.isRequired,
};

export default RadioButton;