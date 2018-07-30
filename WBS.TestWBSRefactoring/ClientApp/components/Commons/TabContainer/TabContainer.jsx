import Typography from "@material-ui/core/Typography";
import React from "react";
import PropTypes from "prop-types";

const TabContainer = ({ children }) => (
    <Typography component="div" style={{ padding: 8 * 3 }}>
        {children}
    </Typography>
);

TabContainer.propTypes = {
    children: PropTypes.any
};

export default TabContainer;