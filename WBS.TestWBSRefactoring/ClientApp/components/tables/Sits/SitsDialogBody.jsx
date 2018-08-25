import React from "react";
import PropTypes from "prop-types";

import TextFieldMultiline from "../../Commons/TextFields/TextFieldMultiline";
import TextFieldSelect from "../../Commons/TextFields/TextFieldSelect";
import UserAutosuggestField from "../../Commons/TextFields/UserAutosuggestField";
import transformFieldsToState from "helpers/transformFieldsToState";
import { getFormats } from "../helpersAPI";

class SitsDialogBody extends React.PureComponent {
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
        getFormats(this.setFormats, this.showError);
    }

    setFormats = data =>
        this.setState({
            formats: data
        });

    showError = () => {};

    getDataToSave = () => {
        const { 
            formatId,
            kySitId,
            technicalExpertId,
            directorOfSitId,
            createrOfBudgetId,
            kyRegionId,
            operationDirectorId,
            title
        } = this.state;
        return {
            formatId,
            kySitId,
            technicalExpertId,
            directorOfSitId,
            createrOfBudgetId,
            kyRegionId,
            operationDirectorId,
            title 
        }
    }

    //handlers
    handleChange = e => {
        const { name, value } = e.target;
        this.setState({ [name]: value });
    };

    render() {
        const { errors, formFields } = this.props;
        const {
            formats,
            formatId,
            title,
            kySitId,
            technicalExpertId,
            directorOfSitId,
            createrOfBudgetId,
            kyRegionId,
            operationDirectorId,
        } = this.state;
        const {
            title: titleName,
            formatId: formatIdName,
            kySitId: kySitIdName,
            technicalExpertId: technicalExpertIdName,
            directorOfSitId: directorOfSitIdName,
            createrOfBudgetId: createrOfBudgetIdName,
            kyRegionId: kyRegionIdName,
            operationDirectorId: operationDirectorIdName,
 
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
                <TextFieldSelect
                    muProps={{
                        name: formatIdName.propName,
                        label: formatIdName.label,
                        value: formatId,
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
                    items={
                        formats &&
                        formats.map(elem => ({
                            value: elem.id,
                            text: elem.title
                        }))
                    }
                />
                <UserAutosuggestField
                    name={kySitIdName.propName}
                    label={kySitIdName.label}
                    value={kySitId}
                    onSuggestionSelected={this.handleChange}
                />
                <UserAutosuggestField
                    name={technicalExpertIdName.propName}
                    label={technicalExpertIdName.label}
                    value={technicalExpertId}
                    onSuggestionSelected={this.handleChange}
                />
                <UserAutosuggestField
                    name={directorOfSitIdName.propName}
                    label={directorOfSitIdName.label}
                    value={directorOfSitId}
                    onSuggestionSelected={this.handleChange}
                />
                <UserAutosuggestField
                    name={createrOfBudgetIdName.propName}
                    label={createrOfBudgetIdName.label}
                    value={createrOfBudgetId}
                    onSuggestionSelected={this.handleChange}
                />
                <UserAutosuggestField
                    name={kyRegionIdName.propName}
                    label={kyRegionIdName.label}
                    value={kyRegionId}
                    onSuggestionSelected={this.handleChange}
                />
                <UserAutosuggestField
                    name={operationDirectorIdName.propName}
                    label={operationDirectorIdName.label}
                    value={operationDirectorId}
                    onSuggestionSelected={this.handleChange}
                />

                {/*TODO: VALIDATION */}
                {errors && <span style={{ color: "red" }}>{errors}</span>}
            </>
        );
    }
}

export default SitsDialogBody;
