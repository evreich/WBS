import { connect } from "react-redux";
import actionsCreators from "../reducers/BudgetPlans";
import CreateTable from "../components/Commons/Table";

const mapStateToProps = state => state.budgetPlans;

const mapDispatchToProps = {
    ...actionsCreators
};

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
            DialogBodyComponent: DialogBody,
            RowComponent: TableRow,
            InformationModalWindow,
            isNeedFillEmptyRow: false,
            isNeedTableFooter: false
        })
    );

export default BudgetPlansContainer;
