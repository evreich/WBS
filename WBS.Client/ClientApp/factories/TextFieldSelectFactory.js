import React from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';

import TextFieldSelect from 'components/commons/textFields/TextFieldSelect';
import selectItemPropType from 'propTypes/selectItem';
import { getItemsForSelection, clearItemsForSelection } from 'actions/componentsActions';

export default (route, component) => {
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

    //TODO: reselect!!!
    const mapStateToProps = state => (
        state.components[component]
            ? {
                items: state.components[component].items &&
                    state.components[component].items.map(elem => ({
                        value: elem.id,
                        text: elem.title
                    }))
            }
            : {}
    );

    const mapDispatchToProps = (dispatch) => ({
        getItems: () => dispatch(getItemsForSelection(route, component)),
        clearItems: () => dispatch(clearItemsForSelection(component))
    });

    return connect(mapStateToProps, mapDispatchToProps)(Select);
}


