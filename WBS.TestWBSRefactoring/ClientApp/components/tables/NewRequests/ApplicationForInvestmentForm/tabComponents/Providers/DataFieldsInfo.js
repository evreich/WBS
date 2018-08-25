import DataFieldsInfo from 'components/tables/Providers/DataFieldsInfo';

const newDataFieldsInfo = {
    ...DataFieldsInfo,
    //Добавляем столбец для кнопок "Добавить"
    tableHeaders: {
        ...DataFieldsInfo.tableHeaders,
        add: {}
    }
};

export default newDataFieldsInfo;