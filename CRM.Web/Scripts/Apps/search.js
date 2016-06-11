$(document).ready(function () {
    var table = $('#LatetestInteractionContent').DataTable({
            //"columnDefs": [
            //                { className: "hide_column", "targets": [ 1 ] }
            //              ],
            "paging": false,
            "ordering": false,
            "info": false,
            "searching":false
        });

    $('#LatetestInteractionContent tbody').on('click', 'tr', function () {
        var data = table.row(this).data();
        window.location.href = '/CustomerService/Edit/' + data[1];
        //alert('You clicked on ' + data[1] + '\'s row');
    });
});

$(function () {

    //var latestInteraction=$('#LatetestInteractionContent').dataTable({
    //    "paging": false,
    //    "ordering": false,
    //    "info": false,
    //    "searching":false
    //});
    //console.log(latestInteraction);
    //$('#LatetestInteractionContent tbody').on('click', 'tr', function () {
    //    // alert('Row index: ' + latestInteraction.row(this).index());
    //    var id = this.id();

    //    alert('Clicked row id ' + id);
    //});
    //$("#btnSearch").click(function (evt) {
    //    var frequentFlyerId = $("#FrequentFlyerID").val();
    //    var customerID = $("#CustomerID").val();
    //    var fullName = $("#FullName").val();
    //    var mobile = $("#Mobile").val();
    //    var phone = $("#Phone").val();
    //    var email = $("#Email").val();
    //    var serviceCode = $("#ServiceCode").val();
    //    var productSerial = $("#ProductSerial").val();
    //    var interactionCode = $("#InteractionCode").val();
    //    $("#SearchResultContent").load("/customer/searchResult",
    //        { frequentFlyerId: frequentFlyerId, customerID: customerID, fullName: fullName, mobile: mobile, phone: phone, email: email, serviceCode: serviceCode, productSerial: productSerial, interactionCode: interactionCode, viewName: "CustomerDetails" });
    //});

});

function Search() {
   

    var form = $('form');
    $.validator.unobtrusive.parse(form);
    form.validate();

  //  if (form.valid()) {
   //     alert("Valid");
   // }
  //  return;
    var frequentFlyerId = $("#FrequentFlyerID").val();
    var customerID = $("#CustomerID").val();
    var fullName = $("#FullName").val();
    var mobile = $("#Mobile").val();
    var phone = $("#Phone").val();
    var email = $("#Email").val();
    var serviceCode = $("#ServiceCode").val();
    var productSerial = $("#ProductSerial").val();
    var interactionCode = $("#InteractionCode").val();
    $("#SearchResultContent").load("/search/searchResult",
        { frequentFlyerId: frequentFlyerId, customerID: customerID, fullName: fullName, mobile: mobile, phone: phone, email: email, serviceCode: serviceCode, productSerial: productSerial, interactionCode: interactionCode, viewName: "CustomerDetails" });

    var table= $('#CustomerDetailData').dataTable({
        dom: 'Bfrtip',
        buttons: [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ]
    });

    if ($('#CustomerDetailData tbody tr').length > 0)
        $("#btnAddNew").css("display", "none");
    else       
        $("#btnAddNew").css("display", "block");

    //alert($('#CustomerDetailData tbody tr').length);
    //alert(JSON.stringify(table.page.info()));
    //alert(table);
   // if (!table.data().count()) {
       // alert('Empty table');
   // }
}