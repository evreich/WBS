import React from "react";
import PropTypes from "prop-types";

import Tabs from "@material-ui/core/Tabs";
import Tab from "@material-ui/core/Tab";
import Paper from "@material-ui/core/Paper";
import { withStyles } from "@material-ui/core/styles";

import TabContainer from "components/Commons/TabContainer";
import DetalizationOfSite from "../../DetalizationOfSite";
import TextFieldSelect from "components/Commons/TextFields/TextFieldSelect";
import { styles } from "./DetalizationOfBudgetPlan.css";
import { getSites } from "../../helpersAPI";

const fieldNames = {
    selectedSite: {
        propName: "selectedSite",
        label: "Выберите текущий сит"
    },
    tab: {
        propName: "tab",
        label: ""
    }
};

//TODO: вынести в одтельный файл?
export const QueryParamsContext = React.createContext({
    budgetPlanId: 0,
    siteId: 0
});

export const DetalizationOfBudgetPlan = withStyles(styles)(
    class extends React.PureComponent {
        constructor(props) {
            super(props);
            this.state = {
                sits: [],
                [fieldNames.tab.propName]: 0,
                [fieldNames.selectedSite.propName]: 0
            };
        }

        static propTypes = {
            budgetPlanId: PropTypes.number.isRequired,
            classes: PropTypes.object.isRequired
        };

        setInitialValueSelectedSite = () => this.setState({ selectedSite: 0 });

        componentDidUpdate(prevProps) {
            if (this.props.budgetPlanId !== prevProps.budgetPlanId)
                this.setInitialValueSelectedSite();
        }

        setSites = data => {
            this.setState({
                sits: data
            });
        };
        //TODO: Create show error
        showError = () => {};

        componentDidMount() {
            getSites(this.setSites, this.showError);
        }

        handleChange = e => {
            const { name, value } = e.target;
            this.setState({ [name]: value });
        };

        handleTabChange = (event, value) => {
            this.setState({ [fieldNames.tab.propName]: value });
        };

        render() {
            const { classes, budgetPlanId } = this.props;
            const { tab, selectedSite, sits } = this.state;
            const { tab: tabName, selectedSite: selectedSiteName } = fieldNames;

            return (
                <Paper className={classes.root}>
                    <div className={classes.siteSelect}>
                        <TextFieldSelect
                            muProps={{
                                name: selectedSiteName.propName,
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
                    </div>
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
                            {selectedSite !== 0 ? (
                                <QueryParamsContext.Provider
                                    value={{
                                        siteId: selectedSite,
                                        budgetPlanId: budgetPlanId
                                    }}
                                >
                                    <DetalizationOfSite />
                                </QueryParamsContext.Provider>
                            ) : (
                                <span>
                                    Выберите Сит для получения детализированной
                                    информации
                                </span>
                            )}
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
                </Paper>
            );
        }
    }
);
