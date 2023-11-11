import * as Ajax from './GenericAjaxRequests.js';
import * as SweetAlert from './SweetAlerts.js';
const fullURL = window.location.href;

$(document).ready(function () {
    tinymce.init({
        selector: '#description', setup: function (editor) {
            editor.on('init', function () {
                GetData(); // Call GetData only after TinyMCE is initialized
            });
        }
    });
    //$('#teams').select2()
    //Ajax.BuildDropDown('teams', '/api/DropDowns/GetTeamsDropDown', 'Select Teams')
    $('#submitteam').click(function () {
        var data = new FormData();
        data.append('TeamId', fullURL.split('\/')[5])
        data.append('TeamName', $('#name').val())
        data.append('FoundationDate', $('#FoundationDate').val())
        data.append('Description', tinymce.activeEditor.getContent())
        $('#logo')[0].files[0] == null ? data.append('Logo', $('#Logo').val()) : data.append('LogoFile', $('#logo')[0].files[0])
        data.append('Website', $('#Website').val())

        Ajax.SendPutRequestFormData(data, '/api/Teams').then(function (result) {
            if (result.statusCode == 204) {
                SweetAlert.SuccessAlert('Add Successfully')
 setTimeout(function () {
                location.reload();
            }, 3000);
            }
            else
                SweetAlert.ErrorAlert('Error')

           
        }, function (error) {
            SweetAlert.ErrorAlert('Error')

        });
    })

});
function GetData() {
    Ajax.SendGetRequestByAjax('/api/Teams/' + fullURL.split('\/')[5]).then(function (result) {
        debugger
        if (result.statusCode == 200) {
            $('#name').val(result.data.teamName)
            $('#Website').val(result.data.website)
            $('#Logo').val(result.data.logo)
            $('#FoundationDate').val(result.data.foundationDate.split('T')[0])
            $("#logoimg").attr("src", "/uploads/" + result.data.logo);
            tinymce.activeEditor.setContent(result.data.description);


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