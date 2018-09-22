import { connect } from "react-redux";

import CreateTable from "factories/Table";
import ModalWindow from "../modalWindows/ProviderModalWindow";
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
import { tableStyles } from 'stylesheets/tableLayoutAuto.css';
import metaData from 'constants/tablesMetaData/providersMetaData'
import api from 'constants/api';
import objectTypes from 'constants/objectTypes';
import { getProvidersTableData } from 'selectors/tableSelectors';

const TABLE = "providers";
const ROUTE = api.providers;

const mapStateToProps = state => (
    state.tables[TABLE] ?
        {
            data: getProvidersTableData(TABLE)(state),
            pagination: state.tables[TABLE].pagination || {},
            accessToCreate: state.tables[TABLE].permissions ? state.tables[TABLE].permissions.accessToCreate : false
        } : {}
);

//TODO: повторяется одно и то же - вынести?
const mapDispatchToProps = (dispatch) => ({
    getDataTable: (pageIndex, pageSize, queryParams) => dispatch(getTable(pageIndex, pageSize, ROUTE, TABLE, queryParams)),
    clearTable: () => dispatch(clearTable(TABLE)),
    updateTable: (data) => dispatch(updateTable(data, TABLE)),
    changeData: (pageIndex, pageSize, method, data) => dispatch(changeData(pageIndex, pageSize, method, data, ROUTE, TABLE)),
    deleteData: (pageIndex, pageSize, data) => dispatch(deleteData(pageIndex, pageSize, data, ROUTE, TABLE)),
    setUpdatingItem: (updatingItemId) => dispatch(setUpdatingItem(updatingItemId, TABLE)),
    clearUpdatingItem: () => dispatch(clearUpdatingItem(TABLE)),
    getPermissions: () => dispatch(getPermissions(TABLE, objectTypes.provider))
});

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(
    CreateTable({
        metaData,
        title: TABLE,
        tableStyles: tableStyles,
        ChangeItemModalWindow: ModalWindow
    })
);
