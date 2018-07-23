import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';
import { withStyles } from 'material-ui/styles';
import AppBar from 'material-ui/AppBar';
import Toolbar from 'material-ui/Toolbar';
import Typography from 'material-ui/Typography';
import Button from 'material-ui/Button';
import actionsCreators from '../../reducers/Authorization';
import styles from './Header.css.js'

class Header extends Component {
    constructor() {
        super()
        this.state = {
            auth: {},
        }
    }

    logoutClick = () => {
        const { logout } = this.props
        sessionStorage.removeItem('auth')
        logout()
    }
    static getDerivedStateFromProps(nextProps) {
        return {
            auth: nextProps.auth,
        };
    }

    render() {
        const { auth = {} } = this.state;
        const { classes } = this.props;
        return (
            <div className={classes.root}>
                <AppBar position="static" color="primary" >
                    <Toolbar className={classes.toolbar}>
                        <Typography variant="title" color="inherit" className={classes.flex}>Title</Typography>
                        <div>
                            {
                                auth.role === 'admin' &&
                                <Button color="inherit" component={Link} to="/signup">SignUp</Button>
                            }
                            {
                                auth.access_token &&
                                (<>
                                    &nbsp;<span className={classes.currentLogin}>{auth.username}</span>&nbsp;
                                    < Button color="inherit" onClick={this.logoutClick}>Logout</Button>
                                </>)
                            }
                        </div>
                    </Toolbar>
                </AppBar >
            </div >
        );
    }
}

Header.propTypes = {
    classes: PropTypes.object.isRequired,
    logout: PropTypes.func,
};

const mapStateToProps = state => ({ auth: state.auth });
const mapDispatchToProps = { ...actionsCreators };

export default withStyles(styles)(connect(mapStateToProps, mapDispatchToProps)(Header));