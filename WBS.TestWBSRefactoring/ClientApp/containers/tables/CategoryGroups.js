import { connect } from "react-redux";

import CreateTable from "generators/Table";
import { getTable, clearTable, updateTable, changeData, deleteData } from '../tablesActions';

const TABLE = "categoryGroups";
const ROUTE = document.api.categoryGroups;

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

//TODO: tableStyles
export default connect(
    mapStateToProps,
    mapDispatchToProps
)(
    CreateTable({
        title: TABLE,
        tableStyles: tableStyles
    })
);
