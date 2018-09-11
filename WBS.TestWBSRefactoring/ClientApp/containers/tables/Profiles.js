import { connect } from "react-redux";

import CreateTable from "factories/Table";
import ProfileTableRow from "components/tableRows/ProfileTableRow";
import {
    getTable,
    clearTable,
    updateTable,
    changeData,
    setUpdatingItem,
    clearUpdatingItem
} from "actions/tablesActions";
import { markOnDeleteData } from 'actions/profileActions';
import descriptors from "descriptors/profilesDescriptors";
import api from 'constants/api';

const TABLE = "profiles";
const ROUTE = api.profiles;
const ROUTE_MARK_ON_DELETE_PROFILE = api.markProfileForDeletion;

const mapStateToProps = state => {
    const props = (state.tables[TABLE] ?
        {
            ...state.tables[TABLE],
            //TODO: send server error in form from redux store
            //errors: state.tables[TABLE].errors
        } : {});
    if (state.tables[TABLE] && state.tables[TABLE].updatingItem)
        props.modalFormInitialValues = state.tables[TABLE].data
            .find((item) => item.id === state.tables[TABLE].updatingItem)
    return props;
}

//TODO: повторяется одно и то же - вынести?
const mapDispatchToProps = dispatch => ({
    getDataTable: (pageIndex, pageSize) => dispatch(getTable(pageIndex, pageSize, ROUTE, TABLE)),
    clearTable: () => dispatch(clearTable(TABLE)),
    updateTable: data => dispatch(updateTable(data, TABLE)),
    changeData: (pageIndex, pageSize, method, data) => dispatch(changeData(pageIndex, pageSize, method, data, ROUTE, TABLE)),
    deleteData: (pageIndex, pageSize, data) => dispatch(markOnDeleteData(pageIndex, pageSize, data, ROUTE, ROUTE_MARK_ON_DELETE_PROFILE, TABLE)),
    setUpdatingItem: (updatingItemId) => dispatch(setUpdatingItem(updatingItemId, TABLE)),
    clearUpdatingItem: () => dispatch(clearUpdatingItem(TABLE))
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
