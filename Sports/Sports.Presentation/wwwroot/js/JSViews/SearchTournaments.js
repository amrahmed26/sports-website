import * as Ajax from './GenericAjaxRequests.js';
import * as SweetAlert from './SweetAlerts.js';

$(document).ready(function () {
    $('#Data').DataTable()
    $('#submitKey').click(function () {
        Ajax.SendGetRequestByAjax('/api/Tournaments/SearchTournamentByTitle/' + $('#Key').val()).then(function (result) {
            if (result.statusCode == 200) {
                $('#Data').DataTable().destroy();
                console.log(result.data.name)
                $('#Data').DataTable({
                    data: result.data,

                    columns: [
                        { "data": "name" },
                        {
                            "data": "logo",
                            "render": function (data, type, row) {
                                return '<img src="/uploads/' + data + '" alt="Image" width="50" height="50">';
                            }
                        },
                        {
                            "data": "tournamentId",
                            "render": function (data, type, row) {
                                return '<a class="btn btn-info" href="/Tournaments/Details/' + data +'" >Details</a> ';
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




