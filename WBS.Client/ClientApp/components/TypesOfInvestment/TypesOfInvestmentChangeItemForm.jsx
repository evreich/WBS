import React from 'react';
import PropTypes from 'prop-types';
import Dialog, {
    DialogActions,
    DialogContent,
    DialogTitle,
} from 'material-ui/Dialog';
import Button from 'material-ui/Button';
import { connect } from 'react-redux'
import TextFieldMultiline from '../Commons/TextFields/TextFieldMultiline'
import TextFieldPlaceholder from '../Commons/TextFields/TextFieldPlaceholder'
import actionsCreators from '../../reducers/helpers';

class ChangeItemForm extends React.Component {

    static getDerivedStateFromProps(nextProps){       
        return nextProps? {...nextProps.data} : null      
    } 

    submmit = (event) => {
        event.preventDefault();
        const { save } = this.props;
        const { title, code, externalCode } = this.state;
        const values = { title, code, externalCode };
        save(values);

    }

    cancel = () => {
        const { cancel } = this.props;
        cancel();
    }

    handleChange = (e) => {
        const { name, value } = e.target;
        this.setState({ [name]: value });
    }

    render() {
        const { submitting, error, header } = this.props;
        const { title, code, externalCode } = this.state
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
                            <TextFieldMultiline name="title" value={title} label="Название" onChange={this.handleChange}/>
                        </div>
                        <div>
                            <TextFieldPlaceholder name="code" value={code} label="Код" type="number" onChange={this.handleChange} />
                        </div>
                        <div>
                            <TextFieldPlaceholder name="externalCode" value={externalCode} label="Внешний код" type="number" onChange={this.handleChange}/>
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

ChangeItemForm.propTypes = {
    header: PropTypes.string,
    cancel: PropTypes.func.isRequired,
    save: PropTypes.func.isRequired,
    submitting: PropTypes.any,
    error: PropTypes.object
};

const mapDispatchFromProps = { ...actionsCreators };
const mapStateToProps = state => ({ initialValues: state.typesOfInvestment.updatingDataItem });

export default connect(mapStateToProps, mapDispatchFromProps)(ChangeItemForm);



