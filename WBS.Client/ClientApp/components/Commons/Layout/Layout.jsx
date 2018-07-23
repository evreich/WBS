import React from 'react';
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';
import { connect } from 'react-redux';
import MuiPickersUtilsProvider from 'material-ui-pickers/utils/MuiPickersUtilsProvider';
import DateFnsUtils from 'material-ui-pickers/utils/date-fns-utils';
import ruLocale from 'date-fns/locale/ru';
import muiTheme from '../../../muiTheme';
import PropTypes from "prop-types";
import SideMenuContainer from '../SideMenuContainer';
import { push } from 'react-router-redux';


const Layout = ({ children, routing, auth }) => {
    let targetRoute = routing.location.pathname;
    const customPush = route => (route !== targetRoute ? push(route) : null);
    if (!auth || !auth.access_token || !auth.refresh_token) {
        localStorage.removeItem("drawerOpen") // для управления выезжающим меню, чтобы его небыло видно при logout-е
        customPush('/');
    } else if (auth.privateRoutes) {
        if (auth.privateRoutes.indexOf(targetRoute) !== -1) {
            localStorage.removeItem("drawerOpen")// для управления выезжающим меню, чтобы его небыло видно при logout-е
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
                    <SideMenuContainer />
                    {children}
                </>
            </MuiPickersUtilsProvider>
        </MuiThemeProvider>
    );
}

Layout.propTypes = {
    children: PropTypes.array,
    routing: PropTypes.object,
    auth: PropTypes.object,
    push: PropTypes.func,
}

const mapStateToProps = state => ({
    routing: state.routing,
    auth: state.auth,
});

export default connect(mapStateToProps)(Layout);
