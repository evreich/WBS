import React from "react";
import PropTypes from "prop-types";

import TextFieldMultiline from "../../Commons/TextFields/TextFieldMultiline";
import TextFieldSelect from "../../Commons/TextFields/TextFieldSelect";
import UserAutosuggestField from "../../Commons/TextFields/UserAutosuggestField";
import transformFieldsToState from "../../../helpers/transformFieldsToState";
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

    getDataToSave = () => this.state

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
            formats,
            formatId,
            title,
            kySitFio,
            technicalExpertFio,
            directorOfSitFio,
            createrOfBudgetFio,
            kyRegionFio,
            operationDirectorFio,
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
            formatTitle: formatTitleName,
            kySitFio: kySitFioName,
            technicalExpertFio: technicalExpertFioName,
            directorOfSitFio: directorOfSitFioName,
            createrOfBudgetFio: createrOfBudgetFioName,
            kyRegionFio: kyRegionFioName,
            operationDirectorFio: operationDirectorFioName,
 
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
                    textPropName={formatTitleName.propName}
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
                    value={kySitFio}
                    textPropName={kySitFioName.propName}
                    onSuggestionSelected={this.handleChange}
                />
                <UserAutosuggestField
                    name={technicalExpertIdName.propName}
                    label={technicalExpertIdName.label}
                    value={technicalExpertFio}
                    textPropName={technicalExpertFioName.propName}
                    onSuggestionSelected={this.handleChange}
                />
                <UserAutosuggestField
                    name={directorOfSitIdName.propName}
                    label={directorOfSitIdName.label}
                    value={directorOfSitFio}
                    textPropName={directorOfSitFioName.propName}
                    onSuggestionSelected={this.handleChange}
                />
                <UserAutosuggestField
                    name={createrOfBudgetIdName.propName}
                    label={createrOfBudgetIdName.label}
                    value={createrOfBudgetFio}
                    textPropName={createrOfBudgetFioName.propName}
                    onSuggestionSelected={this.handleChange}
                />
                <UserAutosuggestField
                    name={kyRegionIdName.propName}
                    label={kyRegionIdName.label}
                    value={kyRegionFio}
                    textPropName={kyRegionFioName.propName}
                    onSuggestionSelected={this.handleChange}
                />
                <UserAutosuggestField
                    name={operationDirectorIdName.propName}
                    label={operationDirectorIdName.label}
                    value={operationDirectorFio}
                    textPropName={operationDirectorFioName.propName}
                    onSuggestionSelected={this.handleChange}
                />

                {/*TODO: VALIDATION */}
                {errors && <span style={{ color: "red" }}>{errors}</span>}
            </>
        );
    }
}

export default SitsDialogBody;
