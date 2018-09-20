import { connect } from "react-redux";

import CreateTable from "factories/Table";
import {
    getTable, clearTable, updateTable, changeData, getPermissions, clearUpdatingItem } from 'actions/tablesActions';
import descriptors from "descriptors/BudgetPlanDescriptors";
import api from 'constants/api';
import TableRow from "./BudgetPlanTableRow";
import objectTypes from 'constants/objectTypes';
import ModalWindow from "../../modalWindows/BudgetPlanModalWindow";

const TABLE = "budgetPlans";
const ROUTE = api.budgetPlan;

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
    getPermissions: () => dispatch(getPermissions(TABLE, objectTypes.budgetPlan)),
    clearUpdatingItem: () => dispatch(clearUpdatingItem(TABLE))
});

const BudgetPlansContainer = connect(
        mapStateToProps,
        mapDispatchToProps
    )(
    CreateTable({
        dataFiledsInfo: descriptors,
        title: TABLE,
        RowComponent: TableRow,
        ChangeItemModalWindow: ModalWindow
        })
    );

export default BudgetPlansContainer;
