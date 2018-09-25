import React from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';

import TextFieldSelect from 'components/commons/textFields/TextFieldSelect/TextFieldSelect';
import selectItemPropType from 'propTypes/selectItem';
import { getItemsForSelection, clearComponentData } from 'actions/componentsActions';
import getSelectItems from 'selectors/selectItemsSelectors';

export default (route,
    componentName,
    mapStateToProps = defaultMapStateToProps(componentName),
    mapDispatchToProps = defaultMapDispatchToProps(route, componentName)
) => {
    class Select extends React.Component {
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
            return <TextFieldSelect items={items} {...other} />
        }

    }

    Select.propTypes = {
        getItems: PropTypes.func.isRequired,
        clearItems: PropTypes.func.isRequired,
        items: PropTypes.arrayOf(selectItemPropType)
    }

    Select.defaultProps = {
        items: []
    }

    return connect(mapStateToProps, mapDispatchToProps)(Select);
}

const defaultMapStateToProps = componentName => state => (
    state.components[componentName]
        ? {
            items: getSelectItems(componentName)(state)
        }
        : {}
);

const defaultMapDispatchToProps = (route, componentName) => (dispatch) => ({
    getItems: () => dispatch(getItemsForSelection(route, componentName)),
    clearItems: () => dispatch(clearComponentData(componentName))
});