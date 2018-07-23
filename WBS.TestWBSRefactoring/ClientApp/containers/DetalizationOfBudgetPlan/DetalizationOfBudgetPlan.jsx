import { connect } from "react-redux";
import actionsCreators from "../../reducers/helpers";
import { styles } from "./DetalizationOfBudgetPlan.css";
import { withStyles } from "material-ui/styles";
import DetalizationOfBudgetPlan from "../../components/DetalizationOfBudgetPlan";

const mapStateToProps = state => ({ sits: state.helpers.sits });
const mapDispatchToProps = { ...actionsCreators };

export default withStyles(styles)(
    connect(
        mapStateToProps,
        mapDispatchToProps
    )(DetalizationOfBudgetPlan)
);
