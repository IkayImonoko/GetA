
function drawTrafficLight(red, yellow, green) {
    document.getElementById('app').innerHTML = /*HTML*/`<div class="trafficLight">
     ${red ? returnRedDiv() : returnGrayDiv()} 
     ${yellow ? returnYellowDiv() : returnGrayDiv()} 
     ${green ? returnGreenDiv() : returnGrayDiv()}
     </div>`;
}
function returnRedDiv() {
    return `<div class="light" style="background-color: red;"></div>`;
}
function returnYellowDiv() {
    return `<div class="light" style="background-color: yellow;"></div>`;
}
function returnGreenDiv() {
    return `<div class="light" style="background-color: green;"></div>`;
}
function returnGrayDiv() {
    return `<div class="light" style="background-color: gray;"></div>`;
}
function goToNextPhase() {
    currentPhase = (currentPhase + 1) % 4;
    if (currentPhase == 0)
        drawTrafficLight(true, false, false)
    else if (currentPhase == 1)
        drawTrafficLight(true, true, false)
    else if (currentPhase == 2)
        drawTrafficLight(false, false, true)
    else
        drawTrafficLight(false, true, false);
}
