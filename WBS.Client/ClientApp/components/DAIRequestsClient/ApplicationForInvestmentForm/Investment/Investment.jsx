
import React from 'react'
import PropTypes from 'prop-types';
import Table, {
  TableBody,
  TableCell,
  TableHead,
  TableRow,
} from 'material-ui/Table';
import TextField from 'material-ui/TextField';
import AddCircleOutlineIcon from 'material-ui-icons/AddCircleOutline';
import AddIcon from 'material-ui-icons/Add'
import DeleteIcon from 'material-ui-icons/Delete';
import MoreHorizIcon from 'material-ui-icons/MoreHoriz';
import Button from 'material-ui/Button';
import Tooltip from 'material-ui/Tooltip';
import IconButton from 'material-ui/IconButton';
import { withStyles } from 'material-ui/styles';
import styles from '../../../Commons/Table/TableStyles.css';

// таблица инвестиции - шаблон! не адаптирован 
const Investment = ({classes}) => <Table>
                         <TableHead>
                             <TableRow className={classes.header}>
                                <TableCell className={classes.cell}>Предмет инвестиции</TableCell>
                                <TableCell className={classes.cell}>Категория</TableCell>
                                <TableCell className={classes.cell} numeric>Амортизация (лет)</TableCell>
                                <TableCell className={classes.cell} numeric>Количество</TableCell>
                                <TableCell className={classes.cell} numeric>Цена (руб.)</TableCell>
                                <TableCell className={classes.cell} colSpan={3}>
                                <Tooltip
                                    title="Добавить подстроку детализации"
                                    placement="left"
                                    enterDelay={300}
                                    >
                                    <Button style={{ float: 'right', color: 'green'}} >
                                        Добавить&nbsp;
                                        <AddCircleOutlineIcon />
                                    </Button>
                            </Tooltip>
                          </TableCell>
                        </TableRow>
                      </TableHead>
                      <TableBody>
                        <TableRow className={classes.row} key={0}>
                          <TableCell className={classes.cell}>
                            <TextField
                              style={{ width: 200 }}
                              value="Ремонт свежих продуктов"
                              disabled
                            />
                          </TableCell>
                          <TableCell className={classes.cell}>0034</TableCell>
                          <TableCell className={classes.cell} numeric>30</TableCell>
                          <TableCell className={classes.cell} numeric>
                            <TextField
                              style={{ width: 50 }}
                              value="1"
                              disabled
                            />
                          </TableCell>
                          <TableCell className={classes.cell} numeric>
                            <TextField
                              style={{ width: 150 }}
                              value="20000000"
                              disabled
                            />
                          </TableCell>
                          <TableCell className={classes.cell}>
                            <Tooltip
                              title="Выбор предмета инвестиций"
                              placement="left"
                              enterDelay={300}
                            >
                              <IconButton>
                                <MoreHorizIcon />
                              </IconButton>
                            </Tooltip>
                          </TableCell>
                          <TableCell className={classes.cell}>
                            <Tooltip
                              title="Добавить подстроку детализации"
                              placement="left"
                              enterDelay={300}
                            >
                              <IconButton>
                                <AddIcon />
                              </IconButton>
                            </Tooltip>
                          </TableCell>
                          <TableCell className={classes.cell}>
                            <Tooltip
                              title="Удалить предмет инвестиций"
                              placement="left"
                              enterDelay={300}
                            >
                              <IconButton>
                                <DeleteIcon />
                              </IconButton>
                            </Tooltip>
                          </TableCell>
                        </TableRow>
                        <TableRow className={classes.row} key={1}>
                          <TableCell className={classes.cell} style={{ borderLeft: '20px solid rgba(0, 0, 0, 0.08)' }}>
                            <TextField
                              style={{ width: 200 }}
                              defaultValue=""
                            />
                          </TableCell>
                          <TableCell className={classes.cell}>
                            <Tooltip
                              title="Выбрать категорию"
                              placement="left"
                              enterDelay={300}
                            >
                              <IconButton>
                                <MoreHorizIcon />
                              </IconButton>
                            </Tooltip>
                          </TableCell>
                          <TableCell className={classes.cell} numeric>30</TableCell>
                          <TableCell className={classes.cell} numeric>
                            <TextField
                              style={{ width: 50 }}
                              defaultValue="0"
                            />
                          </TableCell>
                          <TableCell className={classes.cell} numeric>
                            <TextField
                              style={{ width: 150 }}
                              defaultValue="0"
                            />
                          </TableCell>
                          <TableCell className={classes.cell} />
                          <TableCell className={classes.cell} />
                          <TableCell className={classes.cell}>
                            <Tooltip
                              title="Удалить предмет инвестиций"
                              placement="left"
                              enterDelay={300}
                            >
                              <IconButton>
                                <DeleteIcon />
                              </IconButton>
                            </Tooltip>
                          </TableCell>
                        </TableRow>
                        <TableRow className={classes.row} key={2}>
                          <TableCell className={classes.cell} style={{ borderLeft: '20px solid rgba(0, 0, 0, 0.08)' }}>
                            <TextField
                              style={{ width: 200 }}
                              defaultValue=""
                            />
                          </TableCell>
                          <TableCell className={classes.cell}>
                            <Tooltip
                              title="Выбрать категорию"
                              placement="left"
                              enterDelay={300}
                            >
                              <IconButton>
                                <MoreHorizIcon />
                              </IconButton>
                            </Tooltip>
                          </TableCell>
                          <TableCell className={classes.cell} numeric>30</TableCell>
                          <TableCell className={classes.cell} numeric>
                            <TextField
                              style={{ width: 50 }}
                              defaultValue="0"
                            />
                          </TableCell>
                          <TableCell className={classes.cell} numeric>
                            <TextField
                              style={{ width: 150 }}
                              defaultValue="0"
                            />
                          </TableCell>
                          <TableCell className={classes.cell} />
                          <TableCell className={classes.cell} />
                          <TableCell className={classes.cell}>
                            <Tooltip
                              title="Удалить предмет инвестиций"
                              placement="left"
                              enterDelay={300}
                            >
                              <IconButton>
                                <DeleteIcon />
                              </IconButton>
                            </Tooltip>
                          </TableCell>
                        </TableRow>
                      </TableBody>
                    </Table>

Investment.propTypes = {
    classes: PropTypes.object.isRequired
}

export default withStyles(styles)(Investment)