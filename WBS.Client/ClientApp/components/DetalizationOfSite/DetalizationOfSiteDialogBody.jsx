import React from "react";
import PropTypes from "prop-types";
import TextFieldSelect from "../Commons/TextFields/TextFieldSelect";
import TextFieldPlaceholder from "../Commons/TextFields/TextFieldPlaceholder";
import { fieldNames } from "./DataFieldsInfo";

class DetalizationOfSiteDialogBody extends React.PureComponent {
    constructor(props) {
        super(props);
        const {
            resultCenterId,
            typeOfInvestmentId,
            categoryId,
            subjectOfInvestment,
            dateOfDelivery,
            count,
            price
        } = fieldNames;
        this.state = {
            id: 0,
            [resultCenterId.id]: 0,
            [typeOfInvestmentId.id]: 0,
            [categoryId.id]: 0,
            [subjectOfInvestment.id]: "",
            [dateOfDelivery.id]: new Date(),
            [count.id]: 0,
            [price.id]: 0
        };
    }

    static propTypes = {
        getGroupsForSelect: PropTypes.func,
        getTypesOfInvestment: PropTypes.func,
        getResultCentresSelect: PropTypes.func,
        groups: PropTypes.array.isRequired,
        errors: PropTypes.object,
        data: PropTypes.any.isRequired,
        onRef: PropTypes.func.isRequired,
        resultCentres: PropTypes.array,
        typesOfInvestment: PropTypes.array,
        categories: PropTypes.array,
        siteId: PropTypes.number.isRequired,
        budgetPlan: PropTypes.object.isRequired
    };

    //lifecycles
    static getDerivedStateFromProps(nextProps) {
        return nextProps && nextProps.data ? { ...nextProps.data } : null;
    }

    componentDidMount() {
        const {
            onRef,
            getTypesOfInvestment,
            getGroupsForSelect,
            getResultCentresSelect
        } = this.props;
        //связываем с родительским компонентом,
        //чтобы он имел доступ к методам дочернего компонента
        onRef(this);
        getTypesOfInvestment();
        getGroupsForSelect();
        getResultCentresSelect();
    }

    getDataToSave = () => this.state;

    //handlers
    handleChange = e => {
        const { name, value } = e.target;
        this.setState({ [name]: value });
    };

    render() {
        const {
            errors,
            resultCentres,
            typesOfInvestment,
            categories
        } = this.props;
        const {
            resultCenterId,
            typeOfInvestmentId,
            categoryId,
            subjectOfInvestment,
            investmentDate,
            count,
            costItem
        } = this.state;
        const {
            resultCenterId: resultCenterName,
            typeOfInvestmentId: typeOfInvestmentName,
            categoryId: categoryName,
            subjectOfInvestment: subjectOfInvestmentName,
            dateOfDelivery: dateOfDeliveryName,
            count: countName,
            price: priceName
        } = fieldNames;

        return (
            <>
                <TextFieldSelect
                    muProps={{
                        name: resultCenterName.id,
                        label: resultCenterName.label,
                        value: resultCenterId,
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
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
                        name: typeOfInvestmentName.id,
                        label: typeOfInvestmentName.label,
                        value: typeOfInvestmentId,
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
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
                        name: categoryName.id,
                        label: categoryName.label,
                        value: categoryId,
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
                    items={
                        categories &&
                        categories.map(elem => ({
                            value: elem.id,
                            text: elem.title
                        }))
                    }
                />
                <TextFieldPlaceholder
                    muProps={{
                        name: subjectOfInvestmentName.id,
                        label: subjectOfInvestmentName.label,
                        value: subjectOfInvestment,
                        type: "number",
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
                />
                <TextFieldPlaceholder
                    muProps={{
                        name: dateOfDeliveryName.id,
                        label: dateOfDeliveryName.label,
                        value: investmentDate,
                        type: "number",
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
                />
                <TextFieldPlaceholder
                    muProps={{
                        name: countName.id,
                        label: countName.label,
                        value: count,
                        type: "number",
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
                />
                <TextFieldPlaceholder
                    muProps={{
                        name: priceName.id,
                        label: priceName.label,
                        value: costItem,
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
