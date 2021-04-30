// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


var coll = document.getElementsByClassName("colapse");
for (let i = 0; i < coll.length; i++) {
    coll[i].addEventListener("click",
        function () {
            this.classList.toggle("active");
            let content = this.nextElementSibling;

            if (content.style.display === "block") {
                content.style.display = "none";
            }
            else {
                content.style.display = "block";
            }
        });
}

var languages = document.getElementsByClassName("lang-display");

SetLanguageColors();

function SetLanguageColors()
{
    for (var i = 0; i < languages.length; i++)
    {
        let color = "";
        switch (languages[i].innerHTML.toLowerCase())
        {
            case ".net":
                color = "clr-net";
                break;
            case "c#":
                color = "clr-cs";
                break;
            case "html":
                color = "clr-html";
                break;
            case "js":
                color = "clr-js";
                break;
            case "css":
                color = "clr-css";
                break;
            case "consoleapp":
                color = "clr-console";
                break;
            case "wpf":
                color = "clr-wpf";
                break;
            case "winforms":
                color = "clr-forms";
                break;
            case "asp core":
                color = "clr-asp";
                break;
            default:
                color = "clr-red";
        }

        languages[i].classList.add(color);

    }

}
