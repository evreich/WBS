import React from 'react'
import PropTypes from 'prop-types';
import Table, {
  TableBody,
  TableCell,
  TableHead,
  TableRow,
} from 'material-ui/Table';
import Button from 'material-ui/Button';
import AddCircleOutlineIcon from 'material-ui-icons/AddCircleOutline';
import IconButton from 'material-ui/IconButton';
import DeleteIcon from 'material-ui-icons/Delete';


const Vendors = ({classes, vendors, onDelete, onAddNew}) => <Table className={classes.table}>
                            <TableHead>
                                <TableRow className={classes.header}>
                                <TableCell className={classes.cell}>Поставщик</TableCell>
                                <TableCell className={classes.cell} numeric>
                                    <Button style={{ float: 'right' }} color="secondary" onClick={() => onAddNew()} >
                                         Добавить&nbsp;
                                        <AddCircleOutlineIcon/>
                                    </Button>
                                </TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {vendors && vendors.map((v) => 
                                  <TableRow className={classes.row} key={v.id}> 
                                    <TableCell className={classes.cell}>{v.title}</TableCell>                          
                                    <TableCell className={classes.cell} numeric>
                                        <IconButton onClick={() => {onDelete(v.id)}}>
                                            <DeleteIcon />
                                        </IconButton>
                                    </TableCell>
                                </TableRow>)}
                            </TableBody>
                            </Table>
                    
Vendors.propTypes = {
    classes: PropTypes.object.isRequired,
    vendors: PropTypes.array.isRequired,
    onDelete: PropTypes.func.isRequired,
    onAddNew: PropTypes.func.isRequired,
 }                           
 export default Vendors;                             