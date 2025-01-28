function show() {
    addInputBlock("fname", "First name:", "text");
    addInputBlock("lname", "Last name:", "text");
    addInputBlock("zero2hundred", "En til hundre:", "range");
    addInputBlock("number", "Skriv inn et tall:", "number");
    addInputBlock("html", "HTML", "radio");
    addInputBlock("css", "CSS", "radio");
    addInputBlock("javascript", "JavaScript", "radio");
    addInputBlock("vehicle1", "I have a bike", "checkbox");
    addInputBlock("vehicle2", "I have a car", "checkbox");
    addInputBlock("vehicle3", "I have a boat", "checkbox");
};

function addInputBlock(id, title, type) {
    if (type === "text" || type === "number") {
        addLabel(id, title);
        addInput(type, id);
    } else if (type === "radio") {
        addInput(type, id, name = "fav_language");
        addLabel(id, title);
    } else if (type === "checkbox") {
        addInput(type, id);
        addLabel(id, title);
    } else { // type == range
        addLabel(id, title);
        addInput(type, id, null, "1", "100", "1");
    }
}

function addInput(type, id, name = null, min = null, max = null, step = null) {
    if (type === "radio") {
        document.getElementById('myTable').innerHTML +=/*HTML*/` <input type=${type} id=${id} name = ${name}>`
    }
    else if (type === "range") {
        document.getElementById('myTable').innerHTML +=/*HTML*/` <input type=${type} min=${min} max=${max} step=${step} id=${id}>`
    }
    else {
        document.getElementById('myTable').innerHTML +=/*HTML*/` <input type=${type} id=${id}>`
    }
    if (type === "text" || type === "number" || type === "range") { document.getElementById('myTable').innerHTML += `<br />` }
};

function addLabel(id, title) {
    document.getElementById('myTable').innerHTML += /*HTML*/`<label for=${id}>${title}</label><br />`
};