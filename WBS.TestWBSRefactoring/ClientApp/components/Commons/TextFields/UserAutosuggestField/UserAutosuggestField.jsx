import React from "react";
import PropTypes from "prop-types";
import Autosuggest from "react-autosuggest";

import TextField from "@material-ui/core/TextField";
import Paper from "@material-ui/core/Paper";
import MenuItem from "@material-ui/core/MenuItem";
import { withStyles } from "@material-ui/core/styles";
//import match from 'autosuggest-highlight/umd/match';
//import parse from 'autosuggest-highlight/umd/parse';

import { getFilteredProfilesForSelect } from "./helpersAPI";
import styles from './UserAutosuggestField.css';

const suggestionCount = 20;

function renderInput(inputProps) {
    const { classes, ref, label, ...other } = inputProps;

    return (
        <TextField
            fullWidth
            label={label}
            style={{ marginTop: "20px" }}
            InputProps={{
                inputRef: ref,
                classes: {
                    input: classes.input
                },
                ...other
            }}
        />
    );
}

function renderSuggestion(suggestion, { /*query,*/ isHighlighted }) {
    //const matches = match(suggestion.label, query);
    //const parts = parse(suggestion.label, matches);

    return (
        <MenuItem
            selected={isHighlighted}
            component="div"
            style={{ height: "35px" }}
        >
            <div>
                {/*parts.map((part, index) => (part.highlight ?
                    <span key={String(index)}>
                        {part.fio}
                    </span>
                    :
                    <strong key={String(index)}>
                        {part.fio}
                    </strong>
                )
                )*/}
                <span style={{ fontWeight: "bold" }} /*key={String(index)}*/>
                    {suggestion.fio}
                </span>
                <br />
                <span style={{ fontSize: "13px" }}>{suggestion.login}</span>
            </div>
        </MenuItem>
    );
}

function renderSuggestionsContainer(options) {
    const { containerProps, children } = options;

    return (
        <Paper
            {...containerProps}
            square
            /*todo: */ style={{ maxHeight: 200, overflow: "auto" }}
        >
            {children}
            {children !== null &&
                children.props.items.length === suggestionCount && (
                    <ul style={{ рeight: 80 }}>Уточните параметры поиска</ul>
                )}
        </Paper>
    );
}

function getSuggestionValue(suggestion) {
    return suggestion.fio;
}

class AutosuggestField extends React.Component {
    state = {
        value: "",
        fetchedValue: "",
        suggestions: []
    };

    handleSuggestionsFetchRequested = ({ value }) => {
        const fetchedValue = this.state.fetchedValue;
        //запоминаем значение fetchedValue, для которого уже делали запрос, иначе на каждый клик шлет запросы на сервер
        if (value.length > 2 && value !== fetchedValue) {
            getFilteredProfilesForSelect(
                this.setSuggestion,
                this.showError,
                { value, suggestionCount }
            );
            this.setState({ fetchedValue: value });
        } else {
            this.handleSuggestionsClearRequested();
            this.setState({ fetchedValue: "" });
        }
    };

    setSuggestion = data =>
        this.setState({
            suggestions: data
        });

    showError = () => {};

    onSuggestionSelected = (event, { suggestion }) => {
        this.setState({
            value: suggestion.fio,
            suggestions: [],
            fetchedValue: ""
        });
        const { onSuggestionSelected, name } = this.props;
        onSuggestionSelected({ target: { name: name, value: suggestion.id } });
    };

    handleSuggestionsClearRequested = () => {
        this.setState({
            suggestions: []
        });
    };

    handleChange = (event, { newValue }) => {
        this.setState({
            value: newValue
        });
    };

    render() {
        const { classes, name, label } = this.props;
        const { value, suggestions } = this.state;

        return (
            <Autosuggest
                theme={{
                    container: classes.container,
                    suggestionsContainerOpen: classes.suggestionsContainerOpen,
                    suggestionsList: classes.suggestionsList,
                    suggestion: classes.suggestion
                }}
                renderInputComponent={renderInput}
                suggestions={suggestions}
                onSuggestionsFetchRequested={
                    this.handleSuggestionsFetchRequested
                }
                onSuggestionsClearRequested={
                    this.handleSuggestionsClearRequested
                }
                renderSuggestionsContainer={renderSuggestionsContainer}
                getSuggestionValue={getSuggestionValue}
                renderSuggestion={renderSuggestion}
                onSuggestionSelected={this.onSuggestionSelected}
                inputProps={{
                    classes,
                    label,
                    name,
                    value,
                    onChange: this.handleChange
                }}
            />
        );
    }
}

AutosuggestField.propTypes = {
    classes: PropTypes.object.isRequired,
    name: PropTypes.string,
    label: PropTypes.string.isRequired,
    onSuggestionSelected: PropTypes.func.isRequired,
    value: PropTypes.any
};

export default withStyles(styles)(AutosuggestField);
