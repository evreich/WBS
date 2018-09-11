import PropTypes from "prop-types";

export default PropTypes.shape({
    accessToken: PropTypes.string,
    refreshToken: PropTypes.string,
    privateRoutes: PropTypes.arrayOf(PropTypes.string)
});