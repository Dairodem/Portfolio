let allChips = [];
let chipCount = 0;

function startGame()
{
    gameState.start();
    setScoreNeeded();
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
    if (isfalling)
    {
        moveDown(currChip);
    }
    if (isWinner)
    {
        SetLblScoreText(playerColor + " has won!");
        let score = IncreaseScore(playerColor);
        gameState.stop();

        if (score === scoreNeeded)
        {
            gameOver(playerColor);
        }
        else
        {
            ResetBoard();
        }
    }
}
function StartNewGame()
{
    rounds = parseInt(document.getElementById("lblRounds").innerHTML);
    ResetScoreBoard();
    setAllScoreChips();
    ResetBoard();
}
function ResetBoard()
{
    //remove all chips
    getAllChips();

    for (let i = 0; i < chipCount; i++)
    {
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
function gameOver(winnerName)
{
    SetLblScoreText(winnerName + " has won the Game!");
}
