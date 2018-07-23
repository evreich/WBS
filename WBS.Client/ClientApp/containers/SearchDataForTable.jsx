import { connect } from "react-redux";
import selectActionCreators from "../../reducers/helpers";
import { styles } from "../Commons/Table/TableStyles.css";
import { withStyles } from "material-ui/styles";
import SearchDataForTable from "../components/DetalizationOfSite/SearchDataForTable";

const mapStateToProps = state => ({
    resultCentres: state.helpers.resultCentres,
    typesOfInvestment: state.helpers.typesOfInvestment,
    categories: state.helpers.groupsOfCategories
});

const mapDispatchToProps = {
    ...selectActionCreators
};

export default withStyles(styles)(
    connect(
        mapStateToProps,
        mapDispatchToProps
    )(SearchDataForTable)
);
