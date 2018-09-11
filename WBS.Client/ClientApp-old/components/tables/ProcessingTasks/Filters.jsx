import React from "react";
import PropTypes from "prop-types";

import Dialog from "@material-ui/core/Dialog";
import DialogActions from "@material-ui/core/DialogActions";
import DialogContent from "@material-ui/core/DialogContent";
import DialogTitle from "@material-ui/core/DialogTitle";
import TextField from "@material-ui/core/TextField";
import MenuItem from "@material-ui/core/MenuItem";
import Button from "@material-ui/core/Button";

import DateRangePicker from "../../Commons/DateRangePicker";

const styles = {
    saveButton: {
        color: "white",
        background: "green",
        "&:hover": { background: "#045404", backgroundClip: "padding-box" }
    },
    cancelButton: {
        color: "white",
        background: "red",
        "&:hover": { background: "#b50606", backgroundClip: "padding-box" }
    }
}

class Filters extends React.PureComponent {
    static propTypes = {
        open: PropTypes.bool,
        handleClose: PropTypes.func,
        classes: PropTypes.object
    };

    render() {
        const { open, handleClose, classes } = this.props;
        return (
            <Dialog
                open={open}
                onClose={handleClose}
                
                aria-labelledby="form-dialog-title"
                maxWidth={false}
            >
                <DialogTitle id="form-dialog-title">
                    <div
                        style={{
                            display: "flex",
                            justifyContent: "space-between"
                        }}
                    >
                        <div style={{ marginTop: 5 }}>Фильтры</div>
                        <Button style={styles.saveButton}>Очистить</Button>
                    </div>
                </DialogTitle>
                <DialogContent>
                    <div className={classes.flexRow} style={{ width: 500 }}>
                        <TextField
                            label="Номер заявки"
                            style={{ width: 150 }}
                            InputLabelProps={{
                                shrink: true
                            }}
                        />
                        <TextField
                            label="Название сита"
                            style={{ width: 150 }}
                            InputLabelProps={{
                                shrink: true
                            }}
                            select
                            value={0}
                        >
                            <MenuItem value={0}>Все</MenuItem>
                            <MenuItem value={1}>001-Mytichi</MenuItem>
                            <MenuItem value={2}>002-Kommunarka</MenuItem>
                            <MenuItem value={3}>003-Marfino</MenuItem>
                        </TextField>
                        <TextField
                            label="Текущий этап"
                            style={{ width: 150 }}
                            InputLabelProps={{
                                shrink: true
                            }}
                            select
                            value={0}
                        >
                            <MenuItem value={0}>Все</MenuItem>
                            <MenuItem value={1}>Инициирование заявки</MenuItem>
                            <MenuItem value={2}>
                                Получение технического одобрения
                            </MenuItem>
                            <MenuItem value={3}>Согласование КУ сита</MenuItem>
                        </TextField>
                    </div>
                    <div
                        className={classes.flexRow}
                        style={{ justifyContent: "space-around" }}
                    >
                        <DateRangePicker label="Дата поступления задачи" />
                        <DateRangePicker label="Срок обработки задачи" />
                    </div>
                </DialogContent>
                <DialogActions>
                    <Button
                        onClick={handleClose}
                        style={styles.cancelButton}
                    >
                        Закрыть
                    </Button>
                    <Button
                        onClick={handleClose}
                        variant="raised"
                        style={styles.saveButton}
                    >
                        Применить
                    </Button>
                </DialogActions>
            </Dialog>
        );
    }
}

export default Filters;
