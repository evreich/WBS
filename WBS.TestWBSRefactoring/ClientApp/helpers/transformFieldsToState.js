const transformFieldsToState = (fields) => 
    fields.reduce((fieldsInitObj, currField) => ({
        ...fieldsInitObj,
        [currField.id]: ''
    })
    , {});

export default transformFieldsToState