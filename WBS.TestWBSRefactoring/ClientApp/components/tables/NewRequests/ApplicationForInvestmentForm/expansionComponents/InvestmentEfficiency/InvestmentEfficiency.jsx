import React, { Fragment } from "react";
import PropTypes from "prop-types";

import { InputAdornment } from "material-ui/Input";
import SentimentDissatisfiedIcon from "material-ui-icons/SentimentDissatisfied";
import SentimentSatisfiedIcon from "material-ui-icons/SentimentSatisfied";

import TextFieldPlaceholder from "../../../../../Commons/TextFields/TextFieldPlaceholder";
import { convertToDouble } from "../../../../../../helpers/formatHelper";
import {
    getDoh,
    getNVP,
    getPayback,
    getSmile
} from "../../../../../../helpers/efficiencyCalcHelper";

class InvestmentEfficiency extends React.PureComponent {
    constructor(props, context) {
        super(props, context);
        this.state = {
            paybackSmile: {}
        };
    }

    static propTypes = {
        handleChangeParentState: PropTypes.func,
        onRef: PropTypes.func,
        rationaleForInvestmentId: PropTypes.number,
        formFields: PropTypes.object
    };

    componentDidMount() {
        const { onRef } = this.props;
        onRef(this);
    }

    //handlers
    handleChange = e => {
        const { name, value } = e.target;
        this.setState({ [name]: value });
    };

    calculationEfficiency = () => {
        const {
            rationaleForInvestmentId: riId,
            handleChangeParentState
        } = this.props;

        const { totalInvestment,
            extraAnnualCost,
            estimatedOperationPeriod,
            additionalSalesPerYear,
            netMargin,
            savingsPerYear } = this.state;
        const discont = 15.5;

        const total = convertToDouble(totalInvestment);
        const additional = convertToDouble(extraAnnualCost);
        const period = convertToDouble(estimatedOperationPeriod);
        const year = convertToDouble(additionalSalesPerYear);
        const margin = convertToDouble(netMargin);
        const savings = convertToDouble(savingsPerYear);

        let marginAddedValue = "";
        if (riId === 1 && year !== 0 && margin !== 0) {
            marginAddedValue = ((year * margin) / 100).toString();
        }
        marginAddedValue = convertToDouble(marginAddedValue);

        const internalRateOfReturnVal = getDoh(
            total,
            additional,
            period,
            year,
            margin,
            marginAddedValue,
            savings
        ).toString();
        const netPresentValueVal = getNVP(
            total,
            additional,
            period,
            year,
            margin,
            marginAddedValue,
            savings,
            discont
        );
        const paybackVal = getPayback(
            total,
            additional,
            period,
            year,
            margin,
            marginAddedValue,
            savings,
            discont
        );
        getSmile(
            total,
            additional,
            period,
            year,
            margin,
            marginAddedValue,
            savings,
            discont
        )
            ? this.setState({
                  paybackSmile: {
                      endAdornment: (
                          <InputAdornment position="end">
                              <SentimentSatisfiedIcon
                                  style={{ color: "green" }}
                              />
                          </InputAdornment>
                      )
                  }
              })
            : this.setState({
                  paybackSmile: {
                      endAdornment: (
                          <InputAdornment position="end">
                              <SentimentDissatisfiedIcon
                                  style={{ color: "red" }}
                              />
                          </InputAdornment>
                      )
                  }
              });

        handleChangeParentState(
            "internalRateOfReturn",
            internalRateOfReturnVal
        );
        handleChangeParentState("netPresentValue", netPresentValueVal);
        handleChangeParentState("periodOfPayback", paybackVal);
        handleChangeParentState("marginOnAddedValue", marginAddedValue);
    };

    render() {
        const {
            rationaleForInvestmentId: riId,
            formFields: {
                totalInvestment: totalInvestmentName,
                estimatedOperationPeriod: estimatedOperationPeriodName,
                additionalSalesPerYear: additionalSalesPerYearName,
                savingsPerYear: savingsPerYearName,
                periodOfPayback: periodOfPaybackName,
                netMargin: netMarginName,
                internalRateOfReturn: internalRateOfReturnName,
                netPresentValue: netPresentValueName,
                marginOnAddedValue: marginOnAddedValueName,
                extraAnnualCost: extraAnnualCostName
            }
        } = this.props;
        
        const {
            paybackSmile,
            totalInvestment,
            estimatedOperationPeriod,
            additionalSalesPerYear,
            savingsPerYear,
            periodOfPayback,
            netMargin,
            internalRateOfReturn,
            netPresentValue,
            marginOnAddedValue,
            extraAnnualCost
        } = this.state;

        const style = {
            field: { width: 300, marginTop: 20 },
            column: { display: "flex", flexDirection: "column" }
        };
        return (
            <Fragment>
                <div style={style.column}>
                    <TextFieldPlaceholder
                        muProps={{
                            name: totalInvestmentName.propName,
                            label: totalInvestmentName.label,
                            value: totalInvestment,
                            type: "number",
                            onChange: this.handleChange,
                            disabled: true,
                            defaultValue: "0",
                            style: style.field
                        }}
                    />
                    <TextFieldPlaceholder
                        muProps={{
                            name: estimatedOperationPeriodName.propName,
                            label: estimatedOperationPeriodName.label,
                            value: estimatedOperationPeriod,
                            type: "number",
                            onChange: this.handleChange,
                            defaultValue: "0",
                            style: style.field
                        }}
                    />
                    {riId === 1 && (
                        <TextFieldPlaceholder
                            muProps={{
                                name: additionalSalesPerYearName.propName,
                                label: additionalSalesPerYearName.label,
                                value: additionalSalesPerYear,
                                type: "number",
                                onChange: this.handleChange,
                                style: style.field
                            }}
                        />
                    )}
                    {riId === 2 && (
                        <TextFieldPlaceholder
                            muProps={{
                                name: savingsPerYearName.propName,
                                label: savingsPerYearName.label,
                                value: savingsPerYear,
                                type: "number",
                                onChange: this.handleChange,
                                defaultValue: "0",
                                style: style.field
                            }}
                        />
                    )}
                </div>
                <div style={style.column}>
                    <TextFieldPlaceholder
                        muProps={{
                            name: marginOnAddedValueName.propName,
                            label: marginOnAddedValueName.label,
                            value: marginOnAddedValue,
                            type: "text",
                            onChange: this.handleChange,
                            disabled: true,
                            defaultValue: "0.00",
                            style: style.field
                        }}
                    />
                    <TextFieldPlaceholder
                        muProps={{
                            name: periodOfPaybackName.propName,
                            label: periodOfPaybackName.label,
                            value: periodOfPayback,
                            disabled: true,
                            onChange: this.handleChange,
                            style: style.field,
                            defaultValue: "??>0",
                            InputProps: paybackSmile
                        }}
                    />
                    <TextFieldPlaceholder
                        muProps={{
                            name: extraAnnualCostName.propName,
                            label: extraAnnualCostName.label,
                            value: extraAnnualCost,
                            type: "number",
                            onChange: this.handleChange,
                            defaultValue: "0.00",
                            style: style.field
                        }}
                    />
                </div>
                <div
                    style={{
                        width: 300,
                        ...style.column
                    }}
                >
                    {riId === 1 && (
                        <TextFieldPlaceholder
                            muProps={{
                                name: netMarginName.propName,
                                label: netMarginName.label,
                                value: netMargin,
                                type: "number",
                                onChange: this.handleChange,
                                defaultValue: "0",
                                style: style.field
                            }}
                        />
                    )}
                    <TextFieldPlaceholder
                        muProps={{
                            name: internalRateOfReturnName.propName,
                            label: internalRateOfReturnName.label,
                            value: internalRateOfReturn,
                            type: "number",
                            onChange: this.handleChange,
                            defaultValue: "0",
                            style: style.field,
                            disabled: true
                        }}
                    />
                    <TextFieldPlaceholder
                        muProps={{
                            name: netPresentValueName.propName,
                            label: netPresentValueName.label,
                            value: netPresentValue,
                            onChange: this.handleChange,
                            defaultValue: "0.00",
                            style: style.field,
                            disabled: true,
                            InputProps: {
                                endAdornment: (
                                    <InputAdornment position="end">
                                        15.5%
                                    </InputAdornment>
                                )
                            }
                        }}
                    />
                </div>
            </Fragment>
        );
    }
}

export default InvestmentEfficiency;
