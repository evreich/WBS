import React from "react";
import PropTypes from "prop-types";

import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableRow from "@material-ui/core/TableRow";
import TableHead from "@material-ui/core/TableHead";
import Button from "@material-ui/core/Button";
import AddCircleOutlineIcon from "@material-ui/icons/AddCircleOutline";
import IconButton from "@material-ui/core/IconButton";
import DeleteIcon from "@material-ui/icons/Delete";
import { withStyles } from "@material-ui/core/styles";

import styles from 'components/Commons/Table/TableStyles.css';

const Providers = ({ classes, providers, onDelete, onAddNew }) => (
    <Table className={classes.table}>
        <TableHead>
            <TableRow className={classes.header}>
                <TableCell className={classes.cell}>Поставщик</TableCell>
                <TableCell className={classes.cell} numeric>
                    <Button
                        style={{ float: "right" }}
                        color="secondary"
                        onClick={() => onAddNew()}
                    >
                        Добавить&nbsp;
                        <AddCircleOutlineIcon />
                    </Button>
                </TableCell>
            </TableRow>
        </TableHead>
        <TableBody>
            {providers &&
                providers.map(v => (
                    <TableRow className={classes.row} key={v.id}>
                        <TableCell className={classes.cell}>
                            {v.title}
                        </TableCell>
                        <TableCell className={classes.cell} numeric>
                            <IconButton
                                onClick={() => {
                                    onDelete(v.id);
                                }}
                            >
                                <DeleteIcon />
                            </IconButton>
                        </TableCell>
                    </TableRow>
                ))}
        </TableBody>
    </Table>
);

Providers.propTypes = {
    classes: PropTypes.object.isRequired,
    providers: PropTypes.array.isRequired,
    onDelete: PropTypes.func.isRequired,
    onAddNew: PropTypes.func.isRequired
};
export default withStyles(styles)(Providers);
