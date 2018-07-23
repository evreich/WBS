
import React from 'react'
import PropTypes from 'prop-types';
import {
    TableCell,
    TableRow,
} from 'material-ui/Table';


export class SimpleRow extends React.Component {

   handleInfoButtonClick = () => {
        const {row, handleInfoButtonClick} = this.props
        handleInfoButtonClick(row)
    }

    render(){
        const {row, classes} = this.props
        return(
           
                <TableRow className={classes.rowHover}>
                                        <TableCell className={classes.cell} ><a onClick={this.handleInfoButtonClick}>{row.fio}</a></TableCell>                                    
                                        <TableCell className={classes.cell} >{row.jobPosition}</TableCell> 
                                        <TableCell className={classes.cell} >{row.department}</TableCell> 
                                        <TableCell className={classes.cell} >{row.deletionMark?'да':'-'}</TableCell> 
                                       
                </TableRow>
         
        )
    }
}

SimpleRow.propTypes = {
    classes: PropTypes.object.isRequired,
    row: PropTypes.object.isRequired,
    handleInfoButtonClick: PropTypes.func,
}