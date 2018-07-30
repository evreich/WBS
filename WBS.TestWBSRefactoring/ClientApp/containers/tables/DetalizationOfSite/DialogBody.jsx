import { connect } from "react-redux";
import DetalizationOfSiteDialogBody from '../../components/DetalizationOfSite/DetalizationOfSiteDialogBody'
import actionCreators from "../../reducers/helpers"; 

const mapDispatchFromProps = { ...actionCreators };

const mapStateToProps = state => ({
    errors: state.monolithic.errors,
    resultCentres: state.helpers.resultCentres,
    typesOfInvestment: state.helpers.typesOfInvestment,
    categories: state.helpers.groupsOfCategories
});

export default connect(
    mapStateToProps,
    mapDispatchFromProps
)(DetalizationOfSiteDialogBody);
