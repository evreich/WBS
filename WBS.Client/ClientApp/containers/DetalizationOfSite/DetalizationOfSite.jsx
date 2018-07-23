import { connect } from "react-redux";
import actionsCreators from "../../reducers/DetalizationOfBudgetPlans";
import selectActionCreators from "../../reducers/helpers";
import CreateTable from "../../components/Commons/Table";

const mapStateToProps = state => ({
    itemsOfBudgetPlan: state.budgetPlans.detalizationOfSelectedBP
});

const mapDispatchToProps = {
    ...actionsCreators,
    ...selectActionCreators
};

const DetalizationOfSiteContainer = (dataFields, DialogBody) =>
    connect(
        mapStateToProps,
        mapDispatchToProps
    )(
        CreateTable({
            dataFiledsInfo: dataFields,
            DialogBodyComponent: DialogBody
        })
    );

export default DetalizationOfSiteContainer;
