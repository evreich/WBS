import { connect } from "react-redux";

import { logout } from '../authorization/authorizationActions';

import SideMenuComponent from '../../components/Commons/SideMenuContainer';

const mapDispatchToProps = (dispatch) => ({ logout: () => dispatch(logout()) }) ;

export default connect(null, mapDispatchToProps)((SideMenuComponent))