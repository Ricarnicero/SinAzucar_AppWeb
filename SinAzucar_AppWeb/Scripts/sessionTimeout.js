window.history.forward();

var MAX_TIME_INACTIVE = 600;
var TIME_TO_DIPLAY_ALERT = 30;
var TIME_TO_CLOSE_SESSION = MAX_TIME_INACTIVE

const init = (timers) => {
    MAX_TIME_INACTIVE = timers.timeout
    TIME_TO_DIPLAY_ALERT = timers.alert
    TIME_TO_CLOSE_SESSION = MAX_TIME_INACTIVE

    document.body.appendChild(createModal())

    $(document).mousemove(() => {
        if (TIME_TO_CLOSE_SESSION <= TIME_TO_DIPLAY_ALERT) $("#ModalSession").modal("hide")
        TIME_TO_CLOSE_SESSION = MAX_TIME_INACTIVE;
    });

    setInterval(() => {
        --TIME_TO_CLOSE_SESSION
        if (TIME_TO_CLOSE_SESSION == 0) window.location.href = "../SesionExpirada.aspx";
        else if (TIME_TO_CLOSE_SESSION <= TIME_TO_DIPLAY_ALERT)
            try {
                $('.count').html(TIME_TO_CLOSE_SESSION);
                $("#ModalSession").modal();
            } catch (e) { }
    }, 1000)
}

const createModal = () => {
    var modal = document.createElement("DIV"),
    dialog = document.createElement("DIV"),
    content = document.createElement("DIV"),
    header = document.createElement("DIV"),
    body = document.createElement("DIV"),
    closeModal = document.createElement("BUTTON"),
    title = document.createElement("h4")

    modal.className = "modal"
    modal.style.zIndex = 9999999
    modal.id = "ModalSession"

    modal.innerHTML = Modal

    return modal
}

const Modal = "<div class='modal-dialog'>" +
                    "<div class='modal-content'>" +
                        "<div class='modal-header'>" +
                            "<h4 class='modal-title'>Sesión inactiva</h4>" +
                            "<button type='button' class='close' data-dismiss='modal'>&times;</button>" +
                        "</div>" +
                        "<div class='modal-body'>" +
                            "<p>Su Sesión Caducara en <span class='count'>0</span> segundos</p>" +
                            "(Mueve el cursor para mantenerte activo)" +
                        "</div>" +
                    "</div>" +
                "</div>"