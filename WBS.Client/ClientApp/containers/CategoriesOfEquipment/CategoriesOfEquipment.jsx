import { connect } from "react-redux";
import actionsCreators from "../../reducers/CategoriesOfEquipment";
import CreateTable from "../../components/Commons/Table";

const mapStateToProps = state => state.categoriesOfEquipment;

const mapDispatchToProps = {
    ...actionsCreators
};

const CategoriesOfEquipmentContainer = (dataFields, DialogBody) =>
    connect(
        mapStateToProps,
        mapDispatchToProps
    )(
        CreateTable({
            dataFiledsInfo: dataFields,
            DialogBodyComponent: DialogBody
        })
    );

export default CategoriesOfEquipmentContainer;
