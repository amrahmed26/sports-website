
var Id;
$(document).ready(function () {

    loadData()


});

function loadData() {
    debugger
    $.ajax({
        type: 'Get',
        url: "/api/Teams",
        success: function (datarecord) {
            console.log(datarecord)
            $('#Data').DataTable({
                data: datarecord.data,

                columns: [
                    { "data": "teamName" },
                    {
                        "data": "logo",
                        "render": function (data, type, row) {
                            return '<img src="/uploads/' + data + '" alt="Image" width="50" height="50">';
                        }
                    },
                    {
                        "data": "teamId",
                        "render": function (data, type, row) {
                            return '<a class="btn btn-info" href="/Teams/editTeam/' + data + '" >Edit</a> ' +
                                '<button class="btn btn-danger" id="DeleteButton"  onclick="deleteTeam(' + data + ')">Delete</button>';
                        }
                    }
                ]
            });
        }
    })

}


function deleteTeam(id) {
     debugger
    SendDeleteRequest('/api/Teams/' + id).then(function (result) {
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