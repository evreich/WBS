import React, { Component } from 'react';
import PropTypes from 'prop-types';

import icons from './AvailableIcons';
import { withStyles } from '@material-ui/core/styles';
import classNames from 'classnames';
import Drawer from '@material-ui/core/Drawer';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import List from '@material-ui/core/List';
import CardHeader from '@material-ui/core/CardHeader';
import Avatar from '@material-ui/core/Avatar';
import Typography from '@material-ui/core/Typography';
import Divider from '@material-ui/core/Divider';
import IconButton from '@material-ui/core/IconButton';
import MenuIcon from '@material-ui/icons/Menu';
import ChevronLeftIcon from '@material-ui/icons/ChevronLeft';
import ExitToAppIcon from '@material-ui/icons/ExitToApp'

import NavListItem from '../NavListItem';
import styles from './SideMenu.css.js';

class SideMenu extends Component {
    state = {
        open: !!localStorage.getItem("drawerOpen"),
        auth: {}
    };

    logoutClick = () => {
        const { logout } = this.props
        localStorage.removeItem('auth')
        localStorage.removeItem("drawerOpen");
        this.setState({ open: false });
        logout()
    }

    static getDerivedStateFromProps(nextProps) {
        return {
            auth: nextProps.auth,
        };
    }

    handleDrawerOpen = () => {
        this.setState({ open: true });
        localStorage.setItem("drawerOpen", "true");
    };

    handleDrawerClose = () => {
        this.setState({ open: false });
        localStorage.removeItem("drawerOpen");
    };

    render() {
        const { classes } = this.props;
        const { open, auth = {} } = this.state;

        const menuItems = auth.availableMenuItems || [];

        const renderMenuItem = (item) => {
            if (item) {
                const Icon = icons[item.iconName];
                if (item.children && item.children.length > 0) {
                    return <NavListItem key={item.id} text={item.text} icon={<Icon />}>
                        {renderMenuItems(item.children)}
                    </NavListItem>
                }
                else {
                    return <NavListItem key={item.id} text={item.text} to={item.to} icon={<Icon />} className={item.parentId ? classes.nested : ''} />
                }
            }
        }
        const renderMenuItems = (items) => items.map(item => renderMenuItem(item));

        const renderedMenu = renderMenuItems(menuItems);

        const drawer = (
            <Drawer
                variant="persistent"
                open={open}
                onClose={this.handleDrawerClose}
                style={{ position: 'fixed', display: open ? 'block' : 'none', marginTop: -10 }}
                classes={{
                    paper: classes.drawerPaper,
                }}
            >
                <div className={classes.drawerHeader}>
                    <CardHeader
                        avatar={
                            <Avatar aria-label="User" className={classes.avatar}>
                                N
                            </Avatar>
                        }
                        title={<strong>{auth.username}</strong>}
                        subheader={<strong>{auth.role}</strong>}
                    />
                    <IconButton onClick={this.logoutClick}>
                        <ExitToAppIcon />
                    </IconButton>
                    <IconButton onClick={this.handleDrawerClose}>
                        <ChevronLeftIcon />
                    </IconButton>
                </div>
                <Divider />
                <List component="nav">
                    {renderedMenu}
                </List>
            </Drawer>
        );

        return (
            <div className={classes.root}>
                <div className={classes.appFrame}>
                    <AppBar
                        position="fixed"
                        style={{ position: 'fixed' }}
                        className={classNames(classes.appBar, {
                            [classes.appBarShift]: open,
                        })}
                    >
                        <Toolbar>
                            {
                                auth.accessToken &&
                                (<>
                                    <IconButton
                                        color="inherit"
                                        aria-label="open drawer"
                                        onClick={this.handleDrawerOpen}
                                        className={classNames(classes.menuButton, open && classes.hide)}
                                    >
                                        <MenuIcon />
                                    </IconButton>
                                    <Typography variant="title" color="inherit" noWrap style={{ flex: 1 }} />

                                </>)
                            }
                        </Toolbar>
                    </AppBar>
                    {drawer}
                    <div className={classNames(classes.content, { [classes.contentShift]: open, })}
                    />
                </div>
            </div>
        );
    }
}

SideMenu.propTypes = {
    classes: PropTypes.object.isRequired,
    logout: PropTypes.func,
};

export default withStyles(styles, { withTheme: true })(SideMenu);
