import React from "react";
import PropTypes from "prop-types";

import { withStyles } from "@material-ui/core/styles";
import Tabs from "@material-ui/core/Tabs";
import Tab from "@material-ui/core/Tab";
import Paper from "@material-ui/core/Paper";

import SiteSelect from 'containers/textFields/selects/SiteSelect';
import { styles } from "./ComplexElements.css";
import TabContainer from "components/Commons/TabContainer";
import FilterForm from "../filterForms/BudgetLineFilterForm";
import BudgetLines from "containers/tables/budgetPlans/budgetLines";

const fieldNames = {
    tab: {
        propName: "tab",
        label: ""
    }
};

class SiteSelectAndDetalization extends React.Component{
    constructor(props) {
        super(props);
        this.state = {
            siteId: 10,
            [fieldNames.tab.propName]: 0
        }
    }

    onSiteChanged = e => {
        this.setState({
            siteId: e.target.value
        });
    }

    handleTabChange = (event, value) => {
        this.setState({ [fieldNames.tab.propName]: value });
    };

    render() {
        const { siteId, tab } = this.state;
        const budgetPlanId = this.props.budgetPlanId; 
        const { tab: tabName } = fieldNames;
        return (
            <Paper className={this.props.classes.BudgetPlanPosition} >

                <hr style={{ marginTop: 5 }} />
                    <SiteSelect value={siteId} label="Выберите сит" selectionChanged={this.onSiteChanged} />
                <hr style={{ marginTop: 0 }} />
                <Tabs
                    value={tab}
                    name={tabName.propName}
                    onChange={this.handleTabChange}
                    indicatorColor="primary"
                    textColor="secondary"
                    scrollable
                    scrollButtons="on"
                >
                    <Tab label="Детальный план сита" />
                    <Tab label="Сводка по плану сита" />
                    <Tab label="Сводка по всем ситам" />
                    <Tab label="Амортизация по ситу" />
                    <Tab label="Амортизация по всем ситам" />
                    <Tab label="Hyperion экспорт" />
                    <Tab label="Hyperion импорт" />
                </Tabs>
                <hr style={{ marginTop: 0 }} />
            {tab === 0 && (
                    <TabContainer>
                            <FilterForm />
                            {!!siteId && !!budgetPlanId && <div className={this.props.classes.BudgetLinePosition}><BudgetLines className={this.props.classes.BudgetLinePosition}/></div> }
                    </TabContainer>
            )}
            {tab === 1 && (
                <TabContainer>Сводка по плану сита</TabContainer>
            )}
            {tab === 2 && (
                <TabContainer>Сводка по всем ситам</TabContainer>
            )}
            {tab === 3 && (
                <TabContainer>Амортизация по ситу</TabContainer>
            )}
            {tab === 4 && (
                <TabContainer>Амортизация по всем ситам</TabContainer>
            )}
            {tab === 5 && <TabContainer>Hyperion экспорт</TabContainer>}
            {tab === 6 && <TabContainer>Hyperion импорт</TabContainer>}
        </Paper>);
    }
}

SiteSelectAndDetalization.propTypes = {
    classes: PropTypes.object.isRequired,
    budgetPlanId: PropTypes.number.isRequired
};

export default withStyles(() => ({ ...styles}))(SiteSelectAndDetalization);