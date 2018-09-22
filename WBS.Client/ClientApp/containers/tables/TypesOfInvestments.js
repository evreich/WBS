import { connect } from "react-redux";

import CreateTable from "factories/Table";
import ModalWindow from "../modalWindows/TypeOfInvestmentsModalWindow";
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
import metaData from 'constants/tablesMetaData/typesOfInvestmentMetaData'
import api from 'constants/api';
import objectTypes from 'constants/objectTypes';
import { getTableData } from 'selectors/tableSelectors';

const TABLE = "typesOfInvestments";
const ROUTE = api.typesOfInvestments;

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
    getPermissions: () => dispatch(getPermissions(TABLE, objectTypes.typeOfInvestment))
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