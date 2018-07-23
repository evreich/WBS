import { connect } from "react-redux";
import CategoriesOfEquipmentDialogBody from '../../components/CategoriesOfEquipment/CategoriesOfEquipmentDialogBody'
import actionCreators from "../../reducers/helpers"; 

const mapStateToProps = state => ({
    groups: state.helpers.groupsOfCategories,
    initialValues: state.categoriesOfEquipment.updatingDataItem
    //TODO: send server error in form from redux store
    //errors: state.form.errors
});

const mapDispatchFromProps = {
    ...actionCreators
};

export default connect(
    mapStateToProps,
    mapDispatchFromProps
)(CategoriesOfEquipmentDialogBody);
