import React from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';
import Autosuggest from 'react-autosuggest';

import TextField from '@material-ui/core/TextField';
import Paper from '@material-ui/core/Paper';
import MenuItem from '@material-ui/core/MenuItem';
import { withStyles } from '@material-ui/core/styles';
//import match from 'autosuggest-highlight/umd/match';
//import parse from 'autosuggest-highlight/umd/parse';

import actionsCreators from '../../../reducers/helpers';

const suggestionCount = 20;

function renderInput(inputProps) {
    const { classes, ref, label, ...other } = inputProps;

    return (
        <TextField
            fullWidth
            label={label}
            style={{ marginTop: '20px' }}
            InputProps={{
                inputRef: ref,
                classes: {
                    input: classes.input,
                },
                ...other,
            }}
        />
    );
}

function renderSuggestion(suggestion, { /*query,*/ isHighlighted }) {
    //const matches = match(suggestion.label, query);
    //const parts = parse(suggestion.label, matches);

    return (
        <MenuItem selected={isHighlighted} component="div" style={{ height: '35px' }}>
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
                <span style={{ fontWeight: 'bold' }}/*key={String(index)}*/>
                    {suggestion.fio}
                </span>
                <br />
                <span style={{ fontSize: '13px' }}>{suggestion.login}</span>
            </div>
        </MenuItem>
    );
}

function renderSuggestionsContainer(options) {
    const { containerProps, children } = options;

    return (
        <Paper {...containerProps} square /*todo: */ style={{ maxHeight: 200, overflow: 'auto' }}>
            {children}
            {children !== null && children.props.items.length === suggestionCount && <ul style={{ рeight: 80 }}>Уточните параметры поиска</ul>}
        </Paper>
    );
}

function getSuggestionValue(suggestion) {
    return suggestion.fio;
}


const styles = theme => ({
    container: {
        flexGrow: 1,
        position: 'relative'
    },
    suggestionsContainerOpen: {
        position: 'absolute',
        zIndex: 1,
        marginTop: theme.spacing.unit,
        left: 0,
        right: 0,
    },
    suggestion: {
        display: 'block',
    },
    suggestionsList: {
        margin: 0,
        padding: 0,
        listStyleType: 'none',
    },
});

class AutosuggestField extends React.Component {
    state = {
        value: '',
        fetchedValue: '',
        suggestions: [],
    };

    static getDerivedStateFromProps(nextProps, state) {
        const res = !nextProps || typeof state.fetchedValue !== 'string' || state.fetchedValue.length === 0
            || !Array.isArray(nextProps.suggestionsDict[nextProps.name])
            ? { suggestions: [] }
            : { suggestions: nextProps.suggestionsDict[nextProps.name] };
        return res;
    }

    handleSuggestionsFetchRequested = ({ value }) => {
        const { fetchedValue } = this.state;
        //запоминаем значение fetchedValue, для которого уже делали запрос, иначе на каждый клик шлет запросы на сервер
        if (value.length > 2 && value !== fetchedValue) {
            const { getFilteredProfilesForSelect, name } = this.props;
            getFilteredProfilesForSelect(value, suggestionCount, name);
            this.setState({ fetchedValue: value });
        }
        else {
            this.handleSuggestionsClearRequested();
            this.setState({ fetchedValue: '' });
        }
    };

    onSuggestionSelected = (event, { suggestion }) => {
        this.setState({
            value: suggestion.fio,
            suggestions: [],
            fetchedValue: ''
        });
        const { onSuggestionSelected, name } = this.props;
        onSuggestionSelected({ target: { name: name, value: suggestion.id } });
    }

    handleSuggestionsClearRequested = () => {
        this.setState({
            suggestions: [],
        });
    };

    handleChange = (event, { newValue }) => {
        this.setState({
            value: newValue,
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
                    suggestion: classes.suggestion,
                }}
                renderInputComponent={renderInput}
                suggestions={suggestions}
                onSuggestionsFetchRequested={this.handleSuggestionsFetchRequested}
                onSuggestionsClearRequested={this.handleSuggestionsClearRequested}
                renderSuggestionsContainer={renderSuggestionsContainer}
                getSuggestionValue={getSuggestionValue}
                renderSuggestion={renderSuggestion}
                onSuggestionSelected={this.onSuggestionSelected}
                inputProps={{
                    classes,
                    label,
                    name,
                    value,
                    onChange: this.handleChange,
                }}
            />
        );
    }
}

AutosuggestField.propTypes = {
    classes: PropTypes.object.isRequired,
    name: PropTypes.string,
    label: PropTypes.string.isRequired,
    suggestions: PropTypes.array,
    suggestionsDict: PropTypes.object.isRequired,
    onSuggestionSelected: PropTypes.func.isRequired,
    getFilteredProfilesForSelect: PropTypes.func.isRequired
};

const mapDispatchFromProps = { ...actionsCreators }
const mapStateToProps = (state) => ({ suggestionsDict: state.helpers.filteredProfiles })

export default withStyles(styles)(
    connect(mapStateToProps, mapDispatchFromProps)(AutosuggestField)
);
