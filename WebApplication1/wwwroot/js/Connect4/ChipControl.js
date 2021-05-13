

let myQuandrant = 0;
let fallSpeed = 6;
let isfalling = false;
let currChip = {};
var currColor = "";
let chip = document.getElementById("chip");

function moveDown(element)
{
    var elStyle = window.getComputedStyle(element);
    var topValue = parseInt(elStyle.getPropertyValue("top").replace("px", ""));
    element.style.top = (topValue + fallSpeed) + "px";

    if (topValue > posArr[myQuandrant])
    {
        isfalling = false;
        element.style.top = posArr[myQuandrant] + "px";
        element.removeAttribute("id");
        posArr[myQuandrant] -= 100;

        setColorAt(playerColor, parseInt((posArr[myQuandrant] / 100) + 1), myQuandrant);
        if (!CheckField(playerColor))
        {
            ChangeColor(playerColor === "yellow" ? currColor = "red" : currColor = "yellow");
            playerColor = currColor;
            changePlayerName(playerColor);
        }
        else
        {
            isWinner = true;
        }
    }
}
function moveChip()
{
    chip.style.left = getQuadrant(posX) + 'px';
}
function createChip()
{
    myQuandrant = (currQuadrant / 100);

    if (!isfalling && posArr[myQuandrant] >= 0)
    {
        NewChip(playerColor);
        currChip = document.getElementById("newChip");
        ChangeColor("gray");
    }
}
function NewChip(color)
{
    isfalling = true;

    this.x = getQuadrant(posX);
    this.y = 0;
    this.newChip = document.createElement("div");
    this.ring = document.createElement("div");
    this.newChip.appendChild(this.ring);

    this.newChip.classList.add("chip");
    this.newChip.id = "newChip";
    this.newChip.classList.add("chipindex");
    this.newChip.classList.add(color);
    this.ring.classList.add("ring");

    const canvas = document.getElementById("canvas");
    canvas.insertBefore(this.newChip, chip);
    this.newChip.style.left = getQuadrant(posX) + 'px';

}


