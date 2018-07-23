import React from "react";
import PropTypes from "prop-types";
import Tabs from "@material-ui/core/Tabs";
import Tab from "@material-ui/core/Tab";
import Paper from "material-ui/Paper";
import TabContainer from "../Commons/TabContainer";
import DetalizationOfSite from "../../containers/DetalizationOfSite/DetalizationOfSite";
import TextFieldSelect from "../Commons/TextFields/TextFieldSelect";

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
            [fieldNames.tab.id]: 0,
            [fieldNames.selectedSite.id]: 0
        };
    }

    static propTypes = {
        budgetPlan: PropTypes.object.isRequired,
        classes: PropTypes.object.isRequired,
        getSitsForSelect: PropTypes.func.isRequired,
        sits: PropTypes.array
    };

    static getDerivedStateFromProps(nextProps) {
        return nextProps ? { selectedSite: 0 } : null;
    }

    componentDidMount() {
        const { getSitsForSelect } = this.props;
        getSitsForSelect();
    }

    handleChange = e => {
        const { name, value } = e.target;
        this.setState({ [name]: value });
    };

    render() {
        const { classes, sits, budgetPlan } = this.props;
        const { tab, selectedSite } = this.state;
        const { tab: tabName, selectedSite: selectedSiteName } = fieldNames;

        return !sits || sits.length === 0 ? (
            <div className={classes.root}>
                {/*TODO: сделать везде нормальную обработку загрузок */}
                Загрузка...
            </div>
        ) : (
            <Paper className={classes.root}>
                <div className={classes.container}>
                    <TextFieldSelect
                        muProps={{
                            name: selectedSiteName.id,
                            label: selectedSiteName.label,
                            value: selectedSite,
                            onChange: this.handleChange,
                            fullWidth: true,
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
                                budgetPlan={budgetPlan}
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
        );
    }
}

export default DetalizationOfBudgetPlan;