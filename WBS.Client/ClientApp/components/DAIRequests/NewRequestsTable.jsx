import React, { Component, Fragment } from 'react';
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
import ExpansionPanel, {
    ExpansionPanelSummary,
    ExpansionPanelDetails,
} from 'material-ui/ExpansionPanel';
import Toolbar from 'material-ui/Toolbar';
import Typography from 'material-ui/Typography';
//import AppBar from 'material-ui/AppBar';
import Divider from 'material-ui/Divider';
//import IconButton from 'material-ui/IconButton';
import Dialog, {
    DialogActions,
    DialogContent,
    DialogTitle,
} from 'material-ui/Dialog';
import { InputAdornment } from 'material-ui/Input';
import Tabs, { Tab } from 'material-ui/Tabs';
import { MenuItem } from 'material-ui/Menu';
import TextField from 'material-ui/TextField';
import DatePicker from '../Commons/DatePicker';
import { FormControlLabel } from 'material-ui/Form';
import Checkbox from 'material-ui/Checkbox';
import Radio from 'material-ui/Radio';
import AddCircleOutlineIcon from 'material-ui-icons/AddCircleOutline';
import ExpandMoreIcon from 'material-ui-icons/ExpandMore';
import AddIcon from 'material-ui-icons/Add'
import DeleteIcon from 'material-ui-icons/Delete';
import MoreHorizIcon from 'material-ui-icons/MoreHoriz';
import Slide from 'material-ui/transitions/Slide';
import Paper from 'material-ui/Paper';
import Button from 'material-ui/Button';
import Tooltip from 'material-ui/Tooltip';
import { styles, toolbarStyles } from './TableStyles.css';
import IconButton from 'material-ui/IconButton';

let counter = 0;
function createData(date, siteName, lastModified, subject) {
    counter += 1;
    return { id: counter, date, siteName, lastModified, subject };
}
function Transition(props) {
    return <Slide direction="up" timeout={{ enter: 10, exit: 100 }} {...props} />;
}
function TabContainer({ children }) {
    return (
        <Typography component="div" style={{ padding: 8 * 3 }}>
            {children}
        </Typography>
    );
}

TabContainer.propTypes = {
    children: PropTypes.any,
    dir: PropTypes.any,
};

const columnData = [
    { id: 'date', numeric: false, disablePadding: false, label: 'Дата создания' },
    { id: 'siteName', numeric: false, disablePadding: false, label: 'Название сита' },
    { id: 'lastModified', numeric: false, disablePadding: false, label: 'Дата последней модификации' },
    { id: 'subject', numeric: false, disablePadding: false, label: 'Предмет инвестиции' },
];

class TableHeader extends Component {
    createSortHandler = property => event => {
        const { onRequestSort } = this.props;
        onRequestSort(event, property);
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
    const { numSelected, classes, onCreate } = props;

    return (
        <Toolbar
            className={classNames(classes.root, {
                [classes.highlight]: numSelected > 0,
            })}
        >
            <div className={classes.title}>
                <Typography variant="title">Новые заявки</Typography>
            </div>
            <div className={classes.spacer} />
            <div className={classes.actions}>
                <Tooltip title="Filter list">
                    <Button variant="flat" size="small" onClick={onCreate} style={{ marginRight: 10 }} color="secondary" aria-label="Create new">
                        Создать&nbsp;
            <AddCircleOutlineIcon />
                    </Button>
                </Tooltip>
            </div>
        </Toolbar>
    );
};

TableToolbar.propTypes = {
    classes: PropTypes.object.isRequired,
    numSelected: PropTypes.number.isRequired,
    onCreate: PropTypes.func.isRequired,
};

TableToolbar = withStyles(toolbarStyles)(TableToolbar);



class NewRequestsTable extends React.Component {
    constructor(props, context) {
        super(props, context);

        this.handleOpen = this.handleOpen.bind(this);
        this.handleClose = this.handleClose.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.handleChangeTab = this.handleChangeTab.bind(this);

        this.state = {
            open: false,
            tab: 2,
            checkbox: null,
            order: 'asc',
            orderBy: 'date',
            selected: [],
            data: [
                createData('06.02.2018 18:29:32', 'Marfino', '07.02.2018 11:01:32', 'Тележки для покупателей, 240 л'),
                createData('07.02.2018 11:14:15', 'Marfino', '07.02.2018 11:14:16', 'Тележки для покупателей'),
                createData('27.02.2018 19:10:54', 'Kommunarka', '27.02.2018 19:10:54', 'Реконструкция зарядной комнаты на транзитной зоне'),
                createData('06.02.2018 18:29:32', 'Marfino47', '07.02.2018 11:01:32', 'Тележки для покупателей, 240 л'),
                createData('07.02.2018 11:14:15', 'Marfino4', '07.02.2018 11:14:16', 'Тележки для покупателей'),
                createData('27.02.2018 19:10:54', 'Kommunarka5', '27.02.2018 19:10:54', 'Реконструкция зарядной комнаты на транзитной зоне'),
                createData('06.02.2018 18:29:32', 'Marfino76', '07.02.2018 11:01:32', 'Тележки для покупателей, 240 л'),
                createData('07.02.2018 11:14:15', 'Marfino35345', '07.02.2018 11:14:16', 'Тележки для покупателей'),
                createData('27.02.2018 19:10:54', 'Kommunarka2123', '27.02.2018 19:10:54', 'Реконструкция зарядной комнаты на транзитной зоне'),
                createData('06.02.2018 18:29:32', 'Marfino113', '07.02.2018 11:01:32', 'Тележки для покупателей, 240 л'),
                createData('07.02.2018 11:14:15', 'Marfino123', '07.02.2018 11:14:16', 'Тележки для покупателей'),
                createData('27.02.2018 19:10:54', 'Kommunarka5', '27.02.2018 19:10:54', 'Реконструкция зарядной комнаты на транзитной зоне'),
                createData('06.02.2018 18:29:32', 'Marfino65', '07.02.2018 11:01:32', 'Тележки для покупателей, 240 л'),
                createData('07.02.2018 11:14:15', 'Marfino67', '07.02.2018 11:14:16', 'Тележки для покупателей'),
                createData('27.02.2018 19:10:54', 'Kommunarka87', '27.02.2018 19:10:54', 'Реконструкция зарядной комнаты на транзитной зоне'),
                createData('06.02.2018 18:29:32', 'Marfino554', '07.02.2018 11:01:32', 'Тележки для покупателей, 240 л'),
                createData('07.02.2018 11:14:15', 'Marfino65', '07.02.2018 11:14:16', 'Тележки для покупателей'),
                createData('27.02.2018 19:10:54', 'Kommunarka456', '27.02.2018 19:10:54', 'Реконструкция зарядной комнаты на транзитной зоне'),
                createData('06.02.2018 18:29:32', 'Marfino658', '07.02.2018 11:01:32', 'Тележки для покупателей, 240 л'),
                createData('07.02.2018 11:14:15', 'Marfino55', '07.02.2018 11:14:16', 'Тележки для покупателей'),
                createData('27.02.2018 19:10:54', 'Kommunarka656', '27.02.2018 19:10:54', 'Реконструкция зарядной комнаты на транзитной зоне'),
                createData('06.02.2018 18:29:32', 'Marfino5', '07.02.2018 11:01:32', 'Тележки для покупателей, 240 л'),
                createData('07.02.2018 11:14:15', 'Marfino456', '07.02.2018 11:14:16', 'Тележки для покупателей'),
                createData('27.02.2018 19:10:54', 'Kommunarka', '27.02.2018 19:10:54', 'Реконструкция зарядной комнаты на транзитной зоне'),
                createData('06.02.2018 18:29:32', 'Marfino', '07.02.2018 11:01:32', 'Тележки для покупателей, 240 л'),
                createData('07.02.2018 11:14:15', 'Marfino', '07.02.2018 11:14:16', 'Тележки для покупателей'),
                createData('27.02.2018 19:10:54', 'Kommunarka', '27.02.2018 19:10:54', 'Реконструкция зарядной комнаты на транзитной зоне'),
                createData('06.02.2018 18:29:32', 'Marfino', '07.02.2018 11:01:32', 'Тележки для покупателей, 240 л'),
                createData('07.02.2018 11:14:15', 'Marfino', '07.02.2018 11:14:16', 'Тележки для покупателей'),
                createData('27.02.2018 19:10:54', 'Kommunarka', '27.02.2018 19:10:54', 'Реконструкция зарядной комнаты на транзитной зоне'),
                createData('06.02.2018 18:29:32', 'Marfino0-=', '07.02.2018 11:01:32', 'Тележки для покупателей, 240 л'),
                createData('07.02.2018 11:14:15', 'Marfino', '07.02.2018 11:14:16', 'Тележки для покупателей'),
                createData('27.02.2018 19:10:54', 'Kommunarka-0', '27.02.2018 19:10:54', 'Реконструкция зарядной комнаты на транзитной зоне'),
                createData('06.02.2018 18:29:32', 'Marfino877', '07.02.2018 11:01:32', 'Тележки для покупателей, 240 л'),
                createData('07.02.2018 11:14:15', 'Marfino67', '07.02.2018 11:14:16', 'Тележки для покупателей'),
                createData('27.02.2018 19:10:54', 'Kommunarka', '27.02.2018 19:10:54', 'Реконструкция зарядной комнаты на транзитной зоне'),
                createData('06.02.2018 18:29:32', 'Marfino', '07.02.2018 11:01:32', 'Тележки для покупателей, 240 л'),
                createData('07.02.2018 11:14:15', 'Marfino6', '07.02.2018 11:14:16', 'Тележки для покупателей'),
                createData('27.02.2018 19:10:54', 'Kommunarka', '27.02.2018 19:10:54', 'Реконструкция зарядной комнаты на транзитной зоне'),
                createData('06.02.2018 18:29:32', 'Marfino', '07.02.2018 11:01:32', 'Тележки для покупателей, 240 л'),
                createData('07.02.2018 11:14:15', 'Marfino', '07.02.2018 11:14:16', 'Тележки для покупателей'),
                createData('27.02.2018 19:10:54', 'Kommunarka', '27.02.2018 19:10:54', 'Реконструкция зарядной комнаты на транзитной зоне'),
                createData('06.02.2018 18:29:32', 'Marfino', '07.02.2018 11:01:32', 'Тележки для покупателей, 240 л'),
                createData('07.02.2018 11:14:15', 'Marfino', '07.02.2018 11:14:16', 'Тележки для покупателей'),
                createData('27.02.2018 19:10:54', 'Kommunarka', '27.02.2018 19:10:54', 'Реконструкция зарядной комнаты на транзитной зоне'),
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

    handleClose() {
        this.setState({ open: false });
    }

    handleOpen() {
        this.setState({ open: true });
    }

    handleChange(event) {
        this.setState({ checkbox: event.target.value });
    }

    handleChangeTab(e, value) {
        if (typeof e === 'number')
            this.setState({ tab: e });
        else
            this.setState({ tab: value });
    }

    isSelected = id => {
        const { selected } = this.state;
        selected.indexOf(id) !== -1;
    }

    render() {
        const { classes } = this.props;
        const { data, order, orderBy, selected, rowsPerPage, page, tab, open } = this.state;
        const emptyRows = rowsPerPage - Math.min(rowsPerPage, data.length - page * rowsPerPage);

        return (
            <Paper className={classes.root}>
                <TableToolbar numSelected={selected.length} onCreate={this.handleOpen} />
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
                                    <TableCell className={classes.cell}>{n.date}</TableCell>
                                    <TableCell className={classes.cell}>{n.siteName}</TableCell>
                                    <TableCell className={classes.cell}>{n.lastModified}</TableCell>
                                    <TableCell className={classes.cell}>{n.subject}</TableCell>
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
                                    colSpan={4}
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
                        open={open}
                        onClose={this.handleClose}
                        transition={Transition}
                        maxWidth={false}
                    >
                        <DialogTitle id="form-dialog-title">
                            <div style={{ display: 'flex', justifyContent: 'space-between' }}>
                                <div style={{ marginTop: 5 }}>
                                    Заявка на получение инвестиции
              </div>
                <Button style={{color: 'green'}}>
                  Запустить рабочий процесс
                </Button>
              </div>
            </DialogTitle>
            <DialogContent>
              <div className={classes.flexRow} style={{ width: 1200, justifyContent: 'space-around' }}>
                <TextField
                  label="Номер заявки"
                  style={{ width: 300 }}
                  InputLabelProps={{
                    shrink: true,
                  }}
                  disabled
                />
                <DatePicker
                  label="Дата утверждения директором"
                  style={{ width: 300 }}
                  disabled
                />
                <TextField
                  label="Текущий этап"
                  style={{ width: 300 }}
                  InputLabelProps={{
                    shrink: true,
                  }}
                  disabled
                />
              </div>
              <div className={classes.flexRow} style={{ width: 1200, justifyContent: 'space-around' }}>
                <div style={{ display: 'flex', flexDirection: 'column' }}>
                  <TextField
                    label="Название сита"
                    style={{ width: 300, marginTop: 20 }}
                    InputLabelProps={{
                      shrink: true,
                    }}
                    select
                    value={0}
                  >
                    <MenuItem value={0}>Выберите сит</MenuItem>
                    <MenuItem value={1}>001-Mytichi</MenuItem>
                    <MenuItem value={2}>002-Kommunarka</MenuItem>
                    <MenuItem value={3}>003-Marfino</MenuItem>
                  </TextField>
                  <TextField
                    label="Ответственный в сите"
                    style={{ width: 300, marginTop: 20 }}
                    value="A.Nebolsin"
                    InputLabelProps={{
                      shrink: true,
                    }}
                    disabled
                  />
                </div>
                <div style={{ display: 'flex', flexDirection: 'column' }}>
                  <TextField
                    label="Центр результата"
                    style={{ width: 300, marginTop: 20 }}
                    InputLabelProps={{
                      shrink: true,
                    }}
                    select
                    value={0}
                  >
                    <MenuItem value={0}>0054 (виртуальный ЦР заменяющий Активность Иммошан) Иммошан распределение</MenuItem>
                    <MenuItem value={1}>45502 Скоропортящиеся продукты</MenuItem>
                    <MenuItem value={2}>60020 Дирекция</MenuItem>
                    <MenuItem value={3}>60021 ЦО Ашан Сити</MenuItem>
                  </TextField>
                  <DatePicker
                    label="Желаемый срок поставки"
                    style={{ width: 300, marginTop: 20 }}
                  />
                </div>
                <div style={{ width: 300, display: 'flex', flexDirection: 'column' }}>
                  <FormControlLabel
                    className={classes.radio}
                    style={{ marginTop: 12 }}
                    control={
                      <Radio
                        name="radio"
                        style={{ height: 25 }}
                        onChange={this.handleChange}
                        checked={this.state.checkbox === 'a'}
                        value="a"
                      />
                    }
                    label={
                      <Fragment>
                        <span>Ariba </span>
                        <a style={{ color: '#ed1a21' }} href="#">запустить</a>
                      </Fragment>
                    }
                  />
                  <FormControlLabel
                    className={classes.radio}
                    style={{ marginBottom: 4 }}
                    control={
                      <Radio
                        name="radio"
                        style={{ height: 25 }}
                        onChange={this.handleChange}
                        checked={this.state.checkbox === 'b'}
                        value="b"
                      />
                    }
                    label="Выбор технической службы*"
                  />
                  <Divider />
                  <FormControlLabel
                    className={classes.checkbox}
                    control={
                      <Checkbox style={{ height: 24 }} />
                    }
                    label="IT"
                  />
                  <FormControlLabel
                    className={classes.checkbox}
                    control={
                      <Checkbox style={{ height: 24 }} />
                    }
                    label="Consulting"
                  />
                  <FormControlLabel
                    className={classes.checkbox}
                    control={
                      <Checkbox style={{ height: 24 }} />
                    }
                    label="Equipment"
                  />
                </div>
              </div>
              <div className={classes.flexRow} style={{ flexDirection: 'column', width: 1200, justifyContent: 'space-around' }}>
                <Paper>
                  <Tabs
                    value={tab}
                    onChange={this.handleChangeTab}
                    indicatorColor="primary"
                    textColor="secondary"
                    centered
                  >
                    <Tab label="Бюджет" />
                    <Tab label="Вне бюджета" />
                    <Tab label="Инвестиции" />
                    <Tab label="Поставщик" />
                    <Tab label="Эффективность инвестиций" />
                  </Tabs>
                </Paper>
                {tab === 0 && <TabContainer>
                  <Paper>
                    <Table className={classes.table}>
                      <TableHead>
                        <TableRow className={classes.header}>
                          <TableCell className={classes.cell}>Бюджет</TableCell>
                          <TableCell className={classes.cell} numeric>Сумма</TableCell>
                          <TableCell className={classes.cell} numeric>Остаток</TableCell>
                          <TableCell className={classes.cell} numeric>Останется в бюджете при валидации ДАИ</TableCell>
                        </TableRow>
                      </TableHead>
                      <TableBody>
                        <TableRow className={classes.row} key={0}>
                          <TableCell className={classes.cell}>Строка бюджета</TableCell>
                          <TableCell className={classes.cell} numeric>0,00</TableCell>
                          <TableCell className={classes.cell} numeric>0,00</TableCell>
                          <TableCell className={classes.cell} numeric>0,00</TableCell>
                        </TableRow>
                        <TableRow className={classes.row} key={1}>
                          <TableCell className={classes.cell}>Всего для сита</TableCell>
                          <TableCell className={classes.cell} numeric>0</TableCell>
                          <TableCell className={classes.cell} numeric>0</TableCell>
                          <TableCell className={classes.cell} numeric>0,00</TableCell>
                        </TableRow>
                      </TableBody>
                    </Table>
                  </Paper>
                </TabContainer>}
                {tab === 1 && <TabContainer>
                  <TextField
                    style={{ width: 150, marginBottom: 5 }}
                    select
                    value={0}
                  >
                    <MenuItem value={0}>Новый</MenuItem>
                    <MenuItem value={1}>Замена</MenuItem>
                  </TextField>
                  <Paper>
                    <Table className={classes.table}>
                      <TableHead>
                        <TableRow className={classes.header}>
                          <TableCell className={classes.cell}>Вне бюджета</TableCell>
                          <TableCell className={classes.cell} numeric>Сумма</TableCell>
                        </TableRow>
                      </TableHead>
                      <TableBody>
                        <TableRow className={classes.row} key={0}>
                          <TableCell className={classes.cell}>Предмет инвестиции</TableCell>
                          <TableCell className={classes.cell} numeric>5 965 404,89</TableCell>
                        </TableRow>
                      </TableBody>
                    </Table>
                  </Paper>
                </TabContainer>}
                {tab === 2 && <TabContainer>
                  <Paper>
                    <Table>
                      <TableHead>
                        <TableRow className={classes.header}>
                          <TableCell className={classes.cell}>Предмет инвестиции</TableCell>
                          <TableCell className={classes.cell}>Категория</TableCell>
                          <TableCell className={classes.cell} numeric>Амортизация (лет)</TableCell>
                          <TableCell className={classes.cell} numeric>Количество</TableCell>
                          <TableCell className={classes.cell} numeric>Цена (руб.)</TableCell>
                          <TableCell className={classes.cell} colSpan={3}>
                            <Tooltip
                              title="Добавить подстроку детализации"
                              placement="left"
                              enterDelay={300}
                            >
                              <Button style={{ float: 'right', color: 'green' }}>
                                Добавить&nbsp;
                                  <AddCircleOutlineIcon />
                              </Button>
                            </Tooltip>
                          </TableCell>
                        </TableRow>
                      </TableHead>
                      <TableBody>
                        <TableRow className={classes.row} key={0}>
                          <TableCell className={classes.cell}>
                            <TextField
                              style={{ width: 200 }}
                              value="Ремонт свежих продуктов"
                              disabled
                            />
                          </TableCell>
                          <TableCell className={classes.cell}>0034</TableCell>
                          <TableCell className={classes.cell} numeric>30</TableCell>
                          <TableCell className={classes.cell} numeric>
                            <TextField
                              style={{ width: 50 }}
                              value="1"
                              disabled
                            />
                          </TableCell>
                          <TableCell className={classes.cell} numeric>
                            <TextField
                              style={{ width: 150 }}
                              value="20000000"
                              disabled
                            />
                          </TableCell>
                          <TableCell className={classes.cell}>
                            <Tooltip
                              title="Выбор предмета инвестиций"
                              placement="left"
                              enterDelay={300}
                            >
                              <IconButton>
                                <MoreHorizIcon />
                              </IconButton>
                            </Tooltip>
                          </TableCell>
                          <TableCell className={classes.cell}>
                            <Tooltip
                              title="Добавить подстроку детализации"
                              placement="left"
                              enterDelay={300}
                            >
                              <IconButton>
                                <AddIcon />
                              </IconButton>
                            </Tooltip>
                          </TableCell>
                          <TableCell className={classes.cell}>
                            <Tooltip
                              title="Удалить предмет инвестиций"
                              placement="left"
                              enterDelay={300}
                            >
                              <IconButton>
                                <DeleteIcon />
                              </IconButton>
                            </Tooltip>
                          </TableCell>
                        </TableRow>
                        <TableRow className={classes.row} key={1}>
                          <TableCell className={classes.cell} style={{ borderLeft: '20px solid rgba(0, 0, 0, 0.08)' }}>
                            <TextField
                              style={{ width: 200 }}
                              defaultValue=""
                            />
                          </TableCell>
                          <TableCell className={classes.cell}>
                            <Tooltip
                              title="Выбрать категорию"
                              placement="left"
                              enterDelay={300}
                            >
                              <IconButton>
                                <MoreHorizIcon />
                              </IconButton>
                            </Tooltip>
                          </TableCell>
                          <TableCell className={classes.cell} numeric>30</TableCell>
                          <TableCell className={classes.cell} numeric>
                            <TextField
                              style={{ width: 50 }}
                              defaultValue="0"
                            />
                          </TableCell>
                          <TableCell className={classes.cell} numeric>
                            <TextField
                              style={{ width: 150 }}
                              defaultValue="0"
                            />
                          </TableCell>
                          <TableCell className={classes.cell} />
                          <TableCell className={classes.cell} />
                          <TableCell className={classes.cell}>
                            <Tooltip
                              title="Удалить предмет инвестиций"
                              placement="left"
                              enterDelay={300}
                            >
                              <IconButton>
                                <DeleteIcon />
                              </IconButton>
                            </Tooltip>
                          </TableCell>
                        </TableRow>
                        <TableRow className={classes.row} key={2}>
                          <TableCell className={classes.cell} style={{ borderLeft: '20px solid rgba(0, 0, 0, 0.08)' }}>
                            <TextField
                              style={{ width: 200 }}
                              defaultValue=""
                            />
                          </TableCell>
                          <TableCell className={classes.cell}>
                            <Tooltip
                              title="Выбрать категорию"
                              placement="left"
                              enterDelay={300}
                            >
                              <IconButton>
                                <MoreHorizIcon />
                              </IconButton>
                            </Tooltip>
                          </TableCell>
                          <TableCell className={classes.cell} numeric>30</TableCell>
                          <TableCell className={classes.cell} numeric>
                            <TextField
                              style={{ width: 50 }}
                              defaultValue="0"
                            />
                          </TableCell>
                          <TableCell className={classes.cell} numeric>
                            <TextField
                              style={{ width: 150 }}
                              defaultValue="0"
                            />
                          </TableCell>
                          <TableCell className={classes.cell} />
                          <TableCell className={classes.cell} />
                          <TableCell className={classes.cell}>
                            <Tooltip
                              title="Удалить предмет инвестиций"
                              placement="left"
                              enterDelay={300}
                            >
                              <IconButton>
                                <DeleteIcon />
                              </IconButton>
                            </Tooltip>
                          </TableCell>
                        </TableRow>
                      </TableBody>
                    </Table>
                  </Paper>
                </TabContainer>}
                {tab === 3 && <TabContainer>
                  <Paper>
                    <Table className={classes.table}>
                      <TableHead>
                        <TableRow className={classes.header}>
                          <TableCell className={classes.cell}>Поставщик</TableCell>
                          <TableCell className={classes.cell} numeric>
                            <Button style={{ float: 'right', color: 'green' }}>
                              Добавить&nbsp;
                                <AddCircleOutlineIcon />
                            </Button>
                          </TableCell>
                        </TableRow>
                      </TableHead>
                      <TableBody>
                        <TableRow className={classes.row} key={0}>
                          <TableCell className={classes.cell}>ICL</TableCell>
                          <TableCell className={classes.cell} numeric>
                            <IconButton>
                              <DeleteIcon />
                            </IconButton>
                          </TableCell>
                        </TableRow>
                      </TableBody>
                    </Table>
                  </Paper>
                </TabContainer>}
                {tab === 4 && <TabContainer>
                  <Button style={{color: 'green'}}>
                    Рассчитать
                  </Button>
                  <Paper>
                    <div className={classes.flexRow} style={{ justifyContent: 'space-around' }}>
                      <div style={{ display: 'flex', flexDirection: 'column' }}>
                        <TextField
                          label="Всего инвестиций"
                          style={{ width: 300, marginTop: 20 }}
                          value="200 000 000,00"
                          InputLabelProps={{
                            shrink: true,
                          }}
                          disabled
                        />
                        <TextField
                          label="Предположительный срок эксплуатации"
                          style={{ width: 300, marginTop: 20 }}
                          defaultValue="0"
                          InputLabelProps={{
                            shrink: true,
                          }}
                        />
                        <TextField
                          label="Дополнительные продажи за год"
                          style={{ width: 300, marginTop: 20 }}
                          defaultValue="0,00"
                          InputLabelProps={{
                            shrink: true,
                          }}
                        />
                      </div>
                      <div style={{ display: 'flex', flexDirection: 'column' }}>
                        <TextField
                          label="Маржа на добавачную стоимость"
                          style={{ width: 300, marginTop: 20 }}
                          defaultValue="0,00"
                          InputLabelProps={{
                            shrink: true,
                          }}
                          disabled
                        />
                        <TextField
                          label="Срок окупаемости"
                          style={{ width: 300, marginTop: 20 }}
                          defaultValue="??>0"
                          InputLabelProps={{
                            shrink: true,
                          }}
                          disabled
                        />
                        <TextField
                          label="Дополнительные ежегодные затраты"
                          style={{ width: 300, marginTop: 20 }}
                          defaultValue="0,00"
                          InputLabelProps={{
                            shrink: true,
                          }}
                        />
                      </div>
                      <div style={{ width: 300, display: 'flex', flexDirection: 'column' }}>
                        <TextField
                          label="Чистая маржа %"
                          style={{ width: 300, marginTop: 20 }}
                          defaultValue="0"
                          InputLabelProps={{
                            shrink: true,
                          }}
                        />
                        <TextField
                          label="Внутренняя ставка доходности"
                          style={{ width: 300, marginTop: 20 }}
                          defaultValue="0%"
                          InputLabelProps={{
                            shrink: true,
                          }}
                          disabled
                        />
                        <TextField
                          label="Чистая приведенная стоимость"
                          style={{ width: 300, marginTop: 20 }}
                          defaultValue="-173 160 173,16"
                          InputLabelProps={{
                            shrink: true,
                          }}
                          InputProps={{
                            endAdornment: <InputAdornment position="end">15.5%</InputAdornment>
                          }}
                          disabled
                        />
                      </div>
                    </div>
                  </Paper>
                </TabContainer>}
              </div>
              <Divider />
              <div className={classes.flexRow} style={{ width: 1200, justifyContent: 'space-around' }}>
                <div style={{ width: 500, flexDirection: 'column' }}>
                  <TextField
                    label="Обоснование необходимости инвестиций"
                    style={{ width: 350, marginTop: 20, marginBottom: 20 }}
                    InputLabelProps={{
                      shrink: true,
                    }}
                    select
                    value={0}
                  >
                    <MenuItem value={0}>Получение прибыли</MenuItem>
                    <MenuItem value={1}>Экономия средств</MenuItem>
                    <MenuItem value={2}>Требования аудита</MenuItem>
                    <MenuItem value={3}>Требования государственных органов</MenuItem>
                  </TextField>
                  <FormControlLabel
                    className={classes.checkbox}
                    control={
                      <Checkbox />
                    }
                    label="Требуется одобрение технического эксперта"
                  />
                </div>
                <TextField
                  style={{ width: 500, marginTop: 20, marginBottom: 20 }}
                  label="Комментарий для генерального директора"
                  InputLabelProps={{
                    shrink: true,
                  }}
                  multiline
                  rows={4}
                />
              </div>
              <ExpansionPanel expanded>
                <ExpansionPanelSummary expandIcon={<ExpandMoreIcon />}>
                  <Typography className={classes.heading}>Заполняет КУ сита</Typography>
                </ExpansionPanelSummary>
                <ExpansionPanelDetails>
                  <div className={classes.flexRow} style={{ justifyContent: 'space-around' }}>
                    <TextField
                      label="Классификация инвестиций"
                      style={{ width: 350, marginTop: 20 }}
                      InputLabelProps={{
                        shrink: true,
                      }}
                      select
                      value={0}
                      disabled
                    >
                      <MenuItem value={0} />
                    </TextField>
                    <TextField
                      label="Тип факт"
                      style={{ width: 350, marginTop: 20 }}
                      defaultValue=""
                      InputLabelProps={{
                        shrink: true,
                      }}
                      disabled
                    />
                  </div>
                </ExpansionPanelDetails>
              </ExpansionPanel>
              <ExpansionPanel expanded>
                <ExpansionPanelSummary expandIcon={<ExpandMoreIcon />}>
                  <Typography className={classes.heading}>Заполняет инициатор при закрытии заявки</Typography>
                </ExpansionPanelSummary>
                <ExpansionPanelDetails>
                  <div className={classes.flexRow} style={{ justifyContent: 'space-around' }}>
                    <TextField
                      label="Внутренний инвентарный номер"
                      style={{ width: 350, marginTop: 20 }}
                      defaultValue=""
                      InputLabelProps={{
                        shrink: true,
                      }}
                      disabled
                    />
                    <DatePicker
                      label="Дата ввода основных средств в эксплуатацию"
                      style={{ width: 350 }}
                      disabled
                    />
                  </div>
                </ExpansionPanelDetails>
              </ExpansionPanel>
            </DialogContent>
            <DialogActions>
              <span style={{ flex: 1 }}>
                <Button onClick={this.handleClose} variant="raised" disabled style={{color: 'green'}}>
                  Удалить
                </Button>
              </span>
              <Button onClick={this.handleClose} style={{color: 'green'}}>
                Отмена
              </Button>
              <Button onClick={this.handleClose} variant="raised" style={{color: 'green'}}>
                Сохранить
              </Button>
                        </DialogActions>
                    </Dialog>
                </div>
            </Paper >
        );
    }
}

NewRequestsTable.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(NewRequestsTable);
