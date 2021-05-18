
/*
 *---- Declarations
 */
let rounds = 3;
let scoreNeeded = 0;
let scoreYellow = 0;
let scoreRed = 0;
let isWinner = false;
let posArr = [300, 300, 300, 300, 300, 300];
let field =
    [
        [0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0]
    ];
let lblScore = document.getElementById("lblScoreText");
/*
 *---- Start 
 */

setAllScoreChips();


/*
 * ---- Functions
 */
function getState(colorname) {
    let state = 0;
    switch (colorname) {
        case "red":
            state = 1;
            break;

        case "yellow":
            state = -1;
            break;

        default:
        case "gray":
            state = 0;
            break;
    }
    return state;

}
function setColorAt(colorname, _row, _col) {
    field[_row][_col] = getState(colorname);
}
function findVertLine(state) {
    let foundLine = false;

    for (let c = field[0].length - 1; c >= 0; c--) {
        if (field[field.length - 1][c] === state) {
            //lookup next pos
            if (field[field.length - 2][c] === state) {
                //lookup next 2 pos
                if (field[field.length - 3][c] === state && field[field.length - 4][c] === state) {
                    foundLine = true;
                    console.log("Vert-Line found!");
                    break;
                }
            }
        }
    }

    return foundLine;

}
function findHorizonLine(state) {
    let foundLine = false;

    for (let r = field.length - 1; r >= 0; r--) {
        for (let c = field[0].length - 1; c >= 0; c--) {
            if (field[r][c] === state && c >= 3) {
                //lookup next pos
                if (field[r][c - 1] === state) {
                    //lookup next 2 pos
                    if (field[r][c - 2] === state && field[r][c - 3] === state) {
                        foundLine = true;
                        console.log("Hor-Line found!");
                        break;
                    }
                }
            }
        }
        if (foundLine) {
            break;
        }
    }
    return foundLine;

}
function findDiagonalLine(state) {
    let foundLine = false;

    for (let c = field[0].length - 1; c >= 0; c--) {
        if (field[field.length - 1][c] === state) {
            if (c >= 3) {
                //lookup next pos,diagonally leftup
                if (field[field.length - 2][c - 1] === state) {
                    //lookup next 2 pos
                    if (field[field.length - 3][c - 2] === state && field[field.length - 4][c - 3] === state) {
                        foundLine = true;
                        console.log("Dia-Line found!");
                        break;
                    }
                }

            }
            else {

                //lookup next pos diagonally rightup
                if (field[field.length - 2][c + 1] === state) {
                    //lookup next 2 pos
                    if (field[field.length - 3][c + 2] === state && field[field.length - 4][c + 3] === state) {
                        foundLine = true;
                        console.log("Dia-Line found!");
                        break;
                    }
                }
            }
        }
    }

    return foundLine;

}
function CheckField(player) {
    let pState = getState(player);
    let winner = false;

    if (!findHorizonLine(pState)) {
        if (!findVertLine(pState)) {
            if (findDiagonalLine(pState)) {
                winner = true;
            }
        }
        else {
            winner = true;
        }
    }
    else {
        winner = true;
    }
    return winner;
}
function clearField() {
    for (let r = 0; r < field.length; r++) {
        for (let c = 0; c < field[r].length; c++) {
            setColorAt("gray", r, c);
        }

    }
}
function resetPositionArr() {
    posArr = [300, 300, 300, 300, 300, 300];
}
function setScoreNeeded()
{
    scoreNeeded = parseInt(rounds / 2) + 1;
}
function newScoreChip(id)
{
    let newChip = document.createElement("div");
    let ring = document.createElement("div");
    newChip.appendChild(ring);

    newChip.classList.add("score-chip");
    newChip.id = "score-chip-" + id;
    newChip.classList.add("gray");
    ring.classList.add("ring");
    ring.classList.add("ring-s");

    return newChip;
}
function setAllScoreChips()
{
    setScoreNeeded();

    RemoveAllChildren("board-yellow");
    RemoveAllChildren("board-red");

    for (var i = 0; i < scoreNeeded; i++)
    {
        document.getElementById("board-yellow").appendChild(newScoreChip("yellow-" + (i+1)));
        document.getElementById("board-red").appendChild(newScoreChip("red-" + (i+1)));
    }
}
function RemoveAllChildren(id)
{
    while (document.getElementById(id).firstChild) {
        document.getElementById(id).removeChild(document.getElementById(id).firstChild);
    }
}
function IncreaseScore(mycolor)
{
    let s = 0;
    switch (mycolor) {
        case "red":
            scoreRed++;
            s = scoreRed;
            break;
        case "yellow":
            scoreYellow++;
            s = scoreYellow;
            break;
        default:
            console.log("no score set!");
            break;
    }
    let c = document.getElementById("score-chip-" + mycolor + "-" + s);
    c.classList.remove("gray");
    c.classList.add(mycolor);

    return s;
}
function SetLblScoreText(text)
{
    lblScore.innerHTML = text;
}
function ResetScoreBoard()
{
    scoreRed, scoreYellow = 0;
    SetLblScoreText("");
    setAllScoreChips();
}