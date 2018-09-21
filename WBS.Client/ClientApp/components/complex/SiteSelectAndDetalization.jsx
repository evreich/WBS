import React from "react";
import PropTypes from "prop-types";

import { withStyles } from "@material-ui/core/styles";

import SiteSelect from 'containers/textFields/selects/SiteSelect';
import { styles } from "./ComplexElements.css";



class SiteSelectAndDetalization extends React.Component{
    constructor(props) {
        super(props);
        this.state = {
            budgetPlanId: 0,
            siteId: 0,
            isSiteComplex: true
        }
    }

    onSiteChanged = e => {
        this.setState({
            siteId: e.target.value
        });
    }

    render() {
        const { siteId, budgetPlanId } = this.state;
        return <div className={this.props.classes.BudgetPosition}>
            <SiteSelect className={this.props.classes.BudgetPosition} value={siteId} label="Выберите сит" selectionChanged={this.onSiteChanged} />
        { !!siteId && !!budgetPlanId && <h1>Budget plan detalization</h1> }
        </div>;
    }
}

SiteSelectAndDetalization.propTypes = {
    classes: PropTypes.object.isRequired
};

export default withStyles(() => ({ ...styles}))(SiteSelectAndDetalization);