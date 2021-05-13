

document.getElementById("overlay").onmousemove = findObjectCoords;
if (!isfalling) {
    document.getElementById("canvas").onmousedown = createChip;
}

function findObjectCoords(mouseEvent) {
    var obj = document.getElementById("overlay");
    var obj_left = 0;
    var obj_top = 0;
    var xpos;

    while (obj.offsetParent) {
        obj_left += obj.offsetLeft;
        obj_top += obj.offsetTop;
        obj = obj.offsetParent;
    }
    if (mouseEvent) {
        //FireFox
        xpos = mouseEvent.pageX;
    }
    else {
        //IE
        xpos = window.event.x + document.body.scrollLeft - 2;
    }
    xpos -= obj_left;
    posX = xpos;
    if (getQuadrant(posX) !== currQuadrant) {
        moveSelector();
        moveChip();
    }

}