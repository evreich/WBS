import React from "react";
import PropTypes from "prop-types";
import { Field } from 'redux-form'

import fields from '../../../../../constants/textfields';

class MainFormBody extends React.PureComponent {

    render() {
        const { classes } = this.props;
        return (
            <>
            <div className={classes.flexRow}>
                <Field name="requestNumber"
                    component={fields['TextFieldPlaceholder']}
                    type="text"
                    placeholder="номер заявки"
                />
                <Field name="siteId"
                    component={fields['SiteSelect']}
                    type="text"
                    placeholder="название сита"
                />
                <Field name="siteMain"
                    component={fields['TextFieldPlaceholder']}
                    type="text"
                    placeholder="ответственный в сите"
                />
                </div>
                <div className={classes.flexRow}>
                    <Field name="requestNumber"
                        component={fields['TextFieldPlaceholder']}
                        type="text"
                        placeholder="дата утверждения директором"
                    />
                    <Field name="requestNumber"
                        component={fields['ResultCenterSelect']}
                        type="text"
                        placeholder="центр результата"
                    />
                    <Field name="requestNumber"
                        component={fields['TextFieldPlaceholder']}
                        type="text"
                        placeholder="желаемый срок поставки"
                    />
                </div>
                <div className={classes.flexRow}>
                    <Field name="requestNumber"
                        component={fields['TextFieldPlaceholder']}
                        type="text"
                        placeholder="текущий этап"
                    />
                </div>
            </>
        );
    }
}

MainFormBody.propTypes = {
    classes: PropTypes.object
};

export default MainFormBody;
