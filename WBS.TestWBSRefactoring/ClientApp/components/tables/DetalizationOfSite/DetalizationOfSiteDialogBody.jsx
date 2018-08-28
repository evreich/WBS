import React from "react";
import PropTypes from "prop-types";

import TextFieldSelect from "../../Commons/TextFields/TextFieldSelect";
import TextFieldPlaceholder from "../../Commons/TextFields/TextFieldPlaceholder";
import { QueryParamsContext } from "../BudgetPlans/DetalizationOfBudgetPlan/DetalizationOfBudgetPlan";
import transformFieldsToState from "../../../helpers/transformFieldsToState";
import {
    getResultCentres,
    getTypesOfInvestment,
    getCategoriesOfEquip
} from "../helpersAPI";

const budgetPlanPropName = "budgetPlanId";
const sitePropName = "siteId";

class DetalizationOfSiteDialogBody extends React.PureComponent {
    constructor(props) {
        super(props);
        const fields = transformFieldsToState(Object.values(props.formFields));

        this.state = {
            id: 0,
            [budgetPlanPropName]: 0,
            [sitePropName]: 0,
            resultCentres: [],
            typesOfInvestment: [],
            categoryGroups: [],
            ...fields
        };
    }

    static propTypes = {
        errors: PropTypes.object,
        data: PropTypes.object,
        onRef: PropTypes.func,
        formFields: PropTypes.object
    };

    //lifecycles
    static getDerivedStateFromProps(nextProps) {
        return nextProps && nextProps.data ? { ...nextProps.data } : null;
    }

    componentDidMount() {
        const onRef = this.props.onRef;
        //связываем с родительским компонентом,
        //чтобы он имел доступ к методам дочернего компонента
        onRef(this);
        getTypesOfInvestment(this.setTypesOfInvestment, this.showError);
        getCategoriesOfEquip(this.setCategoryGroups, this.showError);
        getResultCentres(this.setResultCentres, this.showError);
    }

    setCategoryGroups = data => {
        this.setState({
            categoryGroups: data
        });
    };

    setResultCentres = data => {
        this.setState({
            resultCentres: data
        });
    };

    setTypesOfInvestment = data => {
        this.setState({
            typesOfInvestment: data
        });
    };

    showError = () => {};

    getDataToSave = () => {
        const amount = this.props.formFields.amount;
        const {
            id,
            resultCenter,
            typeOfInvestment,
            categoryOfEquipment,
            resultCenterId,
            typeOfInvestmentId,
            categoryOfEquipmentId,
            subjectOfInvestment,
            dateOfDelivery,
            count,
            price,
            budgetPlanId,
            siteId
        } = this.state;

        return {
            id,
            budgetPlanId,
            siteId,
            resultCenter,
            typeOfInvestment,
            categoryOfEquipment,
            resultCenterId,
            typeOfInvestmentId,
            categoryOfEquipmentId,
            subjectOfInvestment,
            dateOfDelivery,
            count,
            price,
            [amount.propName]: count * price
        };
    };

    //handlers
    handleChange = (e, ...args) => {
        const { name, value } = e.target;
        const otherArgs = args.length > 0 ? args.reduce((obj, item) => ({ ...obj, ...item })) : {};

        this.setState({
            [name]: value,
            ...otherArgs
        });
    };

    render() {
        const { errors, formFields } = this.props;
        const {
            resultCentres,
            typesOfInvestment,
            categoryGroups,
            resultCenterId,
            typeOfInvestmentId,
            categoryOfEquipmentId,
            subjectOfInvestment,
            dateOfDelivery,
            count,
            price
        } = this.state;
        const {
            resultCenterId: resultCenterName,
            resultCenter: resultCenterTitleName,
            typeOfInvestmentId: typeOfInvestmentName,
            typeOfInvestment: typeOfInvestmentTitleName,
            categoryOfEquipmentId: categoryName,
            categoryOfEquipment: categoryTitleName,
            subjectOfInvestment: subjectOfInvestmentName,
            dateOfDelivery: dateOfDeliveryName,
            count: countName,
            price: priceName
        } = formFields;

        return (
            <>
                <QueryParamsContext.Consumer>
                    {({ budgetPlanId, siteId }) =>
                        this.setState({
                            [budgetPlanPropName]: budgetPlanId,
                            [sitePropName]: siteId
                        })
                    }
                </QueryParamsContext.Consumer>

                <TextFieldSelect
                    muProps={{
                        name: resultCenterName.propName,
                        label: resultCenterName.label,
                        value: resultCenterId,
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
                    textPropName={resultCenterTitleName.propName}
                    items={
                        resultCentres &&
                        resultCentres.map(elem => ({
                            value: elem.id,
                            text: elem.title
                        }))
                    }
                />
                <TextFieldSelect
                    muProps={{
                        name: typeOfInvestmentName.propName,
                        label: typeOfInvestmentName.label,
                        value: typeOfInvestmentId,
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
                    textPropName={typeOfInvestmentTitleName.propName}
                    items={
                        typesOfInvestment &&
                        typesOfInvestment.map(elem => ({
                            value: elem.id,
                            text: elem.title
                        }))
                    }
                />
                <TextFieldSelect
                    muProps={{
                        name: categoryName.propName,
                        label: categoryName.label,
                        value: categoryOfEquipmentId,
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
                    textPropName={categoryTitleName.propName}
                    items={
                        categoryGroups &&
                        categoryGroups.map(elem => ({
                            value: elem.id,
                            text: elem.title
                        }))
                    }
                />
                <TextFieldPlaceholder
                    muProps={{
                        name: subjectOfInvestmentName.propName,
                        label: subjectOfInvestmentName.label,
                        value: subjectOfInvestment,
                        type: "text",
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
                />
                <TextFieldPlaceholder
                    muProps={{
                        name: dateOfDeliveryName.propName,
                        label: dateOfDeliveryName.label,
                        value: dateOfDelivery,
                        type: "date",
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
                />
                <TextFieldPlaceholder
                    muProps={{
                        name: countName.propName,
                        label: countName.label,
                        value: count,
                        type: "number",
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
                />
                <TextFieldPlaceholder
                    muProps={{
                        name: priceName.propName,
                        label: priceName.label,
                        value: price,
                        type: "number",
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
                />

                {/*TODO: VALIDATION */}
                {errors && <span style={{ color: "red" }}>{errors}</span>}
            </>
        );
    }
}

export default DetalizationOfSiteDialogBody;
