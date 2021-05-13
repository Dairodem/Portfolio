

let rounds = 3;
let isWinner = false;
let posArr = [300, 300, 300, 300, 300, 300];
let field =
    [
        [0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0]
    ];

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