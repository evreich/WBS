import React from "react";
import PropTypes from "prop-types";

import TextFieldMultiline from "../../Commons/TextFields/TextFieldMultiline";
import TextFieldPlaceholder from "../../Commons/TextFields/TextFieldPlaceholder";
import transformFieldsToState from "../../../helpers/transformFieldsToState";

class CategoryGroupDialogBody extends React.PureComponent {
    constructor(props) {
        super(props);
        this.fields = transformFieldsToState(Object.values(props.formFields));

        this.state = {
            id: 0,
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

    componentDidMount() {
        const onRef = this.props.onRef;
        //связываем с родительским компонентом,
        //чтобы он имел доступ к методам дочернего компонента
        onRef(this);
    }

    getDataToSave = () => this.state;

    //handlers
    handleChange = e => {
        const { name, value } = e.target;
        this.setState({ [name]: value });
    };

    render() {
        const { errors, formFields } = this.props;
        const { code, title } = this.state;
        const { code: codeName, title: titleName } = formFields;

        return (
            <>
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
                        name: codeName.propName,
                        label: codeName.label,
                        value: code,
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

export default CategoryGroupDialogBody;
