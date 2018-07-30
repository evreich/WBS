import React from "react";
import PropTypes from "prop-types";

import Divider from "@material-ui/core/Divider";
import Search from "material-ui-icons/Search";
import Button from "@material-ui/core/Button";
import ExpansionPanel from "@material-ui/core/ExpansionPanel";
import ExpansionPanelSummary from "@material-ui/core/ExpansionPanelSummary";
import ExpansionPanelDetails from "@material-ui/core/ExpansionPanelDetails";
import ExpandMoreIcon from "@material-ui/icons/ExpandMore";
import Typography from "@material-ui/core/Typography";
import ExpansionPanelActions from "@material-ui/core/ExpansionPanelActions";
import { withStyles } from "material-ui/styles";

import TextFieldSelect from "../../Commons/TextFields/TextFieldSelect";
import TextFieldPlaceholder from "../../Commons/TextFields/TextFieldPlaceholder";
import monthsForSelect from '../../../constants/monthsConstants';
import { styles } from "../../Commons/Table/TableStyles.css";
import { getResultCentres, getTypesOfInvestment, getGroupCategories } from '../helpersAPI';

class SearchDataForTable extends React.PureComponent {
    constructor(props) {
        super(props);
        this.state = {
            resultCentres: [],
            typesOfInvestment: [],
            categoryGroups: [],
            selectedResultCenter: 0,
            selectedTypeOfInvestment: 0,
            selectedCategory: 0,
            selectedSubjectOfInvestment: "",
            selectedDateFrom: 0,
            selectedDateTo: 0
        };
    }
    static propTypes = {
        classes: PropTypes.object.isRequired,
    };

    componentDidMount() {
        getTypesOfInvestment();
        getResultCentres();
        getGroupCategories();
    }
    //TODO: реализовать обраьотчики на кнопки Поиск, Очистка, Экспорт в Excel
    setCategoryGroups = (data) => {
        this.setState({
            categoryGroups: data
        });
    }

    setResultCentres = (data) => {
        this.setState({
            resultCentres: data
        });
    }

    setTypesOfInvestment = (data) => {
        this.setState({
            typesOfInvestment: data
        });
    }

    showError = () => {

    }
 
    render() {
        const {
            classes
        } = this.props;
        const {
            resultCentres,
            typesOfInvestment,
            categoryGroups,
            selectedResultCenter,
            selectedTypeOfInvestment,
            selectedCategory,
            selectedSubjectOfInvestment,
            selectedDateFrom,
            selectedDateTo
        } = this.state;
        return (
            <ExpansionPanel>
                <ExpansionPanelSummary expandIcon={<ExpandMoreIcon />}>
                    <Typography className={classes.heading}>
                        Поиск строк бюджетного плана
                    </Typography>
                </ExpansionPanelSummary>
                <ExpansionPanelDetails>
                    <div style={{flexBasis: '50%'}}>
                        <TextFieldSelect
                        muProps={{
                            name: "selectedResultCenter",
                            value: selectedResultCenter,
                            label: "Центр результатов",
                            onChange: this.handleChange
                        }}
                        items={
                            resultCentres &&
                            resultCentres.map(r => ({
                                value: r.id,
                                text: r.title
                            }))
                        }
                        />

                        <TextFieldSelect
                            muProps={{
                                name: "selectedTypeOfInvestment",
                                value: selectedTypeOfInvestment,
                                label: "Тип инвестиций",
                                onChange: this.handleChange
                            }}
                            items={
                                typesOfInvestment &&
                                typesOfInvestment.map(r => ({
                                    value: r.id,
                                    text: r.title
                                }))
                            }
                        />

                        <TextFieldSelect
                            muProps={{
                                name: "selectedCategory",
                                value: selectedCategory,
                                label: "Категория",
                                onChange: this.handleChange
                            }}
                            items={
                                categoryGroups &&
                                categoryGroups.map(r => ({
                                    value: r.id,
                                    text: r.title
                                }))
                            }
                        />
                    </div>
                    <div style={{flexBasis: '50%'}}>
                        <TextFieldPlaceholder
                            muProps={{
                                name: "selectedCategory",
                                value: selectedCategory,
                                label: "Категория",
                                onChange: this.handleChange
                            }}
                            name="selectedSubjectOfInvestment"
                            value={selectedSubjectOfInvestment}
                            label="Предмет инвестиций"
                            type="text"
                            placeholder="Введите предмет инвестиции"
                            onChange={this.handleChange}
                            style={{ marginLeft: 0 }}
                        />

                        <TextFieldSelect
                            muProps={{
                                name: "selectedCategory",
                                value: selectedCategory,
                                label: "Категория",
                                onChange: this.handleChange
                            }}
                            name="selectedDateFrom"
                            value={selectedDateFrom}
                            label="Планируемая дата инвестиций с"
                            items={monthsForSelect}
                            onChange={this.handleChange}
                        />

                        <TextFieldSelect
                            muProps={{
                                name: "selectedCategory",
                                value: selectedCategory,
                                label: "Категория",
                                onChange: this.handleChange
                            }}
                            name="selectedDateTo"
                            value={selectedDateTo}
                            label="Планируемая дата инвестиций по"
                            items={monthsForSelect}
                            onChange={this.handleChange}
                            style={{ marginRight: "10px" }}
                        />
                    </div>
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
            </ExpansionPanel>
        );
    }
}
export default withStyles(styles)(SearchDataForTable);