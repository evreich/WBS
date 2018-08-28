import React from "react";
import PropTypes from "prop-types";

import TextFieldSelect from "components/Commons/TextFields/TextFieldSelect";
import TextFieldMultiline from "components/Commons/TextFields/TextFieldMultiline";
import Checkbox from "components/Commons/Checkbox/Checkbox";
import { getInvestmentRational } from "components/tables/helpersAPI";
import transformFieldsToState from 'helpers/transformFieldsToState';

class RationaleForInvestment extends React.PureComponent {
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

        getInvestmentRational(this.setInvestmentRational, this.showError);
    }

    getDataToSave = () => this.state;

    setInvestmentRational = data =>
        this.setState({
            investmentRational: data
        });

    showError = () => {};

    //handlers
    handleChange = e => {
        const { name, value } = e.target;
        this.setState({ [name]: value });
    };

    handleChangeCheckbox = name => event => {
        this.setState({ [name]: event.target.checked });
    };

    render() {
        const { classes, formFields } = this.props;
        const {
            rationaleForInvestmentId,
            investmentRational,
            approvalOfTechExpertIsRequired,
            commentForDirectorGeneral
        } = this.state;
        const {
            rationaleForInvestmentId: rationaleForInvestmentIdName,
            approvalOfTechExpertIsRequired: approvalOfTechExpertIsRequiredName,
            commentForDirectorGeneral: commentForDirectorGeneralName
        } = formFields;

        return (
            <div
                className={classes.flexRow}
                style={{
                    width: 1200,
                    justifyContent: "space-around"
                }}
            >
                <div className={classes.rationalForInvestFlexColumn}>
                    <div
                        style={{
                            width: 350,
                            marginTop: 20,
                            marginBottom: 20
                        }}
                    >
                        <TextFieldSelect
                            muProps={{
                                name: rationaleForInvestmentIdName.propName,
                                label: rationaleForInvestmentIdName.label,
                                value: rationaleForInvestmentId,
                                onChange: this.handleChange,
                                fullWidth: true
                            }}
                            items={
                                investmentRational &&
                                investmentRational.map(s => ({
                                    value: s.id,
                                    text: s.title
                                }))
                            }
                        />
                    </div>
                    <Checkbox
                        name={approvalOfTechExpertIsRequiredName.propname}
                        label={approvalOfTechExpertIsRequiredName.label}
                        defaultChecked={approvalOfTechExpertIsRequired}
                        checkboxStyle={{ height: 24 }}
                        onChange={this.handleChangeCheckbox(approvalOfTechExpertIsRequiredName.propname)}
                    />
                </div>
                <div
                    style={{
                        width: 500,
                        marginTop: 20,
                        marginBottom: 20
                    }}
                >
                    <TextFieldMultiline
                        muProps={{
                            name: commentForDirectorGeneralName.propName,
                            label: commentForDirectorGeneralName.label,
                            value: commentForDirectorGeneral,
                            onChange: this.handleChange,
                            rows: 4
                        }}
                    />
                </div>
            </div>
        );
    }
}

export default RationaleForInvestment;
