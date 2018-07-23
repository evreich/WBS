
import React from 'react'
import PropTypes from 'prop-types';
import {
    TableCell,
    TableRow,
} from 'material-ui/Table';


export class SimpleRow extends React.Component {

   handleUpdateButtonClick = () => {
        const {row, handleUpdateButtonClick} = this.props
        handleUpdateButtonClick(row)
    }

    render(){
        const {row, classes} = this.props
        return(         
                <TableRow className={classes.rowHover}>
                  <TableCell className={classes.cell}><a onClick={this.handleUpdateButtonClick}>{row.creationData}</a></TableCell>
                  <TableCell className={classes.cell}>{row.sitName}</TableCell>
                  <TableCell className={classes.cell}>{row.lastModifiedData}</TableCell>
                  <TableCell className={classes.cell}>{row.subject}</TableCell>              
                </TableRow>
         
        )
    }
}

SimpleRow.propTypes = {
    classes: PropTypes.object.isRequired,
    row: PropTypes.object.isRequired,
    handleUpdateButtonClick: PropTypes.func,

}