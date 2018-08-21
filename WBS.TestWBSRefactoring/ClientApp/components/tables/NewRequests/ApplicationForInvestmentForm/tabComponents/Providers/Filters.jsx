import React from 'react';
import PropTypes from 'prop-types';
import TextField from 'material-ui/TextField';
import Button from 'material-ui/Button';
import { FormControlLabel } from 'material-ui/Form';
import Checkbox from 'material-ui/Checkbox';

const WAIT_INTERVAL = 3000;


export default class Filters extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            searchingString: "",
            techServs: []
        };
    }

    timer = null;

    delayTask = (task) => {
        if (this.timer) {
            clearTimeout(this.timer);
        }
        this.timer = setTimeout(task, WAIT_INTERVAL);
    }

    setChanges = () => {
        const { applyFilter } = this.props
        const { searchingString, techServs } = this.state
        const filterObj = {
            title: searchingString,
            techServs: techServs.join(',')
        }
        applyFilter(filterObj);
    }

    handleSearchButtonClick = () => {
        clearTimeout(this.timer);
        this.setChanges()
    }

    onSearchStrChange = (event) => {
        this.setState({ searchingString: event.target.value || '' }, () => this.delayTask(this.setChanges));
    }

    onTechnicalServsChange = (event) => {
        const { techServs } = this.state
        const value = event.target.value
        if (event.target.checked)
            techServs.push(value)
        else {
            const index = techServs.indexOf(value)
            if (index !== -1) techServs.splice(index, 1)
        }

        this.setState({ techServs: techServs }, () => this.delayTask(this.setChanges));
    }

    reset = () => {
        const { reset } = this.props
        clearTimeout(this.timer);
        reset()
    }

    render() {
        const { technicalServs } = this.props
        const { searchingString } = this.state
        return (
            <div style={{ display: 'flex', flexDirection: 'row', marginBottom: 15, justifyContent: 'space-between' }}>
                <div>
                    <TextField
                        style={{ width: 300, marginTop: 20 }}
                        value={searchingString}
                        label="Поставщик"
                        placeholder="Поиск по поставщику"
                        onChange={this.onSearchStrChange}
                        InputLabelProps={{
                            shrink: true,
                        }} />
                </div>
                <div style={{ display: 'flex', flexDirection: 'colomn' }}>
                    <div style={{ display: 'flex', flexDirection: 'row' }}>
                        {technicalServs && technicalServs.map(s =>
                            <FormControlLabel
                                key={s.id}
                                value={s.id}
                                control={
                                    <Checkbox />
                                }
                                onChange={this.onTechnicalServsChange}
                                label={s.title}
                            />)}
                    </div>
                </div>
                <Button onClick={this.handleSearchButtonClick} color='primary'>
                    Поиск
                </Button>
                <Button onClick={this.reset} color='primary'>
                    Сбросить фильтры
                </Button>
            </div>
        );
    }
}

Filters.propTypes = {
    applyFilter: PropTypes.func.isRequired,
    technicalServs: PropTypes.array,
    reset: PropTypes.func.isRequired,
}