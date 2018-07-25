import { connect } from "react-redux";

import CreateTable from "../../components/Commons/Table";
import { getTable } from '../../reducers/tablesReducer/tablesActions';

const TABLE = "categoriesOfEquipment";
const ROUTE = document.api.categoriesOfEquipment;

const mapStateToProps = state => (
    state.tables[TABLE] ?
        {
            //groups: state.helpers.groupsOfCategories,
            initialValues: state.tables[TABLE].updatingDataItem,
            ...state.tables[TABLE]
            //TODO: send server error in form from redux store
            //errors: state.form.errors
        } : {});


const mapDispatchToProps = (dispatch) => ({
    getDataTable: (pageIndex, pageSize) => dispatch(getTable(pageIndex, pageSize, ROUTE, TABLE))
    //CRUD
    //getGroupsForSelect
});

const CategoriesOfEquipmentContainer = (dataFields, DialogBody) => 
    connect(
        mapStateToProps,
        mapDispatchToProps
    )(
        CreateTable({
            dataFiledsInfo: dataFields,
            DialogBodyComponent: DialogBody,
            title: TABLE
        })
    );


export default CategoriesOfEquipmentContainer;
