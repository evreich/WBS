import React from "react";
import PropTypes from "prop-types";

import Table, {
    TableBody,
    TableCell,
    TableHead,
    TableRow
} from "material-ui/Table";
import { withStyles } from "material-ui/styles";

import styles from "../../../../../Commons/Table/TableStyles.css";

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
