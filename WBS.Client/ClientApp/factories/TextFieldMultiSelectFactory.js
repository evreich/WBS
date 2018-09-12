import React from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';

import TextFieldMultiSelect from 'components/commons/textFields/TextFieldMultiSelect';
import selectItemPropType from 'propTypes/selectItem';
import { getItemsForSelection, clearItemsForSelection } from 'actions/componentsActions';

export default (route, component) => {
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

    //TODO: reselect!!!
    const mapStateToProps = state => (
        state.components[component]
            ? { items: state.components[component].items }
            : {}
    );

    const mapDispatchToProps = (dispatch) => ({
        getItems: () => dispatch(getItemsForSelection(route, component)),
        clearItems: () => dispatch(clearItemsForSelection(component))
    });

    return connect(mapStateToProps, mapDispatchToProps)(MultiSelect);
}


