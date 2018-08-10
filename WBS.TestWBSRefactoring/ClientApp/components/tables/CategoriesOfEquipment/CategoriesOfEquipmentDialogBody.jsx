import React from "react";
import PropTypes from "prop-types";

import TextFieldMultiline from "../../Commons/TextFields/TextFieldMultiline";
import TextFieldSelect from "../../Commons/TextFields/TextFieldSelect";
import TextFieldPlaceholder from "../../Commons/TextFields/TextFieldPlaceholder";
import { getCategoryGroups } from "../helpersAPI";
import transformFieldsToState from '../../../helpers/transformFieldsToState';

class CategoriesOfEquipmentDialogBody extends React.PureComponent {
    constructor(props) {
        super(props);
        this.fields = transformFieldsToState(Object.values(props.formFields));

        this.state = {
            id: 0,
            categoryGroups: [],
            ...this.fields
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

    setCategoryGroups = (data) => {
        this.setState({
            categoryGroups: data
        });
    }

    showError = () => {

    }

    componentDidMount() {
        const onRef = this.props.onRef;
        //связываем с родительским компонентом,
        //чтобы он имел доступ к методам дочернего компонента
        onRef(this);
        getCategoryGroups(this.setCategoryGroups, this.showError);
    }

    getDataToSave = () => this.state;

    //handlers
    handleChange = e => {
        const { name, value } = e.target;
        this.setState({ [name]: value });
    };

    render() {
        const { errors, formFields } = this.props;
        const { categoryGroupId, code, title, depreciationPeriod, categoryGroups } = this.state;
        const {
            categoryGroupId: categoryName,
            code: codeName,
            title: titleName,
            depreciationPeriod: periodName
        } = formFields;

        return (
            <>
                <TextFieldSelect
                    muProps={{
                        name: categoryName.propName,
                        label: categoryName.label,
                        value: categoryGroupId,
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
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
                        name: codeName.propName,
                        label: codeName.label,
                        value: code,
                        type: "number",
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
                />
                <TextFieldMultiline
                    muProps={{
                        name: titleName.propName,
                        label: titleName.label,
                        value: title,
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
                />
                <TextFieldPlaceholder
                    muProps={{
                        name: periodName.propName,
                        label: periodName.label,
                        value: depreciationPeriod,
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

export default CategoriesOfEquipmentDialogBody;
