import React from 'react';
import PropTypes from 'prop-types';
import Dialog, {
    DialogActions,
    DialogContent,
    DialogTitle,
} from 'material-ui/Dialog';
import Button from 'material-ui/Button';
import { connect } from 'react-redux';
import TextFieldMultiline from '../Commons/TextFields/TextFieldMultiline';
import TextFieldSelect from '../Commons/TextFields/TextFieldSelect';
import UserAutosuggestField from '../Commons/TextFields/UserAutosuggestField';
import actionsCreators from '../../reducers/helpers';

class SitChangeItemForm extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            formatId: 0,
            technicalExpertId: 0,
            kySitId: 0,
            directorOfSitId: 0,
            createrOfBudgetId: 0,
            kyRegionId: 0,
            operationDirectorId: 0
        }
    }

    componentDidMount() {
        const { getFormatsForSelect } = this.props;
        getFormatsForSelect();
    }

    submmit = (event) => {
        event.preventDefault();
        const { save } = this.props;
        const { title,
            formatId,
            technicalExpertId,
            kySitId,
            directorOfSitId,
            createrOfBudgetId,
            kyRegionId,
            operationDirectorId } = this.state;
        const values = {
            title,
            formatId,
            technicalExpertId,
            kySitId,
            directorOfSitId,
            createrOfBudgetId,
            kyRegionId,
            operationDirectorId
        };
        save(values);
    };

    cancel = () => {
        const { cancel } = this.props
        cancel();
    };

    handleChange = (e) => {
        const { name, value } = e.target;
        this.setState({ [name]: value });
    };

    render() {
        const { submitting, error, formats, title } = this.props
        const { formatId } = this.state;

        return (

            <Dialog
                open={true}
                onClose={this.cancel}
                maxWidth={false}
            >
                <DialogTitle id="form-dialog-title">
                    <div style={{ display: 'flex', justifyContent: 'space-between' }}>
                        <div style={{ marginTop: 5 }}>
                            {title}
                        </div>
                    </div>
                </DialogTitle>
                <DialogContent>
                    <form onSubmit={this.submmit}>
                        <div>
                            <TextFieldSelect name="formatId" label="Формат" items={formats && formats.map((r) => ({ value: r.id, text: r.title }))}
                                onChange={this.handleChange} value={formatId} />
                        </div>
                        <div>
                            <TextFieldMultiline name="title" label="Название" onChange={this.handleChange} />
                        </div>
                        <div>
                            <UserAutosuggestField name="technicalExpertId" label="Технический эксперт" onSuggestionSelected={this.handleChange} />
                        </div>
                        <div>
                            <UserAutosuggestField name="kySitId" label="КУ Сита" onSuggestionSelected={this.handleChange} />
                        </div>
                        <div>
                            <UserAutosuggestField name="directorOfSitId" label="Директор Сита" onSuggestionSelected={this.handleChange} />
                        </div>
                        <div>
                            <UserAutosuggestField name="createrOfBudgetId" label="Создатель" onSuggestionSelected={this.handleChange} />
                        </div>
                        <div>
                            <UserAutosuggestField name="kyRegionId" label="КУ региональный" onSuggestionSelected={this.handleChange} />
                        </div>
                        <div>
                            <UserAutosuggestField name="operationDirectorId" label="Операционный директор" onSuggestionSelected={this.handleChange} />
                        </div>

                        {error && <span style={{ color: 'red' }}>{error}</span>}
                        <DialogActions>
                            <Button type="submit" disabled={submitting} variant="raised" color="secondary">Сохранить</Button>
                            <Button onClick={this.cancel} color="secondary">Отмена</Button>
                        </DialogActions>
                    </form>
                </DialogContent>
            </Dialog>
        )
    }


}

SitChangeItemForm.propTypes = {
    title: PropTypes.string,
    cancel: PropTypes.func.isRequired,
    save: PropTypes.func.isRequired,
    submitting: PropTypes.any,
    formats: PropTypes.array.isRequired,
    getProfilesForSelect: PropTypes.func,
    getFormatsForSelect: PropTypes.func,
    error: PropTypes.object
};

const mapDispatchFromProps = { ...actionsCreators }
const mapStateToProps = state => ({ initialValues: state.sits.updatingDataItem, formats: state.helpers.formats })

export default connect(mapStateToProps, mapDispatchFromProps)(SitChangeItemForm);



