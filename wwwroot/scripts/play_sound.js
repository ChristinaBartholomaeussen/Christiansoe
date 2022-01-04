
const audio = new Audio("audio/edderfugl.mp3");

function playAudio() {
    audio.play();
    document.getElementById("play").style.visibility = "hidden";
    document.getElementById("pause").style.visibility = "visible";
}


function pauseAudio() {
    audio.pause();
    document.getElementById("pause").style.visibility = "hidden";
    document.getElementById("play").style.visibility = "visible";
}