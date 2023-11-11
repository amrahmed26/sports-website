import * as Ajax from './GenericAjaxRequests.js';
import * as SweetAlert from './SweetAlerts.js';
const fullURL = window.location.href;

$(document).ready(function () {
    console.log(fullURL.split('\/')[5])
    tinymce.init({
        selector: '#description',
        setup: function (editor) {
            editor.on('init', function () {
                GetData(); // Call GetData only after TinyMCE is initialized
            });
        }
    })
    $('#teams').select2()
    GetData()
   // Ajax.BuildDropDown('teams', '/api/DropDowns/GetTeamsDropDown', 'Select Teams')
    $('#sumbmittournament').click(function () {
        var data = new FormData();
        data.append('TournamentId', fullURL.split('\/')[5])
        data.append('Name', $('#name').val())
        data.append('Description', tinymce.activeEditor.getContent())
        $('#logo')[0].files[0] == null ? data.append('LogoLink', $('#Logoval').val()) : data.append('Logo', $('#logo')[0].files[0]);
        data.append('TournamentVideo', $('#tournamentVideo').val())
        var teams = $('#teams').val();
        for (var i = 0; i < teams.length; i++) {
            data.append('TeamIds', teams[i])

        }
        Ajax.SendPutRequestFormData(data, '/api/Tournaments').then(function (result) {
            if (result.statusCode == 204)
                SweetAlert.SuccessAlert('Updated Successfully')
            setTimeout(function () {
                location.reload();
            }, 3000);
        }, function (error) {
            SweetAlert.ErrorAlert('Error')

        });
    })

});

function GetData() {
    Ajax.SendGetRequestByAjax('/api/Tournaments/GetForUpdate/' + fullURL.split('\/')[5]).then(function (result) {
        debugger
        if (result.statusCode == 200) {
            var body = result.data
            $('#name').val(result.data[0].name)
            $('#Logoval').val(result.data[0].logo)
            $('#tournamentVideo').val(result.data[0].tournamentVideo)
            $("#logoimg").attr("src", "/uploads/" + result.data[0].logo);
            tinymce.activeEditor.setContent(result.data[0].description);
            $('#video-container iframe').attr('src', result.data[0].tournamentVideo);

            ParseJsonString(result.data[0].teams,'teams')

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
    var data = JSON.parse(collection);
    console.log("Parsed Data:", data);

    $("#" + DropDown).empty();

    var selectedValues = []; // To keep track of selected values and avoid duplicates

    for (var i = 0; i < data.length; i++) {
        var option = $('<option></option>').attr('value', data[i].Id).text(data[i].Name);

        if (data[i].IsSelected == 1 && selectedValues.indexOf(data[i].Id) === -1) {
            option.prop('selected', true);
            selectedValues.push(data[i].Id);
        }

        $("#" + DropDown).append(option);
    }

    console.log("Dropdown HTML:", $("#" + DropDown).html());
}

