const transformFieldsToState = (fields) => 
    fields.reduce((fieldsInitObj, currField) => ({
        ...fieldsInitObj,
        [currField.propName]: ''
    })
    , {});

export default transformFieldsToState