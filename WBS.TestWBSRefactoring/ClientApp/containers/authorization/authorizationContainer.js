import { connect } from "react-redux";

import AuthorizationFormComponent from '../../components/AuthorizationForm/AuthorizationForm';
import { getToken } from './authorizationActions';


const mapStateToProps = state => ({ auth: state.auth });
const mapDispatchToProps = (dispatch) => ({ getToken: (data) => dispatch(getToken(data)) });

export default connect(mapStateToProps, mapDispatchToProps)(AuthorizationFormComponent);

