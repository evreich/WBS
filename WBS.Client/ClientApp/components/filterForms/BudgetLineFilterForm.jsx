import React from "react";
//import PropTypes from "prop-types";

import { Field, reduxForm } from 'redux-form';
import Divider from "@material-ui/core/Divider";
import Search from "@material-ui/icons/Search";
import Button from "@material-ui/core/Button";
import ExpansionPanel from "@material-ui/core/ExpansionPanel";
import ExpansionPanelSummary from "@material-ui/core/ExpansionPanelSummary";
import ExpansionPanelDetails from "@material-ui/core/ExpansionPanelDetails";
import ExpandMoreIcon from "@material-ui/icons/ExpandMore";
import Typography from "@material-ui/core/Typography";
import ExpansionPanelActions from "@material-ui/core/ExpansionPanelActions";
import Grid from '@material-ui/core/Grid';

import ResultCenterSelect from '../../containers/textfields/selects/ResultCenterSelect';
import TypeOfInvestmentSelect from '../../containers/textfields/selects/TypeOfInvestmentSelect';
import CategoryGroupSelect from '../../containers/textfields/selects/CategoryGroupSelect';
import TextFieldPlaceholder from '../commons/textfields/TextFieldPlaceholder/TextFieldPlaceholder';
import MonthSelect from '../../containers/textfields/selects/MonthSelect';

const lessThan = otherField => (value, previousValue, allValues) => (value <= allValues[otherField] ? value : previousValue);
const greaterThan = otherField => (value, previousValue, allValues) => (value >= allValues[otherField] ? value : previousValue);

class BudgetLineFilterForm extends React.Component {
    render() {
        return <ExpansionPanel>
            <ExpansionPanelSummary expandIcon={<ExpandMoreIcon />}>
                <Typography>
                    Поиск строк бюджетного плана
                </Typography>
            </ExpansionPanelSummary>
            <ExpansionPanelDetails style={{ justifyContent: 'space-between' }}>
                <form style={{ width: "100%" }}>
                    <Grid container spacing={24}>
                        <Grid item xs={12} sm={6}>
                            <Grid container direction="column" alignItems="center" justify="center">
                                <Field
                                    component={ResultCenterSelect}
                                    name="resultCenter"
                                    label="Центр результата"
                                />
                                <Field
                                    component={TypeOfInvestmentSelect}
                                    name="typeOfInvestment"
                                    label="Тип инвестиций"
                                />
                                <Field
                                    component={CategoryGroupSelect}
                                    name="categoryGroup"
                                    label="Категория"
                                />
                            </Grid>
                        </Grid>
                        <Grid item xs={12} sm={6}>
                            <Grid container direction="column" alignItems="center" justify="center">
                                <Field
                                    component={TextFieldPlaceholder}
                                    name="investmentType"
                                    label="Предмет инвестиций"
                                />
                                <Typography variant="caption">
                                    Планируемая дата
                                </ Typography>
                                <Grid container direction="row">
                                    <Field
                                        component={MonthSelect}
                                        name="monthFrom"
                                        label="С"
                                        defaultValue={1}
                                        normalize={lessThan('monthTo')}
                                    />
                                    <Field
                                        component={MonthSelect}
                                        name="monthTo"
                                        label="По"
                                        defaultValue={12}
                                        normalize={greaterThan('monthFrom')}
                                    />
                                </Grid>
                            </Grid>
                        </Grid>
                    </Grid>
                </form>
            </ExpansionPanelDetails>
            <br />
            <Divider />
            <ExpansionPanelActions>
                <Button
                    //onClick={this.cancel}
                    color="primary"
                    variant="contained"
                >
                    <Search />Поиск
                    </Button>
                <Button
                    //onClick={this.cancel}
                    color="primary"
                    variant="contained"
                >
                    Очистить фильтр
                    </Button>
                <Button
                    //onClick={this.cancel}
                    color="primary"
                    variant="contained"
                >
                    Экспорт в Excel
                    </Button>
            </ExpansionPanelActions>
        </ExpansionPanel>;
    }
}

export default reduxForm({
    form: "BudgetLineFilterForm",
    initialValues: {
        monthFrom: "1",
        monthTo: "12"
    }
})(BudgetLineFilterForm)