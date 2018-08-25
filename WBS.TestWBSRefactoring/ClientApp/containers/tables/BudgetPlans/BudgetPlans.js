import { connect } from "react-redux";

import CreateTable from "components/Commons/Table";
import { getTable, clearTable, updateTable, changeData } from '../tablesActions';

const TABLE = "budgetPlans";
const ROUTE = document.api.budgetPlan;

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
});

const BudgetPlansContainer = (
    dataFields,
    DialogBody,
    TableRow,
    InformationModalWindow
) =>
    connect(
        mapStateToProps,
        mapDispatchToProps
    )(
        CreateTable({
            dataFiledsInfo: dataFields,
            AddItemDialogBodyComponent: DialogBody,
            ChangeItemDialogBodyComponent: DialogBody,
            RowComponent: TableRow,
            InformationModalWindow,
            isNeedFillEmptyRow: false,
            isNeedTableFooter: false
        })
    );

export default BudgetPlansContainer;
