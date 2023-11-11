
export function BuildDropDown(dropdownId, url, Message) {

    $.ajax({
        type: "Get",
        url: url,
        success: function (results) {
            $("#" + dropdownId + '').empty();
            $("#" + dropdownId + '').append($('<option selected></option>').attr('value', 0).text(Message));

            $.each(results, function (i, result) {

                $("#" + dropdownId + '').append($('<option></option>').attr('value', result.id).text(result.name));


            });
        }
    })
}
export function BuildDropDowns(dropdownIds, url, Message) {
    //  $("#" + dropdownIds + "").select2();
    //   $("#" + dropdownIds + "").trigger("change");
    $.ajax({
        type: "Get",
        url: url,
        success: function (results) {


            for (var i = 0; i < dropdownIds.length; i++) {
                $("#" + dropdownIds[i] + '').empty();
                $("#" + dropdownIds[i] + '').append($('<option></option>').attr('value', 0).text(Message));
                for (var j = 0; j < results.length; j++) {


                    $("#" + dropdownIds[i] + '').append($('<option></option>').attr('value', results[j].id).text(results[j].name));
                }

            }

        }
    })
}
export function BuildDropDownBasedOnSelection(dropdownId, subDropDownId, url, message) {

    var subDropDown = $('#' + subDropDownId + '');
    var superDropDown = $('#' + dropdownId + '').val();
    subDropDown.empty();
    $.ajax({
        type: "Get",
        url: url + superDropDown + "",
        success: function (results) {
            subDropDown.append($('<option></option>').attr('value', 0).text(message));
            $.each(results, function (i, result) {


                subDropDown.append($('<option></option>').attr('value', result.id).text(result.name));


            });
        }
    })
}
export function SendAjaxToGetArray(collection, url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (results) {


            $.each(results, function (i, result) {

                var obj = new Object();
                obj.Id = result.id; obj.Value = result.name;
                collection.push(obj);


            });
        }
    })
}
export function SendPostRequest(model,Url) {
    return  $.ajax({
        type: "Post",
        url: Url,
        data: JSON.stringify(model),
        contentType: "application/json"
       

    });
}
export function SendPostRequestFormData(model, Url) {
    return  $.ajax({
        type: "Post",
        url: Url,
        data: model,
        processData: false, // Prevent jQuery from automatically transforming the data into a query string
        contentType: false,    
       

    });
}export function SendPutRequestFormData(model, Url) {
    return  $.ajax({
        type: "Put",
        url: Url,
        data: model,
        processData: false, // Prevent jQuery from automatically transforming the data into a query string
        contentType: false,    
       

    });
}
export function SentGetRequestByAxios(Url) {
    return axios.get(Url)
        .then(function (response) {
          
            return response.data;
           
            
        })
        .catch(function (error) {
            console.error('GET request error:', error);
        });

}
export function SendGetRequestByAjax(url) {
    return $.ajax({
        type: 'GET',
        url: url,
        dataType: 'json', // Specify the expected data type
    });
}
export function SendPutRequest(Object, Url) {
    return $.ajax({
        type: "Put",
        url: Url,
        data: JSON.stringify(Object),
        contentType: "application/json"


    });
}
export function SendDeleteRequest(Url) {
    return $.ajax({
        type: "Delete",
        url: Url,
        data: JSON.stringify(Object),
        contentType: "application/json"


    });
}
