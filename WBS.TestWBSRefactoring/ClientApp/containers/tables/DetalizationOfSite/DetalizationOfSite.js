import { connect } from "react-redux";

import { getTable, clearTable, updateTable, changeData, deleteData } from '../tablesActions';
import CreateTable from "../../../components/Commons/Table";

const TABLE = "detalizationOfSite";
const ROUTE = document.api.itemsOfBudgetPlan;

const mapStateToProps = state => 
    (state.tables[TABLE] ?
        {
            ...state.tables[TABLE]
            //TODO: send server error in form from redux store
            //errors: state.tables[TABLE].errors
        } : {});

const mapDispatchToProps = (dispatch) => ({
    getDataTable: (pageIndex, pageSize, queryParams) => dispatch(getTable(pageIndex, pageSize, ROUTE, TABLE, queryParams)),
    clearTable: () => dispatch(clearTable(TABLE)),
    updateTable: (data) => dispatch(updateTable(data, TABLE)),
    changeData: (pageIndex, pageSize, method, data) => dispatch(changeData(pageIndex, pageSize, method, data, ROUTE, TABLE)),
    deleteData: (pageIndex, pageSize, data) => dispatch(deleteData(pageIndex, pageSize, data, ROUTE, TABLE))
});


const DetalizationOfSiteContainer = (dataFields, DialogBody, tableStyles) =>
    connect(
        mapStateToProps,
        mapDispatchToProps
    )(
        CreateTable({
            dataFiledsInfo: dataFields,
            DialogBodyComponent: DialogBody,
            tableStyles: tableStyles,
        })
    );

export default DetalizationOfSiteContainer;

