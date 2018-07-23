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

class CategoryGroupsChangeItemForm extends React.Component {
  constructor(props) {
    super(props)
    this.state = {
      title: '',
      code: ''
    }  
  }

  cancel = () => {
    const { cancel } = this.props
    cancel();
  }

  static getDerivedStateFromProps(nextProps){       
    return nextProps? {...nextProps.data} : null      
} 

  handleChange = (e) => {
    const { name, value } = e.target;
    this.setState({ [name]: value });
  }

    submmit = (event) => {
        event.preventDefault();
        const { save } = this.props;
        const { title, code } = this.state;
        const values = { title, code };
        save(values);

  }

  render() {
    const { errors, header } = this.props
    const { title, code } = this.state
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
              <TextFieldMultiline label="Название" type="text" name="title" value={title} onChange={this.handleChange} />
            </div>
            <div>
              <TextFieldPlaceholder label="Код" type="number" name="code" value={code} onChange={this.handleChange} />
            </div>
            {errors && <span style={{ color: 'red' }}>{errors.error}</span>}
            <DialogActions>
              <Button onClick={this.cancel} style={{color: 'white', background:'red'}}>
                Отмена
              </Button>
              <Button type="submit" variant="raised" style={{color: 'white', background:'green'}}>
                Сохранить
              </Button>


            </DialogActions>
          </form>
        </DialogContent>
      </Dialog>
    )
  }


}

CategoryGroupsChangeItemForm.propTypes = {
  header:  PropTypes.string,
  title: PropTypes.string,
  cancel: PropTypes.func.isRequired,
  save: PropTypes.func.isRequired,
  errors: PropTypes.object.isRequired
};

const mapDispatchFromProps = { ...actionsCreators }
const mapStateToProps = (state) => ({ errors: state.monolithic.errors })

export default (connect(mapStateToProps, mapDispatchFromProps)(CategoryGroupsChangeItemForm))



