import React from "react";
import PropTypes from "prop-types";

import Tabs from "@material-ui/core/Tabs";
import Tab from "@material-ui/core/Tab";
import Paper from "material-ui/Paper";
import { withStyles } from "material-ui/styles";

import TabContainer from "../../Commons/TabContainer";
import DetalizationOfSite from '../../../components/tables/DetalizationOfSite';
import TextFieldSelect from "../../Commons/TextFields/TextFieldSelect";
import { styles } from "./DetalizationOfBudgetPlan.css";
import { getSites } from '../helpersAPI';

const fieldNames = {
    selectedSite: {
        id: "selectedSite",
        label: "Выберите текущий сит"
    },
    tab: {
        id: "tab",
        label: ""
    }
};

class DetalizationOfBudgetPlan extends React.PureComponent {
    constructor(props) {
        super(props);
        this.state = {
            sits: [],
            [fieldNames.tab.id]: 0,
            [fieldNames.selectedSite.id]: 0
        };
    }

    static propTypes = {
        budgetPlanId: PropTypes.number.isRequired,
        classes: PropTypes.object.isRequired,
    };

    static getDerivedStateFromProps(nextProps) {
        return nextProps ? { selectedSite: 0 } : null;
    }

    setSites = (data) => {
        this.setState({
            sits: data
        })
    }
    //TODO: Create show error
    showError = () => {

    }

    componentDidMount() {
        getSites(this.setSites, this.showError);
    }

    handleChange = e => {
        const { name, value } = e.target;
        this.setState({ [name]: value });
    };
   
    handleTabChange = (event, value) => {
        this.setState({ [fieldNames.tab.id]: value });
    };

    render() {
        const { classes, budgetPlanId } = this.props;
        const { tab, selectedSite, sits } = this.state;
        const { tab: tabName, selectedSite: selectedSiteName } = fieldNames;

        return <Paper className={classes.root}>
            <TextFieldSelect
                muProps={{
                    name: selectedSiteName.id,
                    label: selectedSiteName.label,
                    value: selectedSite,
                    onChange: this.handleChange,
                    margin: "none"
                }}
                items={
                    sits &&
                    sits.map(elem => ({
                        value: elem.id,
                        text: elem.title
                    }))
                }
            />

            <hr style={{ marginTop: 0 }} />
            <Tabs
                value={tab}
                name={tabName.id}
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
                    {selectedSite !== 0 ? (
                        <DetalizationOfSite
                            siteId={selectedSite}
                            budgetPlanId={budgetPlanId}
                        />
                    ) : (
                            <span>
                                Выберите Сит для получения детализированной
                                информации
                            </span>
                        )}
                </TabContainer>
            )}
            {tab === 1 && <TabContainer>Сводка по плану сита</TabContainer>}
            {tab === 2 && <TabContainer>Сводка по всем ситам</TabContainer>}
            {tab === 3 && <TabContainer>Амортизация по ситу</TabContainer>}
            {tab === 4 && (
                <TabContainer>Амортизация по всем ситам</TabContainer>
            )}
            {tab === 5 && <TabContainer>Hyperion экспорт</TabContainer>}
            {tab === 6 && <TabContainer>Hyperion импорт</TabContainer>}
        </Paper>

    }
}

export default withStyles(styles)(DetalizationOfBudgetPlan);