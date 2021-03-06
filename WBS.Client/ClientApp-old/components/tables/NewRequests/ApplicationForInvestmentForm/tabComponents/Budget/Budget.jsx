import React from "react";
import PropTypes from "prop-types";

import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableRow from "@material-ui/core/TableRow";
import TableHead from "@material-ui/core/TableHead";
import { withStyles } from "@material-ui/core/styles";

import styles from "components/Commons/Table/TableStyles.css";

const Budget = ({ classes, budgetData: { rowBudget, totalSit } }) => (
    <Table className={classes.table}>
        <TableHead>
            <TableRow className={classes.header}>
                <TableCell className={classes.cell}>Бюджет</TableCell>
                <TableCell className={classes.cell} numeric>
                    Сумма
                </TableCell>
                <TableCell className={classes.cell} numeric>
                    Остаток
                </TableCell>
                <TableCell className={classes.cell} numeric>
                    Останется в бюджете при валидации ДАИ
                </TableCell>
            </TableRow>
        </TableHead>
        <TableBody>
            <TableRow className={classes.row} key={0}>
                <TableCell className={classes.cell}>Строка бюджета</TableCell>
                <TableCell className={classes.cell} numeric>
                    {rowBudget.sum}
                </TableCell>
                <TableCell className={classes.cell} numeric>
                    {rowBudget.rest}
                </TableCell>
                <TableCell className={classes.cell} numeric>
                    {rowBudget.dai}
                </TableCell>
            </TableRow>
            <TableRow className={classes.row} key={1}>
                <TableCell className={classes.cell}>Всего для сита</TableCell>
                <TableCell className={classes.cell} numeric>
                    {totalSit.sum}
                </TableCell>
                <TableCell className={classes.cell} numeric>
                    {totalSit.rest}
                </TableCell>
                <TableCell className={classes.cell} numeric>
                    {totalSit.dai}
                </TableCell>
            </TableRow>
        </TableBody>
    </Table>
);

Budget.propTypes = {
    classes: PropTypes.object,
    budgetData: PropTypes.object,
    rowBudget: PropTypes.object,
    totalSit: PropTypes.object
};
export default withStyles(styles)(Budget);
