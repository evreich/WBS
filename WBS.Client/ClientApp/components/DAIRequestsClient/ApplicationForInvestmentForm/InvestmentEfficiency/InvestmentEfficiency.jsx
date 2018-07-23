import React, { Fragment } from 'react';
import PropTypes from 'prop-types';
import TextFieldPlaceholder from '../../../Commons/TextFields/TextFieldPlaceholder';
import { InputAdornment } from 'material-ui/Input';
import SentimentDissatisfiedIcon from 'material-ui-icons/SentimentDissatisfied';
import SentimentSatisfiedIcon from 'material-ui-icons/SentimentSatisfied';
import { convertToDouble } from '../../../../helpers/formatHelper';
import { getDoh, getNVP, getPayback, getSmile } from '../../../../helpers/efficiencyCalcHelper';

class InvestmentEfficiency extends React.Component {
    constructor(props, context) {
        super(props, context);
        this.state = {
            paybackSmile: {}
        };
    }

    componentDidMount() {
        const { onRef } = this.props;
        onRef(this);
    }

    calculationEfficiency = () => {
        const { rationaleForInvestmentId: riId,
            fields: { 
                totalInvestment,
                extraAnnualCost,
                estimatedOperationPeriod,
                additionalSalesPerYear,
                netMargin,
                savingsPerYear 
            },
            handleChangeParentState
        } = this.props;
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

        const internalRateOfReturnVal = getDoh(total, additional, period, year, margin, marginAddedValue, savings).toString();
        const netPresentValueVal = getNVP(total, additional, period, year, margin, marginAddedValue, savings, discont);
        const paybackVal = getPayback(total, additional, period, year, margin, marginAddedValue, savings, discont);
        getSmile(total, additional, period, year, margin, marginAddedValue, savings, discont)
            ? this.setState({
                paybackSmile: {
                    endAdornment: (
                        <InputAdornment position="end">
                            <SentimentSatisfiedIcon style={{ color: 'green' }} />
                        </InputAdornment>
                    )
                }
            })
            : this.setState({
                paybackSmile: {
                    endAdornment: (
                        <InputAdornment position="end">
                            <SentimentDissatisfiedIcon style={{ color: 'red' }} />
                        </InputAdornment>
                    )
                }
            });

        handleChangeParentState("internalRateOfReturn", internalRateOfReturnVal);
        handleChangeParentState("netPresentValue", netPresentValueVal);
        handleChangeParentState("periodOfPayback", paybackVal);
        handleChangeParentState("marginOnAddedValue", marginAddedValue);
    }

    render() {
        const {
            rationaleForInvestmentId: riId,
            handleChange,
            fields: {
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
            }
        } = this.props;
        const { paybackSmile } = this.state;
        return (
            <Fragment>
                <div style={{ display: 'flex', flexDirection: 'column' }}>

                    <TextFieldPlaceholder name="totalInvestment" label="Всего инвестиций" type="number" disabled={true} value={totalInvestment} defaultValue="0" style={{ width: 300, marginTop: 20 }} onChange={handleChange} />
                    <TextFieldPlaceholder name="estimatedOperationPeriod" label="Предположительный срок эксплуатации" type="number" value={estimatedOperationPeriod} defaultValue="0" style={{ width: 300, marginTop: 20 }} onChange={handleChange} />
                    {riId === 1 &&
                        <TextFieldPlaceholder
                            name="additionalSalesPerYear"
                            label="Дополнительные продажи за год"
                            type="number"
                            value={additionalSalesPerYear}
                            style={{ width: 300, marginTop: 20 }}
                            onChange={handleChange}
                        />}
                    {riId === 2 &&
                        <TextFieldPlaceholder
                            name="savingsPerYear"
                            label="Экономия средств в год"
                            type="number" defaultValue="0"
                            value={savingsPerYear}
                            style={{ width: 300, marginTop: 20 }}
                            onChange={handleChange}
                        />
                    }
                </div>
                <div style={{ display: 'flex', flexDirection: 'column' }}>
                    <TextFieldPlaceholder name="marginOnAddedValue" label="Маржа на добавочную стоимость" defaultValue="0,00" type="text" value={marginOnAddedValue} disabled={true} style={{ width: 300, marginTop: 20 }} onChange={handleChange} />
                    <TextFieldPlaceholder name="periodOfPayback"
                        label="Срок окупаемости"
                        defaultValue="??>0"
                        value={periodOfPayback}
                        disabled={true}
                        style={{ width: 300, marginTop: 20 }}
                        InputProps={paybackSmile}
                        onChange={handleChange}
                    />
                    <TextFieldPlaceholder name="extraAnnualCost" label="Дополнительные ежегодные затраты" type="number" value={extraAnnualCost} defaultValue="0,00" style={{ width: 300, marginTop: 20 }} onChange={handleChange} />
                </div>
                <div style={{ width: 300, display: 'flex', flexDirection: 'column' }}>
                    {riId === 1 &&
                        <TextFieldPlaceholder
                            name="netMargin"
                            label="Чистая маржа %"
                            type="number"
                            defaultValue="0"
                            value={netMargin}
                            style={{ width: 300, marginTop: 20 }}
                            onChange={handleChange}
                        />}
                    <TextFieldPlaceholder
                        name="internalRateOfReturn"
                        label="Внутренняя ставка доходности"
                        disabled={true}
                        defaultValue="0"
                        value={internalRateOfReturn}
                        style={{ width: 300, marginTop: 20 }}
                        onChange={handleChange}
                    />
                    <TextFieldPlaceholder name="netPresentValue"
                        label="Чистая приведенная стоимость"
                        disabled={true}
                        defaultValue="0,00"
                        value={netPresentValue}
                        style={{ width: 300, marginTop: 20 }}
                        InputProps={{
                            endAdornment: (
                                <InputAdornment position="end">15.5%</InputAdornment>
                            )
                        }}
                        onChange={handleChange}
                    />
                </div>

            </Fragment>
        );
    }
}


InvestmentEfficiency.propTypes = {
    handleChange: PropTypes.func,
    handleChangeParentState: PropTypes.func,
    onRef: PropTypes.func,
    totalInvestment: PropTypes.string,
    estimatedOperationPeriod: PropTypes.string,
    additionalSalesPerYear: PropTypes.string,
    periodOfPayback: PropTypes.string,
    marginOnAddedValue: PropTypes.string,
    extraAnnualCost: PropTypes.string,
    netMargin: PropTypes.string,
    internalRateOfReturn: PropTypes.string,
    netPresentValue: PropTypes.string,
    savingsPerYear: PropTypes.string,
    rationaleForInvestmentId: PropTypes.number,
    fields: PropTypes.object
}


export default InvestmentEfficiency;