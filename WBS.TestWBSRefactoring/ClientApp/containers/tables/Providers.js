import { connect } from "react-redux";

import CreateTable from "generators/Table";
import ProviderTableRow from "components/tableRows/ProviderTableRow";
import { getTable, clearTable, updateTable, changeData, deleteData, setUpdatingItem } from 'actions/tablesActions';
import { tableStyles } from 'stylesheets/tableLayoutAuto.css';
import descriptors from "descriptors/providersDescriptors";
import api from 'constants/api';

const TABLE = "providers";
const ROUTE = api.providers;

const mapStateToProps = state =>
    (state.tables[TABLE] ?
        {
            ...state.tables[TABLE]
            //TODO: send server error in form from redux store
            //errors: state.tables[TABLE].errors
        } : {});

//TODO: повторяется одно и то же - вынести?
const mapDispatchToProps = (dispatch) => ({
    getDataTable: (pageIndex, pageSize, queryParams) => dispatch(getTable(pageIndex, pageSize, ROUTE, TABLE, queryParams)),
    clearTable: () => dispatch(clearTable(TABLE)),
    updateTable: (data) => dispatch(updateTable(data, TABLE)),
    changeData: (pageIndex, pageSize, method, data) => dispatch(changeData(pageIndex, pageSize, method, data, ROUTE, TABLE)),
    deleteData: (pageIndex, pageSize, data) => dispatch(deleteData(pageIndex, pageSize, data, ROUTE, TABLE)),
    setUpdatingItem: (updatingItemId) => dispatch(setUpdatingItem(updatingItemId))
});

//TODO: TableRow
export default connect(
    mapStateToProps,
    mapDispatchToProps
)(
    CreateTable({
        dataFiledsInfo: descriptors,
        title: TABLE,
        tableStyles: tableStyles,
        RowComponent: ProviderTableRow
    })
);
