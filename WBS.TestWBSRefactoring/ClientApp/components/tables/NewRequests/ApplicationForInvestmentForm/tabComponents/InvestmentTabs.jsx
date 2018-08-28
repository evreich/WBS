import React from "react";
import PropTypes from "prop-types";

import Tabs, { Tab } from "material-ui/Tabs";
import Paper from "material-ui/Paper";

import ChooseItemModalWindow from "components/Commons/ModalWindows/ChooseItemModalWindow";
import TextFieldSelect from "components/Commons/TextFields/TextFieldSelect";
import TabContainer from "components/Commons/TabContainer";
import OutBudget from "./OutBudget";
import Investment from "./Investment";
import Providers from "./Providers";
import Budget from "./Budget";
import ProvidersTable from "./Providers/ProvidersTable";
import Filters from "./Providers/Filters";
import QueryParamsContext from "./Providers/QueryParamsContext";

const defaultFilters = {
    title: ""
}

class InvestmentTabs extends React.PureComponent {
    constructor(props) {
        super(props);
        this.state = {
            isProvidersModalWindowOpen: false,
            providers: [],
            tab: 0,
            filters: defaultFilters,
            searchingString: ""
        };
    }

    static propTypes = {
        classes: PropTypes.object,
        onRef: PropTypes.func
    };

    componentDidMount() {
        const onRef = this.props.onRef;
        //связываем с родительским компонентом,
        //чтобы он имел доступ к методам дочернего компонента
        onRef(this);
    }

    getDataToSave = () => this.state;

    //handlers
    handleChange = e => {
        const { name, value } = e.target;
        this.setState({ [name]: value });
    };

    handleChangeTab = (e, value) => {
        if (typeof e === "number")
            this.setState({ tab: e });
        else
            this.setState({ tab: value });
    };

    handleDeleteProviderButtonClick = id => {
        this.setState(prevState => ({
            providers: prevState.providers.filter(p => p.id !== id)
        }));
    };

    handleOpenProvidersWindow = () => {
        this.setState({ isProvidersModalWindowOpen: true });
    };

    handleCloseProvidersWindow = () => {
        this.setState({ isProvidersModalWindowOpen: false });
    };

    handleAddProvider = provider => {
        const { providers } = this.state;
        if (providers.map(p => p.id).indexOf(provider.id) === -1)
            providers.push(provider);
        this.setState({
            providers: providers,
            isProvidersModalWindowOpen: false,
            searchingString: ""
        });
    };

    render() {
        const { classes } = this.props;
        const { tab, providers, isProvidersModalWindowOpen, searchingString, filters } = this.state;

        const getFilteredDataTable = (newFilters) => {
            this.setState({ filters: newFilters });
        };

        const getDataTable = () => {
            this.setState({ filters: defaultFilters });
        };


        return (
            <div className={classes.tabs}>
                <Paper>
                    <Tabs
                        value={tab}
                        onChange={this.handleChangeTab}
                        indicatorColor="primary"
                        textColor="secondary"
                        centered
                    >
                        <Tab label="Бюджет" />
                        <Tab label="Вне бюджета" />
                        <Tab label="Инвестиции" />
                        <Tab label="Поставщик" />
                    </Tabs>
                </Paper>
                {tab === 0 && (
                    <TabContainer>
                        <Paper>
                            <Budget
                                budgetData={{
                                    rowBudget: {
                                        sum: 11,
                                        rest: 22,
                                        dai: 33
                                    },
                                    totalSit: {
                                        sum: 11,
                                        rest: 22,
                                        dai: 33
                                    }
                                }}
                            />
                        </Paper>
                    </TabContainer>
                )}
                {tab === 1 && (
                    <TabContainer>
                        <div style={{ width: 150, marginBottom: 5 }}>
                            <TextFieldSelect
                                muProps={{
                                    name: "",
                                    label: "Вне бюджета",
                                    value: "",
                                    onChange: (() => { })
                                }}
                                items={[
                                    { id: "1", text: "Новый", key: "1" },
                                    { id: "2", text: "Замена", key: "2" }
                                ]}
                            />
                        </div>
                        <Paper>
                            <OutBudget outBudgetData={{ sum: 1000 }} />
                        </Paper>
                    </TabContainer>
                )}
                {tab === 2 && (
                    <TabContainer>
                        <Paper style={{ overflowX: 'auto' }} >
                            <Investment />
                        </Paper>
                    </TabContainer>
                )}
                {tab === 3 && (
                    <TabContainer>
                        <Paper>
                            <Providers
                                providers={providers}
                                onDelete={this.handleDeleteProviderButtonClick}
                                onAddNew={this.handleOpenProvidersWindow}
                            />
                            <ChooseItemModalWindow
                                open={isProvidersModalWindowOpen}
                                onAdd={this.handleAddProvider}
                                cancel={this.handleCloseProvidersWindow}
                                technicalServs={[]}
                                header={"Выбор поставщиков"}
                            >
                                <>
                                    <Filters
                                        technicalServs={[]}
                                        applyFilter={getFilteredDataTable}
                                        reset={getDataTable}
                                        searchingString={searchingString}
                            />
                                    <QueryParamsContext.Provider
                                        value={{
                                            queryParams: filters,
                                            add: this.handleAddProvider,
                                            showToolbar: false
                                        }}
                                    >
                                        <ProvidersTable classes={classes} />
                                    </QueryParamsContext.Provider>
                                </>
                            </ChooseItemModalWindow>
                        </Paper>
                    </TabContainer>
                )}
            </div>
        );
    }
}

export default InvestmentTabs;
