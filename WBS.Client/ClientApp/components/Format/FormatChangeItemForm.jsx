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
import TextFieldPlaceholder from '../Commons/TextFields/TextFieldPlaceholder';
import actionsCreators from '../../reducers/helpers';
import UserAutosuggestField from '../Commons/TextFields/UserAutosuggestField';

class FormatChangeItemForm extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            title: '',
            profile: '',
            directorOfFormatId: null,
            directorOfKYFormatId: null,
            kyFormatId: null,
            typeOfFormat: '',
            e1Limit: 0,
            e2Limit: 0,
            e3Limit: 0,
        }

    }
    componentDidMount() {
        const { getProfilesForSelect } = this.props;
        getProfilesForSelect()
    }
    static getDerivedStateFromProps(nextProps) {
        return nextProps ? { ...nextProps.data } : null
    }

    submmit = (event) => {
        event.preventDefault();
        const { save } = this.props;
        const values = { ...this.state };
        save(values);

    }

    handleChange = (e) => {
        const { name, value } = e.target;
        this.setState({ [name]: value });
    }

    cancel = () => {
        const { cancel } = this.props
        cancel();
    }

    render() {
        const { error, header } = this.props
        const {
      title,
            profile,
            typeOfFormat,
            e1Limit,
            e2Limit,
            e3Limit } = this.state

        return (

            <Dialog
                open={true}
                onClose={this.cancel}
                maxWidth={false}
            >
                <DialogTitle id="form-dialog-title">
                    <div style={{ display: 'flex', justifyContent: 'space-between' }}>
                        <div style={{ marginTop: 5 }}>
                            {header}
                        </div>
                    </div>
                </DialogTitle>
                <DialogContent>
                    <form onSubmit={this.submmit}>
                        <div>
                            <TextFieldMultiline name="title" value={title} label="Название" component={TextFieldMultiline} onChange={this.handleChange} />
                        </div>
                        <div>
                            <TextFieldMultiline name="profile" value={profile} label="Профиль" component={TextFieldMultiline} onChange={this.handleChange} />
                        </div>
                        <div>
                            <UserAutosuggestField name="directorOfFormatId" label="Директор Формата" onSuggestionSelected={this.handleChange} />
                        </div>
                        <div>
                            <UserAutosuggestField name="directorOfKYFormatId" label="Директор КУ Формата" onSuggestionSelected={this.handleChange} />
                        </div>
                        <div>
                            <UserAutosuggestField name="kyFormatId" label="КУ Формат" onSuggestionSelected={this.handleChange} />
                        </div>
                        <div>
                            <TextFieldMultiline name="typeOfFormat" value={typeOfFormat} label="Тип Формата" onChange={this.handleChange} />
                        </div>
                        <div>
                            <TextFieldPlaceholder name="e1Limit" value={e1Limit} label="E1" type="number" onChange={this.handleChange} />
                        </div>
                        <div>
                            <TextFieldPlaceholder name="e2Limit" value={e2Limit} label="E2" type="number" onChange={this.handleChange} />
                        </div>
                        <div>
                            <TextFieldPlaceholder name="e3Limit" value={e3Limit} label="E3" type="number" onChange={this.handleChange} />
                        </div>
                        {error && <span style={{ color: 'red' }}>{error}</span>}
                        <DialogActions>
                            <Button type="submit" variant="raised" color="secondary">
                                Сохранить
                </Button>
                            <Button onClick={this.cancel} color="secondary">
                                Отмена
                </Button>
                        </DialogActions>
                    </form>
                </DialogContent>
            </Dialog>
        )
    }
}


FormatChangeItemForm.propTypes = {
    header: PropTypes.string,
    cancel: PropTypes.func.isRequired,
    save: PropTypes.func.isRequired,
    getProfilesForSelect: PropTypes.func,
    error: PropTypes.object
};

const mapDispatchFromProps = { ...actionsCreators }
const mapStateToProps = () => { }

export default (connect(mapStateToProps, mapDispatchFromProps)(FormatChangeItemForm))



