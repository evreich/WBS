import React from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';

import TextFieldMultiSelect from 'components/commons/textFields/TextFieldMultiSelect';
import selectItemPropType from 'propTypes/selectItem';
import { getItemsForSelection, clearItemsForSelection } from 'actions/componentsActions';

export default (route,
    componentName,
    mapStateToProps = defaultMapStateToProps(componentName),
    mapDispatchToProps = defaultMapDispatchToProps(route, componentName)
) => {
    class MultiSelect extends React.Component {
        componentDidMount() {
            const { getItems } = this.props;
            getItems();
        }

        componentWillUnmount() {
            const { clearItems } = this.props;
            clearItems();
        }

        render() {
            const { items, ...other } = this.props;
            return <TextFieldMultiSelect items={items} {...other} />
        }

    }

    MultiSelect.propTypes = {
        getItems: PropTypes.func.isRequired,
        clearItems: PropTypes.func.isRequired,
        items: PropTypes.arrayOf(selectItemPropType)
    }

    MultiSelect.defaultProps = {
        items: []
    }

    return connect(mapStateToProps, mapDispatchToProps)(MultiSelect);
}

//TODO: reselect!!!
const defaultMapStateToProps = componentName => state => (
    state.components[componentName]
        ? { items: state.components[componentName].items }
        : {}
);

const defaultMapDispatchToProps = (route, componentName) => (dispatch) => ({
    getItems: () => dispatch(getItemsForSelection(route, componentName)),
    clearItems: () => dispatch(clearItemsForSelection(componentName))
});


