import { connect } from "react-redux";

import AuthorizationFormComponent from '../../components/AuthorizationForm/AuthorizationForm';
import { authorization } from './authorizationActions';


const mapStateToProps = state => ({ auth: state.auth });
const mapDispatchToProps = (dispatch) => ({ authorization: (login, password) => dispatch(authorization(login, password)) });

export default connect(mapStateToProps, mapDispatchToProps)(AuthorizationFormComponent);

