import autosuggestFactory from 'factories/AutosuggestFactory';
import api from 'constants/api';
import * as propTypes from 'prop-types';
import React from 'react';

const UserAutoSuggest = props => {
    const AutoSuggest = autosuggestFactory(api.filteredProfilesForSelect, props.input.name);
    return <AutoSuggest {...props} />
};

UserAutoSuggest.propTypes = {
    input: propTypes.shape({
        name: propTypes.string
    })
}

export default UserAutoSuggest;