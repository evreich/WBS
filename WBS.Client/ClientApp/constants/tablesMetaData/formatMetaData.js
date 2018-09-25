export default {
    id: 'Format',
    title: 'Форматы ситов',
    showViewIcon: false,
    columns: [
        {
            header: 'Название',
            field: 'title',
            sortable: true
        },
        {
            header: 'Профиль',
            field: 'profile',
            sortable: true
        },
        {
            header: 'Директор Формата',
            field: 'directorOfFormatFio',
            sortable: true
        },
        {
            header: 'Директор КУ Формата',
            field: 'directorOfKYFormatFio',
            sortable: true
        },
        {
            header: 'КУ Формат',
            field: 'kyFormatFio',
            sortable: true
        },
        {
            header: 'Тип Формата',
            field: 'typeOfFormat',
            sortable: true
        },
        {
            header: 'E1',
            field: 'e1Limit',
            sortable: true
        },
        {
            header: 'E2',
            field: 'e2Limit',
            sortable: true
        },
        {
            header: 'E3',
            field: 'e3Limit',
            sortable: true
        }
    ]
};

