
$(document).ready(function () {

    loadData()
});

function loadData() {
    debugger
    $.ajax({
        type: 'Get',
        url: "/api/Tournaments",
        success: function (datarecord) {
            console.log(datarecord)
            $('#Data').DataTable({
                data: datarecord.data,

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
                            return '<a class="btn btn-info" href="/Tournaments/editTournament/'+data+'" >Edit</a> ' +
                                '<button class="btn btn-danger" onclick="deleteRow(' + data + ')">Delete</button>';
                        }
                    }
                ]
            });
        }
        })

}


function deleteRow(id) {
    SendDeleteRequest('/api/Tournaments/' + id).then(function (result) {
            SuccessAlert('Deleted')
            setTimeout(function () {
                location.reload();
            }, 3000);
        

    }, function (error) {
       ErrorAlert('Error')

    });
}




function SendDeleteRequest(Url) {
    return $.ajax({
        type: "Delete",
        url: Url,
        contentType: "application/json"


    });
}
 function SuccessAlert(Message) {
    Swal.fire({
        position: 'center',
        icon: 'success',
        title: Message,
        showConfirmButton: false,
        timer: 2000
    })
}
 function ErrorAlert(Message) {
    Swal.fire({
        position: 'center',
        icon: 'error',
        title: Message,
        showConfirmButton: false,
        timer: 2000
    })
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