import * as Ajax from './GenericAjaxRequests.js';
import * as SweetAlert from './SweetAlerts.js';

$(document).ready(function () {
    tinymce.init({
        selector: '#description',
    });
   //$('#teams').select2()
    //Ajax.BuildDropDown('teams', '/api/DropDowns/GetTeamsDropDown', 'Select Teams')
    $('#submitteam').click(function () {
        var data = new FormData();
        data.append('TeamName', $('#name').val())
        data.append('Description', tinymce.activeEditor.getContent())
        data.append('LogoFile', $('#logo')[0].files[0])
        data.append('Website', $('#Website').val())
        data.append('FoundationDate', $('#FoundationDate').val())
        var teams = $('#teams').val();
      
        Ajax.SendPostRequestFormData(data, '/api/Teams').then(function (result) {
            if (result.statusCode == 201)
                SweetAlert.SuccessAlert('Add Successfully')
            else
                SweetAlert.ErrorAlert('Error')

            document.getElementById("TeamData").reset();

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