"use strict";
const input = document.querySelector("input");
const select = document.querySelector("select");
const btn = document.querySelector("button");
const output = document.querySelector("output");
function run(x) {
    let value = select.options[select.selectedIndex].value;
    if (value == "u") {
        output.innerHTML = u(x);
    }
    if (value == "l") {
        output.innerHTML = l(x);
    }
}
function u(x) {
    return "uppered: " + x.toUpperCase();
}
function l(x) {
    return "lowered: " + x.toLowerCase();
}
btn.addEventListener('click', function () {
    run(input.value);
});
