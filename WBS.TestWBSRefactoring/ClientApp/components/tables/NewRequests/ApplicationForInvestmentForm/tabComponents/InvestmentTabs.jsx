import React from "react";
import PropTypes from "prop-types";

import Tabs, { Tab } from "material-ui/Tabs";
import Paper from "material-ui/Paper";

import ChooseVendorModalForm from "./Providers/ChooseVendorModalForm";
import TextFieldSelect from "../../../../Commons/TextFields/TextFieldSelect";
import TabContainer from "../../../../Commons/TabContainer";
import OutBudget from "./OutBudget";
import Investment from "./Investment";
import Providers from "./Providers";
import Budget from "./Budget";

class InvestmentTabs extends React.PureComponent {
    constructor(props) {
        super(props);
        this.state = {
            isProvidersModalWindowOpen: false,
            providers: [],
            tab: 0
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

    //handlers
    handleChange = e => {
        const { name, value } = e.target;
        this.setState({ [name]: value });
    };

    handleChangeTab = (e, value) => {
        if (typeof e === "number") this.setState({ tab: e });
        else this.setState({ tab: value });
    };

    handleDeleteProviderButtonClick = id => {
        this.setState(prevState => ({
            providers: prevState.providers.filter(p => {
                p.id !== id;
            })
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
        this.setState({ providers: providers });
    };

    render() {
        const { classes } = this.props;
        const { tab, providers, isProvidersModalWindowOpen } = this.state;

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
                                    onChange: this.handleChange
                                }}
                                items={[
                                    { id: "1", text: "Новый" },
                                    { id: "2", text: "Замена" }
                                ]}
                            />
                        </div>
                        />
                        <Paper>
                            <OutBudget outBudgetData={{ sum: 1000 }} />
                        </Paper>
                    </TabContainer>
                )}
                {tab === 2 && (
                    <TabContainer>
                        <Paper>
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
                            {isProvidersModalWindowOpen && (
                                <ChooseVendorModalForm
                                    onAdd={this.handleAddProvider}
                                    onClose={this.handleCloseProvidersWindow}
                                    technicalServs={[]}
                                />
                            )}
                        </Paper>
                    </TabContainer>
                )}
            </div>
        );
    }
}

export default InvestmentTabs;
