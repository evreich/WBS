
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
                     <TableCell className={classes.cell} >{row.formatTitle}</TableCell>
                     <TableCell className={classes.cell} ><a onClick={this.handleInfoButtonClick}>{row.title}</a></TableCell> 
                     <TableCell className={classes.cell} >{row.technicalExpertFio}</TableCell> 
                     <TableCell className={classes.cell} >{row.kySitFio}</TableCell>
                     <TableCell className={classes.cell} >{row.directorOfSitFio}</TableCell> 
                     <TableCell className={classes.cell} >{row.createrOfBudgetFio}</TableCell>
                     <TableCell className={classes.cell} >{row.kyRegionFio}</TableCell>
                     <TableCell className={classes.cell} >{row.operationDirectorFio}</TableCell>        
                    
                </TableRow>         
        )
    }
}
SimpleRow.propTypes = {
    classes: PropTypes.object.isRequired,
    row: PropTypes.object.isRequired,
    handleInfoButtonClick: PropTypes.func,

}