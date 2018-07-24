import React from "react";
import PropTypes from "prop-types";
import TextFieldMultiline from "../Commons/TextFields/TextFieldMultiline";
import TextFieldSelect from "../Commons/TextFields/TextFieldSelect";
import TextFieldPlaceholder from "../Commons/TextFields/TextFieldPlaceholder";
import { fieldNames } from "./DataFieldsInfo";

class CategoriesOfEquipmentDialogBody extends React.PureComponent {
    constructor(props) {
        super(props);
        const {
            categoryGroupId,
            code,
            title,
            depreciationPeriod
        } = fieldNames;
        this.state = {
            id: 0,
            [categoryGroupId.id]: 0,
            [code.id]: "",
            [title.id]: "",
            [depreciationPeriod.id]: ""
        };
    }

    static propTypes = {
        getGroupsForSelect: PropTypes.func,
        groups: PropTypes.array.isRequired,
        errors: PropTypes.object,
        data: PropTypes.any.isRequired,
        onRef: PropTypes.func.isRequired
    };

    //lifecycles
    static getDerivedStateFromProps(nextProps) {
        return nextProps && nextProps.data ? { ...nextProps.data } : null;
    }

    componentDidMount() {
        const { getGroupsForSelect, onRef } = this.props;
        //связываем с родительским компонентом,
        //чтобы он имел доступ к методам дочернего компонента
        onRef(this);
        getGroupsForSelect();
    }

    getDataToSave = () => this.state;

    //handlers
    handleChange = e => {
        const { name, value } = e.target;
        this.setState({ [name]: value });
    };

    render() {
        const { errors, groups } = this.props;
        const { categoryGroupId, code, title, depreciationPeriod } = this.state;
        const {
            categoryGroupId: categoryName,
            code: codeName,
            title: titleName,
            depreciationPeriod: periodName
        } = fieldNames;

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
                        groups &&
                        groups.map(elem => ({
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
                        type: "number",
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
