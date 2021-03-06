import React from "react";
import PropTypes from "prop-types";

import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableRow from "@material-ui/core/TableRow";
import TableHead from "@material-ui/core/TableHead";
import { withStyles } from "@material-ui/core/styles";

import styles from "components/Commons/Table/TableStyles.css";

const OutBudget = ({ classes, outBudgetData: { sum } }) => (
    <Table className={classes.table}>
        <TableHead>
            <TableRow className={classes.header}>
                <TableCell className={classes.cell}>Вне бюджета</TableCell>
                <TableCell className={classes.cell} numeric>
                    Сумма
                </TableCell>
            </TableRow>
        </TableHead>
        <TableBody>
            <TableRow className={classes.row} key={0}>
                <TableCell className={classes.cell}>Всего для сита</TableCell>
                <TableCell className={classes.cell} numeric>
                    {sum}
                </TableCell>
            </TableRow>
        </TableBody>
    </Table>
);

OutBudget.propTypes = {
    classes: PropTypes.object.isRequired,
    outBudgetData: PropTypes.object.isRequired,
    sum: PropTypes.number
};
export default withStyles(styles)(OutBudget);
