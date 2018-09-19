import React from "react";
import PropTypes from "prop-types";
import Autosuggest from "react-autosuggest";

import TextField from "@material-ui/core/TextField";
import Paper from "@material-ui/core/Paper";
import MenuItem from "@material-ui/core/MenuItem";
import { withStyles } from "@material-ui/core/styles";

import styles from './AutosuggestField.css';

const SUGGESTION_COUNT = 20;

function renderInput(inputProps) {
    const { classes, ref, label, input, ...other } = inputProps;
    return (
        <TextField
                {...input}
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

function renderSuggestion(suggestion, { isHighlighted }) {
    return (
        <MenuItem
            selected={isHighlighted}
            component="div"
            style={{ height: "35px" }}
        >
            <div>
                <span style={{ fontWeight: "bold" }}>
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
                children.props.items.length === SUGGESTION_COUNT && (
                    <ul style={{ рeight: 80 }}>Уточните параметры поиска</ul>
                )}
        </Paper>
    );
}

const getSuggestionValue = suggestion => suggestion.fio;

class AutosuggestField extends React.Component {
    handleSuggestionsFetchRequested = ({ value, reason }) => {
        if (value.length > 2 && reason !== 'input-focused') {
            const { getItems } = this.props;
            getItems(value, SUGGESTION_COUNT);
        }
    };

    showError = () => { };

    onSuggestionSelected = (event, { suggestion }) => {
        const { input } = this.props;
        input.onChange(suggestion);
    };

    render() {
        const { classes, label, input, suggestions } = this.props;
        const { value, onChange, name } = input;

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
                renderSuggestionsContainer={renderSuggestionsContainer}
                getSuggestionValue={getSuggestionValue}
                renderSuggestion={renderSuggestion}
                onSuggestionSelected={this.onSuggestionSelected}
                inputProps={{
                    classes,
                    label,
                    name,
                    value: value.fio ? value.fio : value,
                    onChange,
                    autoFocus: true
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
    value: PropTypes.any,
    textPropName: PropTypes.string,
    getItems: PropTypes.func,
    clearItems: PropTypes.func,
    suggestions: PropTypes.array,
    input: PropTypes.object,
    disabled: PropTypes.bool
};

export default withStyles(styles)(AutosuggestField);