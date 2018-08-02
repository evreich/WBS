import React, { Component, Fragment } from 'react';
import PropTypes from 'prop-types';

import { Link } from 'react-router-dom';

import Collapse from 'material-ui/transitions/Collapse';
import List, { ListItem, ListItemIcon, ListItemText } from 'material-ui/List';
import ExpandLess from 'material-ui-icons/ExpandLess';
import ExpandMore from 'material-ui-icons/ExpandMore';

class NavListItem extends Component {
  state = { open: false };

  handleOpen = () => {
    const { open } = this.state;
    this.setState({ open: !open });
  };

  render() {
    const { to, icon, text, children, className } = this.props;
    const { open } = this.state;
    return children ? (
      <Fragment>
        <ListItem button onClick={this.handleOpen}>
          <ListItemIcon>
            {icon}
          </ListItemIcon>
          <ListItemText inset primary={text} />
          {open ? <ExpandLess /> : <ExpandMore />}
        </ListItem>
        <Collapse in={open} timeout="auto" unmountOnExit>
          <List component="div" disablePadding>
            {children}
          </List>
        </Collapse>
      </Fragment>
    ) : (
        <ListItem
          button
          component={Link}
          to={to}
          className={className}
        >
          <ListItemIcon>
            {icon}
          </ListItemIcon>
          <ListItemText primary={text} />
        </ListItem>
      );
  }
}

NavListItem.propTypes = {
  text: PropTypes.string,
  icon: PropTypes.element.isRequired,
  to: PropTypes.oneOfType([PropTypes.string, PropTypes.object]),
  children: PropTypes.any,
  className: PropTypes.string,
};

export default NavListItem;
