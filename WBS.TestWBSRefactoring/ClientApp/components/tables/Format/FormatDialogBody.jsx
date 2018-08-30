import React from "react";
import PropTypes from "prop-types";

import TextFieldMultiline from "../../Commons/TextFields/TextFieldMultiline";
import TextFieldPlaceholder from "../../Commons/TextFields/TextFieldPlaceholder";
import UserAutosuggestField from "../../Commons/TextFields/UserAutosuggestField";
import transformFieldsToState from "helpers/transformFieldsToState";

class FormatDialogBody extends React.PureComponent {
    constructor(props) {
        super(props);
        this.fields = transformFieldsToState(Object.values(props.formFields));

        this.state = {
            id: 0,
            formats: [],
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
            title,
            profile,
            directorOfFormatFio,
            directorOfKYFormatFio,
            kyFormatFio,
            typeOfFormat,
            e1Limit,
            e2Limit,
            e3Limit
        } = this.state;
        const {
            title: titleName,
            profile: profileName,
            directorOfFormatId: directorOfFormatIdName,
            directorOfFormatFio: directorOfFormatFioName,
            directorOfKYFormatId: directorOfKYFormatIdName,
            directorOfKYFormatFio: directorOfKYFormatFioName,
            kyFormatId: kyFormatIdName,
            kyFormatFio: kyFormatFioName,
            typeOfFormat: typeOfFormatName,
            e1Limit: e1LimitName,
            e2Limit: e2LimitName,
            e3Limit: e3LimitName
        } = formFields;

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
                <TextFieldMultiline
                    muProps={{
                        name: profileName.propName,
                        label: profileName.label,
                        value: profile,
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
                />
                <UserAutosuggestField
                    name={directorOfFormatIdName.propName}
                    label={directorOfFormatIdName.label}
                    value={directorOfFormatFio}
                    textPropName={directorOfFormatFioName.propName}
                    onSuggestionSelected={this.handleChange}
                />
                <UserAutosuggestField
                    name={directorOfKYFormatIdName.propName}
                    label={directorOfKYFormatIdName.label}
                    value={directorOfKYFormatFio}
                    textPropName={directorOfKYFormatFioName.propName}
                    onSuggestionSelected={this.handleChange}
                />
                <UserAutosuggestField
                    name={kyFormatIdName.propName}
                    label={kyFormatIdName.label}
                    value={kyFormatFio}
                    textPropName={kyFormatFioName.propName}
                    onSuggestionSelected={this.handleChange}
                />
                <TextFieldMultiline
                    muProps={{
                        name: typeOfFormatName.propName,
                        label: typeOfFormatName.label,
                        value: typeOfFormat,
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
                />
                <TextFieldPlaceholder
                    muProps={{
                        name: e1LimitName.propName,
                        label: e1LimitName.label,
                        value: e1Limit,
                        type: "number",
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
                />
                <TextFieldPlaceholder
                    muProps={{
                        name: e2LimitName.propName,
                        label: e2LimitName.label,
                        value: e2Limit,
                        type: "number",
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
                />
                <TextFieldPlaceholder
                    muProps={{
                        name: e3LimitName.propName,
                        label: e3LimitName.label,
                        value: e3Limit,
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

export default FormatDialogBody;
