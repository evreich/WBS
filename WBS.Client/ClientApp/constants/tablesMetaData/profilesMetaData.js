export default {
    id: 'Profiles',
    title: 'Пользователи',
    columns: [
        {
            header: 'ФИО',
            field: 'fio',
            sortable: true
        },
        {
            header: 'Подразделение',
            field: 'department',
            sortable: true
        },
        {
            header: 'Должность',
            field: 'jobPosition',
            sortable: true
        },
        {
            header: 'Помечено на удаление',
            field: 'deletionMark',
            sortable: true
        }
    ]
};