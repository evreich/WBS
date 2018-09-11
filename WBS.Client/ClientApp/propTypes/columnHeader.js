import PropTypes from "prop-types";
import TypesOfColumnData from "constants/typesOfColumnData";

export default PropTypes.shape({
    propName: PropTypes.string,
    type: PropTypes.oneOf(Object.values(TypesOfColumnData)),
    label: PropTypes.string
});