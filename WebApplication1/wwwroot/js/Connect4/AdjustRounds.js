

let minRounds = 3;
let maxRounds = 11;

updateLblRounds();

function changeRounds(amount) {
    let temp = rounds;
    temp += amount;
    if (temp > (minRounds - 1) && temp < (maxRounds + 1)) {
        rounds = temp;
        updateLblRounds();
    }
}
function updateLblRounds() {
    document.getElementById("lblRounds").innerHTML = rounds;
}