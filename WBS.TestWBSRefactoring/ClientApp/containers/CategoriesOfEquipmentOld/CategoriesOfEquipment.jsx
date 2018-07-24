import { connect } from "react-redux";
import actionsCreators from "../../reducers/CategoriesOfEquipment";
import CreateTable from "../../components/Commons/Table";


const mapStateToProps = state => ({
    groups: state.helpers.groupsOfCategories,
    initialValues: state.categoriesOfEquipment.updatingDataItem,
    categoriesOfEquipment: state.categoriesOfEquipment
    //TODO: send server error in form from redux store
    //errors: state.form.errors
});

const mapDispatchToProps = {
    ...actionsCreators,
     //getDataTable
    //CRUD
    //getGroupsForSelect
};

const CategoriesOfEquipmentContainer = (dataFields, DialogBody) =>
    connect(
        mapStateToProps,
        mapDispatchToProps
    )(
        CreateTable({
            dataFiledsInfo: dataFields,
            DialogBodyComponent: DialogBody,
            title: "CategoriesOfEquipmentContainer"
        })
    );

export default CategoriesOfEquipmentContainer;
