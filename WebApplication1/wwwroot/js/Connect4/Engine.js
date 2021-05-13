let allChips = [];
let chipCount = 0;

function startGame() {
    gameState.start();
    ChangeColor(playerColor);
}

var gameState =
{
    start: function () {
        this.interval = setInterval(update, 20);
    },
    stop: function () {
        clearInterval(this.interval);
    }
}

function update() {
    if (isfalling) {
        moveDown(currChip);
    }
    if (isWinner) {
        console.log(playerColor + " has won!");
        let playerscore = document.getElementById("score-" + playerColor);
        let score = parseInt(playerscore.innerHTML);
        score++;
        playerscore.innerHTML = score.toString();
        gameState.stop();
        resetBoard();

        if (score === (parseInt(rounds / 2)) + 1) {
            gameOver(playerColor);
        }
    }
}
function resetBoard() {
    //remove all chips
    getAllChips();

    for (let i = 0; i < chipCount; i++) {
        let elem = allChips[0].remove();
    }
    //clear field
    clearField();
    resetPositionArr();


    //change startplayer
    ChangeColor(playerColor === "yellow" ? currColor = "red" : currColor = "yellow");
    playerColor = currColor;
    changePlayerName(playerColor);
    isWinner = false;
    gameState.start();

}
function getAllChips() {
    allChips = document.getElementsByClassName("chipindex");
    chipCount = allChips.length;
}
function gameOver(winnerName) {
    console.log(winnerName + " has won the Game!");
    gameState.stop();
}