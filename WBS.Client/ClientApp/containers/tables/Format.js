import { connect } from "react-redux";

import CreateTable from "factories/Table";
import ModalWindow from "../modalWindows/FormatModalWindow";
import {
    getTable,
    clearTable,
    updateTable,
    changeData,
    deleteData,
    setUpdatingItem,
    clearUpdatingItem,
    getPermissions
} from 'actions/tablesActions';
import metaData from 'constants/tablesMetaData/formatMetaData'
import api from 'constants/api';
import objectTypes from 'constants/objectTypes';
import { getTableData } from 'selectors/tableSelectors';

const TABLE = "formats";
const ROUTE = api.formats;

const mapStateToProps = state => (
    state.tables[TABLE] ?
        {
            data: getTableData(TABLE)(state),
            pagination: state.tables[TABLE].pagination || {},
            accessToCreate: state.tables[TABLE].permissions ? state.tables[TABLE].permissions.accessToCreate : false
        } : {}
);

//TODO: повторяется одно и то же - вынести?
const mapDispatchToProps = (dispatch) => ({
    getDataTable: (pageIndex, pageSize) => dispatch(getTable(pageIndex, pageSize, ROUTE, TABLE)),
    clearTable: () => dispatch(clearTable(TABLE)),
    updateTable: (data) => dispatch(updateTable(data, TABLE)),
    changeData: (pageIndex, pageSize, method, data) => dispatch(changeData(pageIndex, pageSize, method, data, ROUTE, TABLE)),
    deleteData: (pageIndex, pageSize, data) => dispatch(deleteData(pageIndex, pageSize, data, ROUTE, TABLE)),
    setUpdatingItem: (updatingItemId) => dispatch(setUpdatingItem(updatingItemId, TABLE)),
    clearUpdatingItem: () => dispatch(clearUpdatingItem(TABLE)),
    getPermissions: () => dispatch(getPermissions(TABLE, objectTypes.format))
});

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(
    CreateTable({
        metaData,
        title: TABLE,
        ChangeItemModalWindow: ModalWindow
    })
);

