
let minQty = 2;
let maxQty = 6;

function ChangeValue(value)
{
    let nr = document.getElementById("lblQty").innerHTML;;
    let temp = parseInt(nr) + value;

    if (temp >= minQty && temp <= maxQty)
    {
        nr = temp;
    }

    document.getElementById("lblQty").innerHTML = nr.toString();
}


