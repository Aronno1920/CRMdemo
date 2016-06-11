$(function () {
    alert("alert ALARM!!!");
    $(function () {
    //    $('#SingleSelectGrid')
    //        .on('aweselect', function () {
    //            var selectedItems = $('#SingleSelectGrid').data('api').getSelection();
    //            $('#selection2').html(JSON.stringify(selectedItems));
    //        })
    //        .on('aweload', function () {
    //            $('#selection2').empty();
    //        });
    //});
    $('#ServiceTypeID').change(function () {
        var typeSelected = $('#ServiceTypeID :selected').val();
        //alert(typeSelected);
       // return;
        typeSelected = typeSelected == "" ? 0 : typeSelected;
        //When select 'optionLabel' we need to reset it to default as well. So not need 
        //travel back to server.
        if (typeSelected == "") {
            $('#ServiceTypeDetailID').empty();
            $('#ServiceTypeDetailID').append('<option value="">--Select a Type--</option>'); 
            return;
        }
        $('#ServiceAdditionalDetailID').empty();
        $('#ServiceAdditionalDetailID').append('<option value="">--Select a Type Detail--</option>');

        $('#ServiceSupplementalDetailID').empty();
        $('#ServiceSupplementalDetailID').append('<option value="">--Select an Additional Detail--</option>');
        //This is where the dropdownlist cascading main function
        $.ajax({
            type: "POST",
            url: "GetDDLdata",                            //Your Action name in the DropDownListConstroller.cs
            data: "{'typeSelected':" + typeSelected + ",'ddlType':'typeDetail'}",  //Parameter in this function, Is cast sensitive and also type must be string
            contentType: "application/json; charset=utf-8",
            dataType: "json"

        }).done(function (data) {
            //When succeeded get data from server construct the dropdownlist here.
            if (data != null) {
                
                $('#ServiceTypeDetailID').empty();
                $.each(data, function (index, data) {
                    //alert("Done");
                    $('#ServiceTypeDetailID').append('<option value="' + data.Value + '">' + data.Text + '</option>');
                });
            }
        }).fail(function (response) {
            if (response.status != 0) {
                alert(response.status + " " + response.statusText);
            }
        });
    });

    //Additiona Detail DDL Functions
    $('#ServiceTypeDetailID').change(function () {
        var typeSelected = $('#ServiceTypeDetailID :selected').val();
        //alert(typeSelected);
        // return;
        typeSelected = typeSelected == "" ? 0 : typeSelected;
        //When select 'optionLabel' we need to reset it to default as well. So not need 
        //travel back to server.
        if (typeSelected == "") {           
            $('#ServiceAdditionalDetailID').empty();
            $('#ServiceAdditionalDetailID').append('<option value="">--Select a Type Detail--</option>');
            return;
        }
        $('#ServiceSupplementalDetailID').empty();
        $('#ServiceSupplementalDetailID').append('<option value="">--Select an Additional Detail--</option>');

        //This is where the dropdownlist cascading main function
        $.ajax({
            type: "POST",
            url: "GetDDLdata",                            //Your Action name in the DropDownListConstroller.cs
            data: "{'typeSelected':" + typeSelected + ",'ddlType':'additionalDetail'}",  //Parameter in this function, Is cast sensitive and also type must be string
            contentType: "application/json; charset=utf-8",
            dataType: "json"

        }).done(function (data) {
            //When succeeded get data from server construct the dropdownlist here.
            if (data != null) {

                $('#ServiceAdditionalDetailID').empty();
                $.each(data, function (index, data) {
                    //alert("Done");
                    $('#ServiceAdditionalDetailID').append('<option value="' + data.Value + '">' + data.Text + '</option>');
                });
            }
        }).fail(function (response) {
            if (response.status != 0) {
                alert(response.status + " " + response.statusText);
            }
        });
    });
    //Supplemental Detail DDL Functions
    $('#ServiceAdditionalDetailID').change(function () {
        var typeSelected = $('#ServiceAdditionalDetailID :selected').val();
        //alert(typeSelected);
        // return;
        typeSelected = typeSelected == "" ? 0 : typeSelected;
        //When select 'optionLabel' we need to reset it to default as well. So not need 
        //travel back to server.
        if (typeSelected == "") {
            $('#ServiceSupplementalDetailID').empty();
            $('#ServiceSupplementalDetailID').append('<option value="">--Select an Additional Detail--</option>');

            return;
        }

        //This is where the dropdownlist cascading main function
        $.ajax({
            type: "POST",
            url: "GetDDLdata",                            //Your Action name in the DropDownListConstroller.cs
            data: "{'typeSelected':" + typeSelected + ",'ddlType':'supplementalDetail'}",  //Parameter in this function, Is cast sensitive and also type must be string
            contentType: "application/json; charset=utf-8",
            dataType: "json"

        }).done(function (data) {
            //When succeeded get data from server construct the dropdownlist here.
            if (data != null) {

                $('#ServiceSupplementalDetailID').empty();
                $.each(data, function (index, data) {
                    //alert("Done");
                    $('#ServiceSupplementalDetailID').append('<option value="' + data.Value + '">' + data.Text + '</option>');
                });
            }
        }).fail(function (response) {
            if (response.status != 0) {
                alert(response.status + " " + response.statusText);
            }
        });
    });
});