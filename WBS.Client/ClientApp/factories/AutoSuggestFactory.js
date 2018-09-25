import React from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';

import AutosuggestField from 'components/commons/textFields/AutosuggestField';
import selectItemPropType from 'propTypes/selectItem';
import { getItemsForSelection, clearItemsForSelection } from 'actions/componentsActions';
import getSelectItems from 'selectors/usersItemsSelectors';


class Select extends React.Component {
    componentWillUnmount() {
        const { clearItems } = this.props;
        clearItems();
    }
    render() {
        const { suggestions, getItems, clearItems, ...other } = this.props;
        return <AutosuggestField
            suggestions={suggestions ? suggestions : []}
            getItems={getItems}
            clearItems={clearItems}
            {...other} />
    }
}


export default (route,
    componentName,
    mapStateToProps = defaultMapStateToProps(componentName),
    mapDispatchToProps = defaultMapDispatchToProps(route, componentName)
) => {

    Select.propTypes = {
        getItems: PropTypes.func.isRequired,
        clearItems: PropTypes.func.isRequired,
        items: PropTypes.arrayOf(selectItemPropType),
        suggestions: PropTypes.array
    }

    Select.defaultProps = {
        items: []
    }

    return connect(mapStateToProps, mapDispatchToProps)(Select);
}


//TODO: reselect!!!
const defaultMapStateToProps = componentName => state => (
    state.components[componentName]
        ? {
            suggestions: getSelectItems(componentName)(state)
        }
        : {}
);

const defaultMapDispatchToProps = (route, componentName) => (dispatch) => ({
    getItems: (query, count) => dispatch(getItemsForSelection(route, componentName, { query, count})),
    clearItems: () => dispatch(clearItemsForSelection(componentName))
});