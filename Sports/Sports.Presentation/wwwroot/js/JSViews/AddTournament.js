import * as Ajax from './GenericAjaxRequests.js';
import * as SweetAlert from './SweetAlerts.js';

$(document).ready(function () {
    tinymce.init({
        selector: '#description',
    });
    $('#teams').select2()
    Ajax.BuildDropDown('teams', '/api/DropDowns/GetTeamsDropDown','Select Teams')
    $('#sumbmittournament').click(function () {
        var data = new FormData();
        data.append('Name', $('#name').val())
        data.append('Description', tinymce.activeEditor.getContent())
        data.append('Logo', $('#logo')[0].files[0])
        data.append('TournamentVideo', $('#tournamentVideo').val())
        var teams = $('#teams').val();
        for (var i = 0; i < teams.length; i++) {
        data.append('TeamIds',teams[i])

        }
        Ajax.SendPostRequestFormData(data, '/api/Tournaments').then(function (result) {
            if (result.statusCode == 201)
                SweetAlert.SuccessAlert('Add Successfully')
            document.getElementById("TournamentData").reset();

        }, function (error) {
            SweetAlert.ErrorAlert('Error')

        });
    })

});










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