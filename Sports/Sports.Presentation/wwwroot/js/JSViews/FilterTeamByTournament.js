import * as Ajax from './GenericAjaxRequests.js';
import * as SweetAlert from './SweetAlerts.js';

$(document).ready(function () {
   
    $('#Tournaments').select2()
    Ajax.BuildDropDown('Tournaments', '/api/DropDowns/GetTournamentsDropDown', 'Select Tournament')
    $('#Tournaments').change(function () {
        Ajax.SendGetRequestByAjax('/api/Teams/GetTeamsByTournament/' + $('#Tournaments').val()).then(function (result) {
            if (result.statusCode == 200) {
                $('#Data').DataTable().destroy();

                $('#Data').DataTable({
                    data: result.data,

                    columns: [
                        { "data": "teamName" },
                        {
                            "data": "logo",
                            "render": function (data, type, row) {
                                return '<img src="/uploads/' + data + '" alt="Image" width="50" height="50">';
                            }
                        },
                        
                    ]
                });



            }

        }, function (error) {
            SweetAlert.ErrorAlert('Error')

        });
    })

});




