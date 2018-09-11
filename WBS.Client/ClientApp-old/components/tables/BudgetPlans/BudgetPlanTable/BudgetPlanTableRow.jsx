import React from 'react'
import PropTypes from 'prop-types';

import TableCell from "@material-ui/core/TableCell";
import TableRow from "@material-ui/core/TableRow";
import Assignment from '@material-ui/icons/Assignment';
import Search from '@material-ui/icons/Search';
import IconButton from '@material-ui/core/IconButton';

const BudgetPlanTableRow = (props) => {
    //TODO: реализовать открытие модальных окон на нажатие по соотв кнопкам
    const { row, classes, handleInfoButtonClick } = props
    return (
        <TableRow className={classes.rowHover} onClick={() => handleInfoButtonClick(row)}>
            <TableCell className={classes.cell} >{row.year}</TableCell>
            <TableCell className={classes.cell} >{row.status}</TableCell>
            <TableCell className={classes.cell} >
                <IconButton /*onClick={}*/ color="default" className={classes.button} aria-label="Посмотреть протокол событий">
                    <Assignment />
                </IconButton>
            </TableCell>
            <TableCell className={classes.cell} >
                <IconButton /*onClick={}*/ color="default" className={classes.button} aria-label="Управление планом">
                    <Search />
                </IconButton>
            </TableCell>
        </TableRow>
    )
}

BudgetPlanTableRow.propTypes = {
    classes: PropTypes.object.isRequired,
    row: PropTypes.object.isRequired,
    handleInfoButtonClick: PropTypes.func,
}

export default BudgetPlanTableRow;