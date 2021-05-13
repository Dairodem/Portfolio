
let playerColor = "yellow";

function ChangeColor(colorName) {
    chip.removeAttribute("class");
    chip.classList.add("chip");
    chip.classList.add(colorName);

    selector.removeAttribute("class");
    selector.classList.add("colSelect");
    selector.classList.add("border-" + colorName);

}
function changePlayerName(name) {
    let lbl = document.getElementById("currPlayerColor");
    lbl.removeAttribute("class");
    lbl.classList.add("currplayer");
    lbl.classList.add("player-" + name);
    lbl.innerHTML = name.toUpperCase();
}