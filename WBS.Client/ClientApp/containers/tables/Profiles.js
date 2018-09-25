import { connect } from "react-redux";

import CreateTable from "factories/Table";
import ModalWindow from "../modalWindows/ProfileModalWindow";
import {
    getTable,
    clearTable,
    updateTable,
    changeData,
    setUpdatingItem,
    clearUpdatingItem,
    getPermissions
} from "actions/tablesActions";
import { markOnDeleteData } from 'actions/profileActions';
import metaData from 'constants/tablesMetaData/profilesMetaData'
import api from 'constants/api';
import objectTypes from 'constants/objectTypes';
import { getProfilesTableData } from 'selectors/tableSelectors';

const TABLE = "profiles";
const ROUTE = api.profiles;
const ROUTE_MARK_ON_DELETE_PROFILE = api.markProfileForDeletion;

const mapStateToProps = state => (
    state.tables[TABLE] ?
        {
            data: getProfilesTableData(TABLE)(state),
            pagination: state.tables[TABLE].pagination || {},
            accessToCreate: state.tables[TABLE].permissions ? state.tables[TABLE].permissions.accessToCreate : false
        } : {}
);

//TODO: повторяется одно и то же - вынести?
const mapDispatchToProps = dispatch => ({
    getDataTable: (pageIndex, pageSize) => dispatch(getTable(pageIndex, pageSize, ROUTE, TABLE)),
    clearTable: () => dispatch(clearTable(TABLE)),
    updateTable: data => dispatch(updateTable(data, TABLE)),
    changeData: (pageIndex, pageSize, method, data) => dispatch(changeData(pageIndex, pageSize, method, data, ROUTE, TABLE)),
    deleteData: (pageIndex, pageSize, data) => dispatch(markOnDeleteData(pageIndex, pageSize, data, ROUTE, ROUTE_MARK_ON_DELETE_PROFILE, TABLE)),
    setUpdatingItem: (updatingItemId) => dispatch(setUpdatingItem(updatingItemId, TABLE)),
    clearUpdatingItem: () => dispatch(clearUpdatingItem(TABLE)),
    getPermissions: () => dispatch(getPermissions(TABLE, objectTypes.profile))
});

//TODO: TableRow
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
