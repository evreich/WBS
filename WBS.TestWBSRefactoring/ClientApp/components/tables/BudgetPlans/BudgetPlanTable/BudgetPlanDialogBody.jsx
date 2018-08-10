import React from "react";
import PropTypes from "prop-types";

import TextFieldPlaceholder from "../../../Commons/TextFields/TextFieldPlaceholder";
import { commonFields } from "./DataFieldsInfo";
 
//validation information
const minYearOfBusinessPlan = 2008;
const maxYearOfBusinessPlan = 2040;
const notValidYearMessage = `Год должен быть в диапазоне от ${minYearOfBusinessPlan} до ${maxYearOfBusinessPlan}`;
const yearIsValid = currYear =>
    currYear >= minYearOfBusinessPlan && currYear <= maxYearOfBusinessPlan;
 
class BudgetPlanDialogBody extends React.PureComponent {
    constructor(props) {
        super(props);
        this.state = {
            [commonFields.year.propName]: minYearOfBusinessPlan,
            validationErorr: ""
        };
    }
 
    static propTypes = {
        errors: PropTypes.object,
        onRef: PropTypes.func
    };
 
    componentDidMount() {
        const onRef = this.props.onRef;
        //связываем с родительским компонентом,
        //чтобы он имел доступ к методам дочернего компонента
        onRef(this);
    }
 
    getDataToSave = () => {
        const year = this.state.year;
        if (yearIsValid(year)) return { year };
        else {
            this.setState({ validationErorr: notValidYearMessage });
        }
    };
 
    //handlers
    handleYearChange = e => {
        const { name, value } = e.target;
        this.setState({ [name]: value });
        !yearIsValid(value)
            ? this.setState({ validationErorr: notValidYearMessage })
            : this.setState({ validationErorr: "" });
    };
 
    render() {
        const errors = this.props.errors;
        const { year, validationErorr } = this.state;
        const { year: yearName } = commonFields;
 
        return (
            <>
                <TextFieldPlaceholder
                    muProps={{
                        name: yearName.propName,
                        value: year,
                        label: yearName.label,
                        type: "number",
                        inputProps: {
                            min: minYearOfBusinessPlan,
                            max: maxYearOfBusinessPlan
                        },
                        placeholder: "Введите год",
                        onChange: this.handleYearChange
                    }}
                />
                {validationErorr && (
                    <div><span style={{ color: "red" }}>{validationErorr}</span></div>
                )}
                {/*TODO: VALIDATION */}
                {errors && <span style={{ color: "red" }}>{errors}</span>}
            </>
        );
    }
}
 
export default BudgetPlanDialogBody;