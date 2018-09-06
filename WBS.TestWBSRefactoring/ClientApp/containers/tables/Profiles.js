import { connect } from "react-redux";

import CreateTable from "generators/Table";
import ProfileTableRow from "components/tableRows/ProfileTableRow";
import {
    getTable,
    clearTable,
    updateTable,
    changeData,
    setUpdatingItem
} from "actions/tablesActions";
import { markOnDeleteData } from 'actions/profileActions';
import descriptors from "descriptors/profilesDescriptors";

const TABLE = "profiles";
const ROUTE = document.api.profiles;
const ROUTE_MARK_ON_DELETE_PROFILE = document.api.markProfileForDeletion;

const mapStateToProps = state =>
    (state.tables[TABLE]
        ? {
            ...state.tables[TABLE]
            //TODO: send server error in form from redux store
            //errors: state.tables[TABLE].errors
        }
        : {});

//TODO: повторяется одно и то же - вынести?
const mapDispatchToProps = dispatch => ({
    getDataTable: (pageIndex, pageSize) => dispatch(getTable(pageIndex, pageSize, ROUTE, TABLE)),
    clearTable: () => dispatch(clearTable(TABLE)),
    updateTable: data => dispatch(updateTable(data, TABLE)),
    changeData: (pageIndex, pageSize, method, data) => dispatch(changeData(pageIndex, pageSize, method, data, ROUTE, TABLE)),
    deleteData: (pageIndex, pageSize, data) => dispatch(markOnDeleteData(pageIndex, pageSize, data, ROUTE, ROUTE_MARK_ON_DELETE_PROFILE, TABLE)),
    setUpdatingItem: (updatingItemId) => dispatch(setUpdatingItem(updatingItemId))
});

//TODO: TableRow
export default connect(
    mapStateToProps,
    mapDispatchToProps
)(
    CreateTable({
        dataFiledsInfo: descriptors,
        RowComponent: ProfileTableRow,
        title: TABLE
    })
);
