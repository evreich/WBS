export default {
    id: 'CategoriesOfEquipment',
    title: 'Категории оборудования',
    showViewIcon: false,
    columns: [
        {
            header: 'Группа категории',
            field: 'categoryGroupTitle',
            sortable: true
        },
        {
            header: 'Код',
            field: 'code',
            sortable: true
        },
        {
            header: 'Название',
            field: 'title',
            sortable: true
        },
        {
            header: 'Амортизация, лет.',
            field: 'depreciationPeriod',
            sortable: true
        }
    ]
};