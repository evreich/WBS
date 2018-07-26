import React from "react";
import PropTypes from "prop-types";

import TextFieldMultiline from "../Commons/TextFields/TextFieldMultiline";
import TextFieldSelect from "../Commons/TextFields/TextFieldSelect";
import TextFieldPlaceholder from "../Commons/TextFields/TextFieldPlaceholder";
import { getCategoryGroups } from "./dialogBodyAPI";

class CategoriesOfEquipmentDialogBody extends React.PureComponent {
    constructor(props) {
        super(props);
        const fields = Object.values(props.formFields).reduce((fieldsInitObj, currField) => ({
                ...fieldsInitObj,
                [currField.id]: ''
            })
        , {});

        this.state = {
            id: 0,
            categoryGroups: [],
            ...fields
        };
    }

    static propTypes = {
        errors: PropTypes.object,
        data: PropTypes.any.isRequired,
        onRef: PropTypes.func.isRequired,
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
                        name: categoryName.id,
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
                        name: codeName.id,
                        label: codeName.label,
                        value: code,
                        type: "text",
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
                />
                <TextFieldMultiline
                    muProps={{
                        name: titleName.id,
                        label: titleName.label,
                        value: title,
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
                />
                <TextFieldPlaceholder
                    muProps={{
                        name: periodName.id,
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
