﻿import { connect } from "react-redux";

import CreateTable from "factories/Table";
import ModalWindow from "../modalWindows/RequestModalWindow/RequestModalWindow";
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
import descriptors from "descriptors/newRequestsDescriptors";
import api from 'constants/api';
import objectTypes from 'constants/objectTypes';

const TABLE = "newRequests";
const ROUTE = api.newRequests;

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
const mapDispatchToProps = (dispatch) => ({
    getDataTable: (pageIndex, pageSize) => dispatch(getTable(pageIndex, pageSize, ROUTE, TABLE)),
    clearTable: () => dispatch(clearTable(TABLE)),
    updateTable: (data) => dispatch(updateTable(data, TABLE)),
    changeData: (pageIndex, pageSize, method, data) => dispatch(changeData(pageIndex, pageSize, method, data, ROUTE, TABLE)),
    deleteData: (pageIndex, pageSize, data) => dispatch(deleteData(pageIndex, pageSize, data, ROUTE, TABLE)),
    setUpdatingItem: (updatingItemId) => dispatch(setUpdatingItem(updatingItemId, TABLE)),
    clearUpdatingItem: () => dispatch(clearUpdatingItem(TABLE)),
    getPermissions: () => dispatch(getPermissions(TABLE, objectTypes.daiRequest))
});

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(
    CreateTable({
        dataFiledsInfo: descriptors,
        title: TABLE,
        ChangeItemModalWindow: ModalWindow
    })
    );

