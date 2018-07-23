import React from "react";
import Divider from "@material-ui/core/Divider";
import Search from "material-ui-icons/Search";
import Button from "@material-ui/core/Button";
import ExpansionPanel from "@material-ui/core/ExpansionPanel";
import ExpansionPanelSummary from "@material-ui/core/ExpansionPanelSummary";
import ExpansionPanelDetails from "@material-ui/core/ExpansionPanelDetails";
import ExpandMoreIcon from "@material-ui/icons/ExpandMore";
import Typography from "@material-ui/core/Typography";
import TextFieldSelect from "../Commons/TextFields/TextFieldSelect";
import TextFieldPlaceholder from "../Commons/TextFields/TextFieldPlaceholder";
import ExpansionPanelActions from "@material-ui/core/ExpansionPanelActions";
import { styles as classesForSearch } from "./DetalizationOfSite.css.js";
import monthsForSelect from '../../constants/monthsConstants';
import PropTypes from "prop-types";

class SearchDataForTable extends React.PureComponent {
    constructor(props) {
        super(props);
        this.state = {
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
        resultCentres: PropTypes.array,
        typesOfInvestment: PropTypes.array,
        categories: PropTypes.array,
        getTypesOfInvestment: PropTypes.func,
        getResultCentresSelect: PropTypes.func,
        getGroupsForSelect: PropTypes.func

    };

    componentDidMount() {
        const { getTypesOfInvestment, getGroupsForSelect, getResultCentresSelect } = this.props;
        getTypesOfInvestment();
        getGroupsForSelect();
        getResultCentresSelect();
    }
    //TODO: реализовать обраьотчики на кнопки Поиск, Очистка, Экспорт в Excel

    render() {
        const {
            classes,
            resultCentres,
            typesOfInvestment,
            categories
        } = this.props;
        const {
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
                    <div className={classesForSearch.column}>
                        <TextFieldSelect
                            name="selectedResultCenter"
                            value={selectedResultCenter}
                            label="Центр результатов"
                            items={
                                resultCentres &&
                                resultCentres.map(r => ({
                                    value: r.id,
                                    text: r.title
                                }))
                            }
                            onChange={this.handleChange}
                        />

                        <TextFieldSelect
                            name="selectedTypeOfInvestment"
                            value={selectedTypeOfInvestment}
                            label="Тип инвестиций"
                            items={
                                typesOfInvestment &&
                                typesOfInvestment.map(r => ({
                                    value: r.id,
                                    text: r.title
                                }))
                            }
                            onChange={this.handleChange}
                        />

                        <TextFieldSelect
                            name="selectedCategory"
                            value={selectedCategory}
                            label="Категория"
                            items={
                                categories &&
                                categories.map(r => ({
                                    value: r.id,
                                    text: r.title
                                }))
                            }
                            onChange={this.handleChange}
                        />
                    </div>
                    <div className={classesForSearch.column}>
                        <TextFieldPlaceholder
                            name="selectedSubjectOfInvestment"
                            value={selectedSubjectOfInvestment}
                            label="Предмет инвестиций"
                            type="text"
                            placeholder="Введите предмет инвестиции"
                            onChange={this.handleChange}
                            style={{ marginLeft: 0 }}
                        />

                        <TextFieldSelect
                            name="selectedDateFrom"
                            value={selectedDateFrom}
                            label="Планируемая дата инвестиций с"
                            items={monthsForSelect}
                            onChange={this.handleChange}
                        />

                        <TextFieldSelect
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
export default SearchDataForTable;
