import React from 'react'
import PropTypes from 'prop-types';

import TableCell from "@material-ui/core/TableCell";
import TableRow from "@material-ui/core/TableRow";
 
const ProviderTableRow = (props) => {
    const {row, classes, handleInfoButtonClick} = props
    return(        
        <TableRow className={classes.rowHover} onClick={() => handleInfoButtonClick(row)}>                  
            <TableCell className={classes.cell}> {row.title}</TableCell>  
            <TableCell className={classes.cell}> {row.profiles.map(item => item.title).join(", ")}</TableCell>                            
        </TableRow>         
        )
}
 
ProviderTableRow.propTypes = {
    classes: PropTypes.object.isRequired,
    row: PropTypes.object.isRequired,
    handleInfoButtonClick: PropTypes.func,
}
 
export default ProviderTableRow;