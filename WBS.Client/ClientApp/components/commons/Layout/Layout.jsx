import React from 'react';
import { connect } from 'react-redux';
import { push } from 'react-router-redux';
import PropTypes from "prop-types";

import MuiThemeProvider from '@material-ui/core/styles/MuiThemeProvider';
import MuiPickersUtilsProvider from 'material-ui-pickers/utils/MuiPickersUtilsProvider';
import DateFnsUtils from 'material-ui-pickers/utils/date-fns-utils';
import ruLocale from 'date-fns/locale/ru';

import muiTheme from 'muiTheme';
import SideMenuContainer from 'containers/SideMenuContainer/SideMenuContainer';
import authPropType from "propTypes/auth";
import routingPropType from "propTypes/routing";

const Layout = ({ pushToHome, children, routing, auth }) => {
    let targetRoute = routing.location.pathname;
    const customPush = route => (route !== targetRoute ? push(route) : null);
    if (!auth.accessToken || !auth.refreshToken) {
        localStorage.removeItem("drawerOpen") // для управления выезжающим меню, чтобы его не было видно при logout-е
        targetRoute !== '/' ? pushToHome() : null;
    } else if (auth.privateRoutes) {
        if (auth.privateRoutes.indexOf(targetRoute) !== -1) {
            localStorage.removeItem("drawerOpen")// для управления выезжающим меню, чтобы его не было видно при logout-е
            customPush('/');
        }
    }
    return (
        <MuiThemeProvider theme={muiTheme}> {/* Применяем тему для всех вложенных компонентов */}
            <MuiPickersUtilsProvider
             utils={DateFnsUtils}
                locale={ruLocale}
            >
                <>
                    <SideMenuContainer auth={auth} />
                    {children}
                </>
            </MuiPickersUtilsProvider>
        </MuiThemeProvider>
    );
}

Layout.propTypes = {
    children: PropTypes.array,
    routing: routingPropType,
    auth: authPropType,
    pushToHome: PropTypes.func,
}

const mapDispatchToProps = (dispatch) => ({ pushToHome: () => dispatch(push('/'))});

const mapStateToProps = state => ({
    routing: state.routing,
    auth: state.auth,
});

export default connect(mapStateToProps, mapDispatchToProps)(Layout);
