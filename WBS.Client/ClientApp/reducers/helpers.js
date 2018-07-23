import { Constants, Prefix, HelpersActions } from '../constants';
import { fetch } from '../utils';
import { combineReducers } from 'redux';
import { makeURL } from '../helpers/urlHelper';

const helperReducerFor = (prefix) => {
    const helperReducer = (state = [], action) => {
        switch (action.type) {
            case prefix + HelpersActions.FETCH_HELPERS:
                return action.payload;
            default:
                return state;
        }
    };
    return helperReducer;
}

const helperReducerDictFor = (prefix) => {
    const helperReducer = (state = {}, action) => {
        switch (action.type) {
            case prefix + HelpersActions.FETCH_HELPERS: {
                const result = { ...state };
                result[action.key] = action.payload;
                return result;
            }
            default:
                return state;
        }
    };
    return helperReducer;
}

const getSelectionDataFor = (prefix, URL) =>
    (params = {}, key) => (dispatch, getState) => {
        const url = makeURL(URL, params);
        fetch(url.href, {
            method: 'GET'
        }, dispatch, getState().auth)
            .then(response =>
                response.json()
                    .then(result => {
                        dispatch({
                            type: prefix + HelpersActions.FETCH_HELPERS,
                            payload: result,
                            key: key
                        });
                    })
            )
            .catch(error => {
                alert(error);
            });
    };



const actionCreators = {
    getProfilesForSelect: getSelectionDataFor(Prefix.FOR_PROFILES, Constants.GET_PROFILE_FOR_SELECT),
    getFilteredProfilesForSelect: (query, count, key) =>
        getSelectionDataFor(Prefix.FOR_FILTERED_PROFILES, Constants.GET_PROFILE_FOR_SELECT)({ query: query, count: count }, key),
    getFormatsForSelect: getSelectionDataFor(Prefix.FOR_FORMATS, Constants.GET_FORMATS_FOR_SELECT),
    getRolesForSelect: getSelectionDataFor(Prefix.FOR_ROLES, Constants.GET_ROLES_FOR_SELECT),
    getGroupsForSelect: getSelectionDataFor(Prefix.FOR_CATEGORY_GROUPS, Constants.GET_CATEGORY_GROUPS_FOR_SELECT),
    getSitsForSelect: getSelectionDataFor(Prefix.FOR_SITES, Constants.GET_SITS_FOR_SELECT),
    getTypesOfInvestment: getSelectionDataFor(Prefix.FOR_INVESTMENT, Constants.GET_TYPES_OF_INVESTMENT_FOR_SELECT),
    getResultCentresSelect: getSelectionDataFor(Prefix.FOR_RESULT_CENTRE, Constants.GET_RESULT_CENTRE_FOR_SELECT),
    getTechnicalsServsSelect: getSelectionDataFor(Prefix.FOR_TECHNICAL_SERVS, Constants.GET_TECHNICAL_SERVS_SELECT),
    getInvestmentRationalSelect: getSelectionDataFor(Prefix.FOR_RATIONAL_INVESTMENT, Constants.GET_RATIONAL_INVESTMENT_SELECT)
}

export const reducer = combineReducers({
    profiles: helperReducerFor(Prefix.FOR_PROFILES),
    filteredProfiles: helperReducerDictFor(Prefix.FOR_FILTERED_PROFILES),
    formats: helperReducerFor(Prefix.FOR_FORMATS),
    roles: helperReducerFor(Prefix.FOR_ROLES),
    groupsOfCategories: helperReducerFor(Prefix.FOR_CATEGORY_GROUPS),
    sits: helperReducerFor(Prefix.FOR_SITES),
    resultCentres: helperReducerFor(Prefix.FOR_RESULT_CENTRE),
    technicalServs: helperReducerFor(Prefix.FOR_TECHNICAL_SERVS),
    investmentRational: helperReducerFor(Prefix.FOR_RATIONAL_INVESTMENT),
    typesOfInvestment: helperReducerFor(Prefix.FOR_INVESTMENT)
})

export default actionCreators;