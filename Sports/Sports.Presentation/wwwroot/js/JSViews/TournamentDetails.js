import * as Ajax from './GenericAjaxRequests.js';
import * as SweetAlert from './SweetAlerts.js';
const fullURL = window.location.href;

$(document).ready(function () {
    console.log(fullURL.split('\/')[5])

    $('#teams').select2()
    GetData()
    // Ajax.BuildDropDown('teams', '/api/DropDowns/GetTeamsDropDown', 'Select Teams')

});

function GetData() {
    Ajax.SendGetRequestByAjax('/api/Tournaments/GetForUpdate/' + fullURL.split('\/')[5]).then(function (result) {
        debugger
        if (result.statusCode == 200) {
            var body = result.data
            $('#name').val(result.data[0].name)
            //$('#tournamentVideo').val(result.data[0].tournamentVideo)
            $("#logoimg").attr("src", "/uploads/" + result.data[0].logo);
            $('#video-container iframe').attr('src', result.data[0].tournamentVideo);
            $('#description').html(result.data[0].description)
            ParseJsonString(result.data[0].teams, 'teams')

        }

    }, function (error) {
        SweetAlert.ErrorAlert('Error')

    });
}

function ValidationAlert(Message) {
    Swal.fire({
        title: Message,
        showClass: {
            popup: 'animate__animated animate__fadeInDown'
        },
        hideClass: {
            popup: 'animate__animated animate__fadeOutUp'
        }
    })
}
function ParseJsonString(collection, DropDown) {
    var data = JSON.parse(collection)
    debugger
    $("#" + DropDown + '').empty();

    for (var i = 0; i < data.length; i++) {
        if (data[i].IsSelected == 1) {
            $("#" + DropDown + '').append($('<option selected></option>').attr('value', data[i].Id).text(data[i].Name));

        }
        else if (data[i].IsSelected == 0) {
            $("#" + DropDown + '').append($('<option></option>').attr('value', data[i].Id).text(data[i].Name));

        }

    }
}