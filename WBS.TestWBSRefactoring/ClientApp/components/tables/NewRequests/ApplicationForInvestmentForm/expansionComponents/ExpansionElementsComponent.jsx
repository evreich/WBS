import React from "react";
import PropTypes from "prop-types";

import ExpansionPanel, {
    ExpansionPanelSummary,
    ExpansionPanelDetails
} from "material-ui/ExpansionPanel";
import ExpandMoreIcon from "material-ui-icons/ExpandMore";
import Typography from "material-ui/Typography";
import Grid from "material-ui/Grid";
import Button from "material-ui/Button";

import DatePicker from "components/Commons/DatePicker";
import TextFieldSelect from "components/Commons/TextFields/TextFieldSelect";
import TextFieldPlaceholder from "components/Commons/TextFields/TextFieldPlaceholder";
import TextFieldMultiline from "components/Commons/TextFields/TextFieldMultiline";
import InvestmentEfficiency from "./InvestmentEfficiency";
import transformFieldsToState from 'helpers/transformFieldsToState';

class ExpansionElementsComponent extends React.PureComponent {
    constructor(props) {
        super(props);
        this.fields = transformFieldsToState(Object.values(props.formFields));
        this.state = {
            rationaleForInvestmentId: 0,
            investmentRational: [],
            approvalOfTechExpertIsRequired: false,
            commentForDirectorGeneral: "",
            ...this.fields
        };
    }

    static propTypes = {
        classes: PropTypes.object,
        formFields: PropTypes.object,
        onRef: PropTypes.func
    };

    componentDidMount() {
        const onRef = this.props.onRef;
        onRef(this);
        //set investmentRational
    }

    getDataToSave =() => this.sate;

    //handlers
    handleChange = e => {
        const { name, value } = e.target;
        this.setState({ [name]: value });
    };

    handleChangeStateValue = (name, value) => {
        this.setState({ [name]: value });
    };

    handleDateChange = name => date => {
        this.setState({ [name]: date });
    };

    render() {
        const { classes, formFields } = this.props;
        const {
            rationaleForInvestmentId,
            reasonForDAI,
            investmentRational
        } = this.state;

        const { reasonForDAI: reasonForDAIName } = formFields;

        return (
            <>
                <ExpansionPanel>
                    <ExpansionPanelSummary
                        expandIcon={<ExpandMoreIcon />}
                        style={{
                            display: "flex",
                            justifyContent: "space-between"
                        }}
                    >
                        <Grid container={true}>
                            <Typography>
                                {(() => {
                                    if (rationaleForInvestmentId > 2)
                                        return investmentRational[
                                            rationaleForInvestmentId - 1
                                        ].title;
                                    else return "Эффективность инвестиций";
                                })()}
                            </Typography>
                        </Grid>
                        <Grid
                            container={true}
                            justify="flex-end"
                            full-width="true"
                        >
                            {rationaleForInvestmentId < 3 ? (
                                <Button
                                    variant="raised"
                                    color="primary"
                                    className={classes.btnSmall}
                                    onClick={event => {
                                        event.stopPropagation();
                                        this.efficiencyForm.calculationEfficiency();
                                    }}
                                >
                                    Рассчитать
                                </Button>
                            ) : (
                                ""
                            )}
                        </Grid>
                    </ExpansionPanelSummary>
                    <ExpansionPanelDetails>
                        <div
                            className={classes.flexRow}
                            style={{ justifyContent: "space-around" }}
                        >
                            {rationaleForInvestmentId <= 2 ? (
                                <InvestmentEfficiency
                                    onRef={ref => (this.efficiencyForm = ref)}
                                    rationaleForInvestmentId={
                                        rationaleForInvestmentId
                                    }
                                    handleChange={this.handleChange}
                                    handleChangeParentState={
                                        this.handleChangeStateValue
                                    }
                                    formFields={formFields}
                                />
                            ) : (
                                <TextFieldMultiline
                                    muProps={{
                                        name: reasonForDAIName.propName,
                                        label: reasonForDAIName.label,
                                        value: reasonForDAI,
                                        rows: 5,
                                        disabled: true,
                                        onChange: this.handleChange,
                                        fullWidth: true
                                    }}
                                />
                            )}
                        </div>
                    </ExpansionPanelDetails>
                </ExpansionPanel>
                <br />
                <ExpansionPanel>
                    <ExpansionPanelSummary expandIcon={<ExpandMoreIcon />}>
                        <Typography>Заполняет КУ сита</Typography>
                    </ExpansionPanelSummary>
                    <ExpansionPanelDetails>
                        <div
                            className={classes.flexRow}
                            style={{ justifyContent: "space-around" }}
                        >
                            <div style={{ width: 350, marginTop: 20 }}>
                                <TextFieldSelect
                                    muProps={{
                                        name: "",
                                        label: "Классификация инвестиций",
                                        value: "",
                                        disabled: true,
                                        onChange: this.handleChange
                                    }}
                                    items={[]}
                                />
                            </div>
                            <div style={{ width: 350, marginTop: 20 }}>
                                <TextFieldPlaceholder
                                    muProps={{
                                        name: "",
                                        label: "Тип факт",
                                        value: "",
                                        disabled: true,
                                        onChange: this.handleChange
                                    }}
                                />
                            </div>
                        </div>
                    </ExpansionPanelDetails>
                </ExpansionPanel>
                <br />
                <ExpansionPanel>
                    <ExpansionPanelSummary expandIcon={<ExpandMoreIcon />}>
                        <Typography>
                            Заполняет инициатор при закрытии заявки
                        </Typography>
                    </ExpansionPanelSummary>
                    <ExpansionPanelDetails>
                        <div
                            className={classes.flexRow}
                            style={{ justifyContent: "space-around" }}
                        >
                            <div style={{ width: 350, marginTop: 20 }}>
                                <TextFieldPlaceholder
                                    muProps={{
                                        name: "",
                                        label: "Внутренний инвентарный номер",
                                        value: "",
                                        disabled: true,
                                        onChange: this.handleChange
                                    }}
                                />
                            </div>
                            <DatePicker
                                name=""
                                label="Дата ввода основных средств в эксплуатацию"
                                value={null}
                                disabled={true}
                                items={[]}
                                style={{ width: 350 }}
                                onChange={this.handleDateChange("deliveryTime")}
                            />
                        </div>
                    </ExpansionPanelDetails>
                </ExpansionPanel>
                <br />
            </>
        );
    }
}

export default ExpansionElementsComponent;
