import React, { Component } from 'react';
import PropTypes from 'prop-types';

import { withStyles } from '@material-ui/core/styles';
import { DatePicker } from 'material-ui-pickers';
import KeyboardArrowLeft from '@material-ui/icons/KeyboardArrowLeft'
import KeyboardArrowRight from '@material-ui/icons/KeyboardArrowRight'
import styles from './DateRangePicker.css';

class DateRangePicker extends Component {
  constructor(props) {
    super(props);

    this.updateFrom = this.updateFrom.bind(this);
    this.updateTo = this.updateTo.bind(this);

    this.state = {
      from: null,
      to: null,
    }
  }

  updateFrom(val) {
    this.setState({ from: val });
  }

  updateTo(val) {
    this.setState({ to: val });
  }

  render() {
    const { classes, label } = this.props;
    const { from, to } = this.state;
    return (
      <div className={classes.root}>
        <DatePicker
          clearable
          value={from}
          onChange={this.updateFrom}
          placeholder="Начало"
          label={label}
          animateYearScrolling
          leftArrowIcon={<KeyboardArrowLeft />}
          rightArrowIcon={<KeyboardArrowRight />}
          cancelLabel="Закрыть"
          clearLabel="Очистить"
          format="DD.MM.YYYY"
          InputLabelProps={{
            shrink: true,
          }}
        />
        <DatePicker
          clearable
          value={to}
          onChange={this.updateTo}
          placeholder="Конец"
          animateYearScrolling
          leftArrowIcon={<KeyboardArrowLeft />}
          rightArrowIcon={<KeyboardArrowRight />}
          cancelLabel="Закрыть"
          clearLabel="Очистить"
          format="DD.MM.YYYY"
        />
      </div>
    );
  }
}

DateRangePicker.propTypes = {
  classes: PropTypes.object.isRequired,
  label: PropTypes.string,
};

export default withStyles(styles)(DateRangePicker);
