function state0(){
    document.getElementById('root').innerHTML = `
        <div class="trafficLight" onclick="state1()">
        <div class="light" style="background-color: red;"></div>
        <div class="light" style="background-color: gray;"></div>
        <div class="light" style="background-color: gray;"></div>
        </div>
`;
}

function state1(){
    document.getElementById('root').innerHTML = `
    <div class="trafficLight" onclick="state2()">
    <div class="light" style="background-color: red;"></div>
    <div class="light" style="background-color: yellow;"></div>
    <div class="light" style="background-color: gray;"></div>
    </div>
`; 
}

function state2(){
    document.getElementById('root').innerHTML = `
    <div class="trafficLight" onclick="state3()">
    <div class="light" style="background-color: gray;"></div>
    <div class="light" style="background-color: gray;"></div>
    <div class="light" style="background-color: green;"></div>
    </div>
`;
}

function state3(){
    document.getElementById('root').innerHTML = `
    <div class="trafficLight" onclick="state0()">
    <div class="light" style="background-color: gray;"></div>
    <div class="light" style="background-color: yellow;"></div>
    <div class="light" style="background-color: gray;"></div>
    </div>
`;
}