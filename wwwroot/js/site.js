// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function pasarJugador(e)
{
    var z = document.querySelectorAll(".zonas")
    //console.log("zonas")
    //console.log(z)
    for (let item of z) {
        var l = item.querySelectorAll("td.jugzona")
        //console.log("item")
        //.log(l)
        for (let jugs of l) {
            //console.log("jugs")
            //console.log("jugzona", jugs.textContent)
            if (jugs.textContent.trim() == "") {
                //console.log("vacio")
                jugs.textContent = e.innerText;
                e.parentNode.removeChild(e);
                return;

            }
        }
        }   
}

function readURL(input, output) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            output
                .attr('src', e.target.result)
                .width(150)
                .height(200);
        };

        reader.readAsDataURL(input.files[0]);
    }
}

function generarID(torneo, zona, partido, set, jugador) {
    return torneo * 100000000 + zona * 1000000 + partido * 10000 + set * 100 +jugador

}