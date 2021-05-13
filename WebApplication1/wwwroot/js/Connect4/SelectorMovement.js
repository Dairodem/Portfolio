

let posX = 0;
let currQuadrant = 0;

let selector = document.getElementById("selector");

function moveSelector() {
    currQuadrant = getQuadrant(posX);
    selector.style.left = currQuadrant + 'px';
}
function getQuadrant(pos) {
    let q = Math.floor(pos / 100);

    if (q < 0) {
        q = 0;
    }

    return q * 100;

}