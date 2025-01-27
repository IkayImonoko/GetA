function step0() {
    document.getElementById('room').innerHTML = `   
        Du er utenfor en leilighet <br/>
        <button onclick="step1()"> gå inn </button> `;
}

function step1() {
    document.getElementById('room').innerHTML = `   
        Du er i gangen <br/>
        <button onclick="step0()"> gå ut </button>
        <button onclick="step2()"> gå inn i stua </button>
        <button onclick="step3()"> gå inn på badet </button>
        <button onclick="step4()"> gå inn på kjøkkenet </button> `;
}

function step2() {
    document.getElementById('room').innerHTML = `   
        Du er i stua <br/>
        <button onclick="step4()"> gå inn på kjøkkenet </button>
        <button onclick="step1()"> gå tilbake til gangen </button> `;
}

function step3() {
    document.getElementById('room').innerHTML = `   
        Du er på badet <br/>
        <button onclick="step1()"> gå tilbake til gangen </button> `;
}

function step4() {
    document.getElementById('room').innerHTML = `   
        Du er på kjøkkenet <br/>
        <button onclick="step2()"> gå inn i stua </button>
        <button onclick="step1()"> gå tilbake til gangen </button> `;
}
