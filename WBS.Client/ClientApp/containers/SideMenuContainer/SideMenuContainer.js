import { connect } from "react-redux";

import { logout } from 'actions/authorizationActions';

import SideMenu from 'components/commons/SideMenu';

const mapDispatchToProps = (dispatch) => ({ logout: () => dispatch(logout()) });

export default connect(null, mapDispatchToProps)((SideMenu))