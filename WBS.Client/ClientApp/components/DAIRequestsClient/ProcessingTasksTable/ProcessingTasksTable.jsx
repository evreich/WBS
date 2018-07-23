import React, { Component } from 'react';
import classNames from 'classnames';
import PropTypes from 'prop-types';
import { withStyles } from 'material-ui/styles';
import Table, {
  TableBody,
  TableCell,
  TableFooter,
  TableHead,
  TablePagination,
  TableRow,
  TableSortLabel,
} from 'material-ui/Table';
import Dialog, {
  DialogActions,
  DialogContent,
  DialogTitle,
} from 'material-ui/Dialog';
import TextField from 'material-ui/TextField';
import { MenuItem } from 'material-ui/Menu';
import InsertDriveFileIcon from 'material-ui-icons/InsertDriveFile'
import RefreshIcon from 'material-ui-icons/Refresh';
import IconButton from 'material-ui/IconButton';
import Toolbar from 'material-ui/Toolbar';
import Typography from 'material-ui/Typography';
import Zoom from 'material-ui/transitions/Zoom';
import Paper from 'material-ui/Paper';
import Button from 'material-ui/Button';
import Tooltip from 'material-ui/Tooltip';
import FilterListIcon from 'material-ui-icons/FilterList';
import DateRangePicker from '../../Commons/DateRangePicker';
import { styles, toolbarStyles } from '../TableStyles.css';

let counter = 0;
function createData(number, siteName, date, processingTime, currentStage, protocol, extracted, delegated) {
  counter += 1;
  return { id: counter, number, siteName, date, processingTime, currentStage, protocol, extracted, delegated };
}
function Transition(props) {
  return <Zoom timeout={{ enter: 10, exit: 300 }} {...props} />;
}

const columnData = [
  { id: 'number', numeric: false, disablePadding: false, label: 'Номер заявки' },
  { id: 'siteName', numeric: false, disablePadding: false, label: 'Название сита' },
  { id: 'date', numeric: false, disablePadding: true, label: 'Дата поступления задачи' },
  { id: 'processingTime', numeric: false, disablePadding: true, label: 'Срок обработки задачи' },
  { id: 'currentStage', numeric: false, disablePadding: false, label: 'Текущий этап' },
  { id: 'protocol', numeric: false, disablePadding: true, label: 'Протокол обработки заявки' },
  { id: 'extracted', numeric: false, disablePadding: true, label: 'Кем извлечено' },
  { id: 'delegated', numeric: false, disablePadding: true, label: 'Делегировано' },
];

class TableHeader extends Component {
  createSortHandler = property => event => {
    this.props.onRequestSort(event, property);
  };

  render() {
    const { order, orderBy, rowClassName, cellClassName } = this.props;

    return (
      <TableHead>
        <TableRow className={rowClassName}>
          {columnData.map(column =>
            <TableCell
              key={column.id}
              className={cellClassName}
              sortDirection={orderBy === column.id ? order : false}
            >
              <Tooltip
                title="Sort"
                placement={column.numeric ? 'bottom-end' : 'bottom-start'}
                enterDelay={300}
              >
                <TableSortLabel
                  active={orderBy === column.id}
                  direction={order}
                  onClick={this.createSortHandler(column.id)}
                >
                  {column.label}
                </TableSortLabel>
              </Tooltip>
            </TableCell>, this)}
        </TableRow>
      </TableHead>
    );
  }
}

TableHeader.propTypes = {
  numSelected: PropTypes.number.isRequired,
  onRequestSort: PropTypes.func.isRequired,
  order: PropTypes.string.isRequired,
  orderBy: PropTypes.string.isRequired,
  rowCount: PropTypes.number.isRequired,
  cellClassName: PropTypes.string,
  rowClassName: PropTypes.string,
};

let TableToolbar = props => {
  const { numSelected, classes, onOpen } = props;

  return (
    <Toolbar
      className={classNames(classes.root, {
        [classes.highlight]: numSelected > 0,
      })}
    >
      <div className={classes.title}>
        <Typography variant="title">Список моих задач по обработке заявок</Typography>
        <IconButton color="secondary" className={classes.button} aria-label="Refresh">
          <RefreshIcon />
        </IconButton>
      </div>
      <div className={classes.spacer} />
      <div className={classes.actions}>
        <Tooltip title="Filter list">
          <Button variant="flat" size="small" onClick={onOpen} style={{ marginRight: 10 }} color="secondary" aria-label="Create new">
            Фильтры&nbsp;
            <FilterListIcon />
          </Button>
        </Tooltip>
      </div>
    </Toolbar>
  );
};

TableToolbar.propTypes = {
  classes: PropTypes.object.isRequired,
  numSelected: PropTypes.number.isRequired,
  onOpen: PropTypes.func.isRequired,
};

TableToolbar = withStyles(toolbarStyles)(TableToolbar);



class ProcessingTasksTable extends React.Component {
  constructor(props, context) {
    super(props, context);

    this.state = {
      order: 'asc',
      open: false,
      orderBy: 'date',
      selected: [],
      data: [
        createData('0001-18-026', '07.03.2018 11:52:13', 'Mytishi', '-', 'Согласование КУ сита', '', '', ''),
        createData('0001-18-023', '07.03.2018 11:52:13', 'Mytishi', '-', 'Обработка технической службой (IT)', '', '', ''),
        createData('0001-18-024', '07.03.2018 11:52:13', 'Mytishi', '-', 'Обработка технической службой (IT)', '', '', ''),
        createData('0001-18-026', '07.03.2018 11:52:13', 'Mytishi', '-', 'Согласование КУ сита', '', '', ''),
        createData('0001-18-023', '07.03.2018 11:52:13', 'Mytishi', '-', 'Обработка технической службой (IT)', '', '', ''),
        createData('0001-18-024', '07.03.2018 11:52:13', 'Mytishi', '-', 'Обработка технической службой (IT)', '', '', ''),
        createData('0001-18-026', '07.03.2018 11:52:13', 'Mytishi', '-', 'Согласование КУ сита', '', '', ''),
        createData('0001-18-023', '07.03.2018 11:52:12', 'Mytishi', '-', 'Обработка технической службой (IT)', '', '', ''),
        createData('0001-18-024', '07.03.2018 11:52:13', 'Mytishi', '-', 'Обработка технической службой (IT)', '', '', ''),
        createData('0001-18-026', '07.03.2018 11:52:13', 'Mytishi', '-', 'Согласование КУ сита', '', '', ''),
        createData('0001-18-023', '07.03.2018 11:52:12', 'Mytishi', '-', 'Обработка технической службой (IT)', '', '', ''),
        createData('0001-18-024', '07.03.2018 11:52:13', 'Mytishi', '-', 'Обработка технической службой (IT)', '', '', ''),
        createData('0001-18-026', '07.03.2018 11:52:13', 'Mytishi', '-', 'Согласование КУ сита', '', '', ''),
        createData('0001-18-023', '07.03.2018 11:52:13', 'Mytishi', '-', 'Обработка технической службой (IT)', '', '', ''),
        createData('0001-18-024', '07.03.2018 11:52:13', 'Mytishi', '-', 'Обработка технической службой (IT)', '', '', ''),
        createData('0001-18-026', '07.03.2018 11:52:13', 'Mytishi', '-', 'Согласование КУ сита', '', '', ''),
        createData('0001-18-023', '07.03.2018 11:52:13', 'Mytishi', '-', 'Обработка технической службой (IT)', '', '', ''),
        createData('0001-18-024', '07.03.2018 11:52:13', 'Mytishi', '-', 'Обработка технической службой (IT)', '', '', ''),
        createData('0001-18-026', '07.03.2018 11:52:12', 'Mytishi', '-', 'Согласование КУ сита', '', '', ''),
        createData('0001-18-023', '07.03.2018 11:52:13', 'Mytishi', '-', 'Обработка технической службой (IT)', '', '', ''),
        createData('0001-18-024', '07.03.2018 11:52:13', 'Mytishi', '-', 'Обработка технической службой (IT)', '', '', ''),
        createData('0001-18-026', '07.03.2018 11:52:13', 'Mytishi', '-', 'Согласование КУ сита', '', '', ''),
        createData('0001-18-023', '07.03.2018 11:52:13', 'Mytishi', '-', 'Обработка технической службой (IT)', '', '', ''),
        createData('0001-18-024', '07.03.2018 11:52:13', 'Mytishi', '-', 'Обработка технической службой (IT)', '', '', ''),
        createData('0001-18-026', '07.03.2018 11:52:13', 'Mytishi', '-', 'Согласование КУ сита', '', '', ''),
        createData('0001-18-023', '07.03.2018 11:52:13', 'Mytishi', '-', 'Обработка технической службой (IT)', '', '', ''),
        createData('0001-18-024', '07.03.2018 11:52:13', 'Mytishi', '-', 'Обработка технической службой (IT)', '', '', ''),
      ].sort((a, b) => (a.date < b.date ? -1 : 1)),
      page: 0,
      rowsPerPage: 10,
    };
  }

  handleRequestSort = (event, property) => {
    const { data, orderBy, order } = this.state;
    const handleOrderBy = property;
    let handleOrder = 'desc';

    if (orderBy === property && order === 'desc') {
      handleOrder = 'asc';
    }

    const newData =
      handleOrder === 'desc'
        ? data.sort((a, b) => (b[handleOrderBy] < a[handleOrderBy] ? -1 : 1))
        : data.sort((a, b) => (a[handleOrderBy] < b[handleOrderBy] ? -1 : 1));

    this.setState({ data: newData, handleOrder, handleOrderBy });
  };

  handleChangePage = (event, page) => {
    this.setState({ page });
  };

  handleChangeRowsPerPage = event => {
    this.setState({ rowsPerPage: event.target.value });
  };

  handleClickOpen = () => {
    this.setState({ open: true });
  };

  handleClose = () => {
    this.setState({ open: false });
  };

  isSelected = id => this.state.selected.indexOf(id) !== -1;

  render() {
    const { classes } = this.props;
    const { data, order, orderBy, selected, rowsPerPage, page } = this.state;
    const emptyRows = rowsPerPage - Math.min(rowsPerPage, data.length - page * rowsPerPage);

    return (
      <Paper className={classes.root}>
        <TableToolbar onOpen={this.handleClickOpen} numSelected={selected.length} />
        <div className={classes.tableWrapper}>
          <Table className={classes.table}>
            <TableHeader
              rowClassName={classes.header}
              cellClassName={classes.cell}
              numSelected={selected.length}
              order={order}
              orderBy={orderBy}
              onRequestSort={this.handleRequestSort}
              rowCount={data.length}
            />
            <TableBody>
              {data.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage).map(n =>
                <TableRow
                  className={classes.rowHover}
                  key={n.id}
                >
                  <TableCell className={classes.cell}>{n.number}</TableCell>
                  <TableCell className={classes.cell}>{n.siteName}</TableCell>
                  <TableCell className={classes.cell}>{n.date}</TableCell>
                  <TableCell className={classes.cell}>{n.processingTime}</TableCell>
                  <TableCell className={classes.cell}>{n.currentStage}</TableCell>
                  <TableCell className={classes.cell}><InsertDriveFileIcon /></TableCell>
                  <TableCell className={classes.cell}>{n.extracted}</TableCell>
                  <TableCell className={classes.cell}>{n.delegated}</TableCell>
                </TableRow>
              )}
              {emptyRows > 0 && (
                <TableRow style={{ height: 49 * emptyRows }}>
                  <TableCell colSpan={6} />
                </TableRow>
              )}
            </TableBody>
            <TableFooter>
              <TableRow>
                <TablePagination
                  colSpan={8}
                  count={data.length}
                  rowsPerPage={rowsPerPage}
                  page={page}
                  labelRowsPerPage="Показывать на странице:"
                  labelDisplayedRows={({ from, to, count }) => `${from}-${to} из ${count}`}
                  backIconButtonProps={{
                    'aria-label': 'Предыдущая страница',
                  }}
                  nextIconButtonProps={{
                    'aria-label': 'Следующая страница',
                  }}
                  onChangePage={this.handleChangePage}
                  onChangeRowsPerPage={this.handleChangeRowsPerPage}
                />
              </TableRow>
            </TableFooter>
          </Table>
          <Dialog
            open={this.state.open}
            onClose={this.handleClose}
            transition={Transition}
            aria-labelledby="form-dialog-title"
            maxWidth={false}
          >
            <DialogTitle id="form-dialog-title">
              <div style={{ display: 'flex', justifyContent: 'space-between' }}>
                <div style={{ marginTop: 5 }}>
                  Фильтры
              </div>
                <Button style={{color: 'green'}}>
                  Очистить
              </Button>
              </div>
            </DialogTitle>
            <DialogContent>
              <div className={classes.flexRow} style={{ width: 500 }}>
                <TextField
                  label="Номер заявки"
                  style={{ width: 150 }}
                  InputLabelProps={{
                    shrink: true,
                  }}
                />
                <TextField
                  label="Название сита"
                  style={{ width: 150 }}
                  InputLabelProps={{
                    shrink: true,
                  }}
                  select
                  value={0}
                >
                  <MenuItem value={0}>Все</MenuItem>
                  <MenuItem value={1}>001-Mytichi</MenuItem>
                  <MenuItem value={2}>002-Kommunarka</MenuItem>
                  <MenuItem value={3}>003-Marfino</MenuItem>
                </TextField>
                <TextField
                  label="Текущий этап"
                  style={{ width: 150 }}
                  InputLabelProps={{
                    shrink: true,
                  }}
                  select
                  value={0}
                >
                  <MenuItem value={0}>Все</MenuItem>
                  <MenuItem value={1}>Инициирование заявки</MenuItem>
                  <MenuItem value={2}>Получение технического одобрения</MenuItem>
                  <MenuItem value={3}>Согласование КУ сита</MenuItem>
                </TextField>
              </div>
              <div className={classes.flexRow} style={{ justifyContent: 'space-around' }}>
                <DateRangePicker label="Дата поступления задачи" />
                <DateRangePicker label="Срок обработки задачи" />
              </div>
            </DialogContent>
            <DialogActions>
              <Button onClick={this.handleClose} style={{color: 'green'}}>
                Закрыть
              </Button>
              <Button onClick={this.handleClose} variant="raised" style={{color: 'green'}}>
                Применить
              </Button>
            </DialogActions>
          </Dialog>
        </div>
      </Paper>
    );
  }
}

ProcessingTasksTable.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(ProcessingTasksTable);
