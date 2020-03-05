Especial();
$(document).bind("contextmenu", function (e) {
    e.preventDefault();
});
var count = 360
var Clicks = 0
var timer = $.timer(
    function () {
        count--;
        if (count == -8) {
            window.location.href = "ExpiroSesion.aspx";
        }
        else {

            $('.count').html(count);
            if (count <= 30) {
                $find("MpuSession").show();
                TimeField.innerHTML = "Su Sesión Caducara en " + count
                if (count <= 0) {
                    TimeField.innerHTML = "Su Sesión Ha Caducado, Redireccionado "
                }
            }
        }
    },
    1000,
    true
);
function Mover(event) {
    if (Clicks == 0) {
        count = 360;
        $.ajax({
            type: "POST",
            url: "MasterPage.aspx/KeepActiveSession",
            data: "{'Usuario':'" + document.getElementById('LblCat_Lo_Usuario').textContent + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: function (msg) {
                if (msg.d == "Bye") {
                    window.location.href = "ExpiroSesion.aspx";
                }
            }
        });
        Especial(document.getElementById('LblAgenda').textContent)
        Clicks = 0;
    }
    else {
        count = 360;
        Clicks++
    }
};
function Especial(V_Bandera) {
    var $list = $('#rp_list ul');
    var elems_cnt = $list.children().length;
    var $elem0 = $list.find('li:nth-child(' + (1) + ')');
    var $elem1 = $list.find('li:nth-child(' + (2) + ')');
    var $elem2 = $list.find('li:nth-child(' + (3) + ')');
    $elem0.hide();
    $elem1.hide();
    $elem2.show();
    if (V_Bandera == '11') {
        $elem0.show();
        $elem1.show();
    } else if (V_Bandera == '01') {
        $elem1.show();
    }
    else if (V_Bandera == '10') {
        $elem0.show();
    }
    var d = 200;
    $list.find('li:visible div').each(function () {
        $(this).stop().animate({
            'marginLeft': '-30px'
        }, d += 100);
    });
    $list.find('li:visible').live('mouseenter', function () {
        $(this).find('div').stop().animate({
            'marginLeft': '-135px'
        }, 200);
    }).live('mouseleave', function () {
        $(this).find('div').stop().animate({
            'marginLeft': '-30px'
        }, 200);
    });
}