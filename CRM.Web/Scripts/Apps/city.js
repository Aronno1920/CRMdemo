$(document).ready(function () {

    $('#CityTableContainer').jtable({
        title: 'The City List',
        paging: true, //Enable paging
        pageSize: 10, //Set page size (default: 10)
        sorting: true, //Enable sorting
        defaultSorting: 'Name ASC', //Set default sorting
        actions: {
            listAction: '/City/index',
            deleteAction: '/City/Delete',
            updateAction: '/City/Edit',
            createAction: '/City/Create'
        },
        fields: {
            ID: {
                key: true,
                create: false,
                edit: false,
                list: false
            },
            Name: {
                title: 'Name',
                width: '23%'
            },            
            CityId: {
                title: 'City',
                width: '12%',
                options: '/City/GetCityTypeID'
            },
            IsActive: {
                title: 'Status',
                width: '12%',
                type: 'checkbox',
                values: { 'false': 'Passive', 'true': 'Active' },
                defaultValue: 'true'
            },
            RecordDate: {
                title: 'Record date',
                width: '15%',
                type: 'date',
                displayFormat: 'dd.mm.yy',
                create: false,
                edit: false,
                sorting: false //This column is not sortable!
            }
        }
    });

    //Load student list from server
    $('#CityTableContainer').jtable('load');
});