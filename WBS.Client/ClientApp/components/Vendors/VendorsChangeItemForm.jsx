import React from "react";
import PropTypes from "prop-types";
import Dialog, {
    DialogActions,
    DialogContent,
    DialogTitle
} from "material-ui/Dialog";
import Button from "material-ui/Button";
import { connect } from "react-redux";
import TextFieldMultiline from "../Commons/TextFields/TextFieldMultiline";
import TextFieldMultiSelect from '../Commons/TextFields/TextFieldMultiSelect'
import actionsCreators from '../../reducers/helpers';

class FormatChangeItemForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            title: "",
            profile: []
        };
    }

    componentDidMount() {
      const {getTechnicalsServsSelect} = this.props;
      getTechnicalsServsSelect()
     }

    handleChange = (e) => {
      const { name, value } = e.target;
      this.setState({ [name]: value });
    }

    submmit = (event) => {
      event.preventDefault()
      const { save } = this.props;
      const { title, profile } = this.state
      const values = { title, profile }
      save(values)    
    }

    cancel = () => {
        const { cancel } = this.props;
        cancel();
    };

    render() {
      const { errors, header, technicalServs } = this.props;
      const { title, profile } = this.state;
        return (
            <Dialog open={true} onClose={this.cancel} maxWidth={false}>
                <DialogTitle id="form-dialog-title">
                    <div
                        style={{
                            display: "flex",
                            justifyContent: "space-between"
                        }}
                    >
                        <div style={{ marginTop: 5 }}>{header}</div>
                    </div>
                </DialogTitle>
                <DialogContent>
                    <form onSubmit={this.submmit}>
                        <div>
                            <TextFieldMultiline
                                name="title"
                                value={title}
                                label="Название"
                                onChange={this.handleChange}
                            />
                        </div>
                        <div>
                            <TextFieldMultiSelect
                                name="profile"
                                values={profile}
                                label="Профиль"
                                onChange={this.handleChange}
                                items={technicalServs &&technicalServs.map((r) => ({ value: r.id, text: r.title}))}
                            />
                        </div>
                        {errors && <span style={{ color: "red" }}>{errors.error}</span>}
                        <DialogActions>
                            <Button
                                type="submit"
                                variant="raised"
                                color="secondary"
                            >
                                Сохранить
                            </Button>
                            <Button onClick={this.cancel} style={{color: 'green'}}>
                                Отмена
                            </Button>
                        </DialogActions>
                    </form>
                </DialogContent>
            </Dialog>
        );
    }
}

FormatChangeItemForm.propTypes = {
  header: PropTypes.string,
  cancel: PropTypes.func.isRequired,
  save: PropTypes.func.isRequired,
  errors: PropTypes.object.isRequired,
  getTechnicalsServsSelect: PropTypes.func,
  technicalServs: PropTypes.object.isRequired,
};

const mapStateToProps = state => ({
   errors: state.monolithic.errors,
   technicalServs: state.helpers.technicalServs
});

const mapDispatchToProps = {
  ...actionsCreators
}
export default connect(mapStateToProps, mapDispatchToProps)(FormatChangeItemForm);
