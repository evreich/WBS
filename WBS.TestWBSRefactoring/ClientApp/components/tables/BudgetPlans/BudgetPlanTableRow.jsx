import React from 'react'
import PropTypes from 'prop-types';

import {
    TableCell,
    TableRow,
} from 'material-ui/Table';
import Assignment from 'material-ui-icons/Assignment';
import Build from 'material-ui-icons/Search';
import { IconButton } from 'material-ui';
 
const BudgetPlanTableRow = (props) => {
    //TODO: реализовать открытие модальных окон на нажатие по соотв кнопкам
    const {row, classes, handleInfoButtonClick} = props
    return(        
        <TableRow className={classes.rowHover} onClick={() => handleInfoButtonClick(row)}>                  
            <TableCell className={classes.cell} >
                {row.year}
            </TableCell>  
            <TableCell className={classes.cell} >{row.status}</TableCell> 
            <TableCell className={classes.cell} >
                <IconButton /*onClick={}*/ color="default" className={classes.button} aria-label="Посмотреть протокол событий">
                    <Assignment />
                </IconButton>
            </TableCell>        
            <TableCell className={classes.cell} >
                <IconButton /*onClick={}*/ color="default" className={classes.button} aria-label="Управление планом">
                    <Build />
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