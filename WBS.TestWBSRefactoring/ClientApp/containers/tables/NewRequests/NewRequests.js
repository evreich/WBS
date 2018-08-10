import { connect } from "react-redux";

import CreateTable from "../../../components/Commons/Table";
import { getTable, clearTable, updateTable, changeData, deleteData } from '../tablesActions';

const TABLE = "newRequests";
const ROUTE = document.api.newRequests;

//TODO: исправить код в Table component
//заглушка для InformationModalWindow
const EmptyComponent = () => null;

const mapStateToProps = state => 
    (state.tables[TABLE] ?
        {
            ...state.tables[TABLE]
            //TODO: send server error in form from redux store
            //errors: state.tables[TABLE].errors
        } : {});

const mapDispatchToProps = (dispatch) => ({
    getDataTable: (pageIndex, pageSize) => dispatch(getTable(pageIndex, pageSize, ROUTE, TABLE)),
    clearTable: () => dispatch(clearTable(TABLE)),
    updateTable: (data) => dispatch(updateTable(data, TABLE)),
    changeData: (pageIndex, pageSize, method, data) => dispatch(changeData(pageIndex, pageSize, method, data, ROUTE, TABLE)),
    deleteData: (pageIndex, pageSize, data) => dispatch(deleteData(pageIndex, pageSize, data, ROUTE, TABLE))
});

const CategoriesOfEquipmentContainer = (dataFields, ChangeItemWindow) => 
    connect(
        mapStateToProps,
        mapDispatchToProps
    )(
        CreateTable({
            dataFiledsInfo: dataFields,
            ChangeItemModalWindow: ChangeItemWindow,
            InformationModalWindow: EmptyComponent,
            title: TABLE
        })
    );

export default CategoriesOfEquipmentContainer;
