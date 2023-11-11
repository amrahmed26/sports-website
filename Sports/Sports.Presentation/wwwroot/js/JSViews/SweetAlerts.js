export function SuccessAlert(Message){
   Swal.fire({
                    position: 'center',
                    icon: 'success',
                    title:Message,
                    showConfirmButton: false,
                    timer: 2000
                })
}
export function ErrorAlert(Message){
      Swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: Message,
                    showConfirmButton: false,
                    timer: 2000
                })
}
export function ValidationAlert(Message) {
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