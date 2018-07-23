import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
// import { withRouter } from 'react-router-dom';
import { withStyles } from 'material-ui/styles';
import classNames from 'classnames';
import Drawer from 'material-ui/Drawer';
import AppBar from 'material-ui/AppBar';
import Toolbar from 'material-ui/Toolbar';
import List from 'material-ui/List';
import { CardHeader } from 'material-ui/Card';
import Avatar from 'material-ui/Avatar';
import AccountBoxIcon from 'material-ui-icons/AccountBox';
import FolderIcon from 'material-ui-icons/Folder';
import DescriptionIcon from 'material-ui-icons/Description';
import InsertDriveFileIcon from 'material-ui-icons/InsertDriveFile';
import InfoOutlineIcon from 'material-ui-icons/InfoOutline';
import TrendingUpIcon from 'material-ui-icons/TrendingUp';
import RestorePageIcon from 'material-ui-icons/RestorePage'
import ChromeReaderMode from 'material-ui-icons/ChromeReaderMode';
import AssessmentIcon from 'material-ui-icons/Assessment';
import LibraryBooksIcon from 'material-ui-icons/LibraryBooks';
import AccountCircleIcon from 'material-ui-icons/AccountCircle';
import SupervisorAccountIcon from 'material-ui-icons/SupervisorAccount';
import HomeIcon from 'material-ui-icons/Home';
import Typography from 'material-ui/Typography';
import Divider from 'material-ui/Divider';
import IconButton from 'material-ui/IconButton';
import MenuIcon from 'material-ui-icons/Menu';
import ChevronLeftIcon from 'material-ui-icons/ChevronLeft';
import ExitToAppIcon from 'material-ui-icons/ExitToApp'
import NavListItem from '../NavListItem';
import styles from './SideMenuContainer.css';
import actionsCreators from '../../../reducers/Authorization';


class SideMenuContainer extends Component {
  state = {
    open: !!localStorage.getItem("drawerOpen"),
    auth: {}
  };

  logoutClick = () => {
    const { logout } = this.props
    sessionStorage.removeItem('auth')
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

    const drawer = (
      <Drawer
        variant="persistent"
        open={open}
        style={{ position: 'fixed', display: open ? 'block': 'none', marginTop: -10 }}
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
          <NavListItem
            text="Документы"
            icon={<FolderIcon />}
          >
            <NavListItem
              className={classes.nested}
              text="Таблица разработки"
              icon={<InsertDriveFileIcon />}
              to="/table"
            />
            <NavListItem
              className={classes.nested}
              text="Макет"
              icon={<InsertDriveFileIcon />}
              to="/DateRangePicker"
            />
            <NavListItem
              className={classes.nested}
              text="Заявки на инвестиции"
              icon={<InsertDriveFileIcon />}
              to="/DAIRequests"
            />
            <NavListItem
              className={classes.nested}
              text="Бюджетные планы"
              icon={<DescriptionIcon />}
              to="/BudgetPlans"
            />
            <NavListItem
              className={classes.nested}
              text="Статистика"
              icon={<TrendingUpIcon />}
              to="/Statistics"
            />
            <NavListItem
              className={classes.nested}
              text="Все обработанные мной заявки"
              icon={<RestorePageIcon />}
              to="/DAIProcessedRequests"
            />
            <NavListItem
              className={classes.nested}
              text="Инструкции"
              icon={<InfoOutlineIcon />}
              to="/DocLib"
            />
          </NavListItem>
          {
            auth.role === 'admin' &&
            <NavListItem
              text="Администрирование"
              icon={<AccountBoxIcon />}
            >
              <NavListItem
                className={classes.nested}
                text="Добавить пользователя"
                icon={<ChromeReaderMode />}
                to="/signup"
              />
              <NavListItem
                className={classes.nested}
                text="Журнал изменений"
                icon={<ChromeReaderMode />}
                to="/EventsHistory"
              />
              <NavListItem
                className={classes.nested}
                text="Проверка мониторинга системы"
                icon={<AssessmentIcon />}
                to="/CheckDAIMonitoringSystem"
              />
            </NavListItem>
          }
          <NavListItem
            text="Справочники"
            icon={<LibraryBooksIcon />}
          >
            <NavListItem
              className={classes.nested}
              text="Ситы"
              icon={<HomeIcon />}
              to="/Sits"
            />
            <NavListItem
              className={classes.nested}
              text="Пользователи"
              icon={<AccountCircleIcon />}
              to="/Profiles"
            />
            <NavListItem
              className={classes.nested}
              text="Поставщики"
              icon={<SupervisorAccountIcon />}
              to="/Vendors"
            />
            <NavListItem
              className={classes.nested}
              text="Формат ситов"
              icon={<DescriptionIcon />}
              to="/Formats"
            />
            <NavListItem
              className={classes.nested}
              text="Типы инвестиций"
              icon={<TrendingUpIcon />}
              to="/Investment"
            />
            <NavListItem
              className={classes.nested}
              text="Центры результатов"
              icon={<InsertDriveFileIcon />}
              to="/ResultCentres"
            />
            <NavListItem
              className={classes.nested}
              text="Группы категорий"
              icon={<InsertDriveFileIcon />}
              to="/CategoryGroups"
            />
            <NavListItem
              className={classes.nested}
              text="Категории оборудования"
              icon={<InsertDriveFileIcon />}
              to="/CategoriesOfEquipment"
            />

          </NavListItem>
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
                auth.access_token &&
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

SideMenuContainer.propTypes = {
  classes: PropTypes.object.isRequired,
  theme: PropTypes.object.isRequired,
  logout: PropTypes.func,
};

const mapStateToProps = state => ({ auth: state.auth });
const mapDispatchToProps = { ...actionsCreators };

export default withStyles(styles, { withTheme: true })(connect(mapStateToProps, mapDispatchToProps)((SideMenuContainer)))
