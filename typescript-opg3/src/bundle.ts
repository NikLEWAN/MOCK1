const input: HTMLInputElement = <HTMLInputElement> document.querySelector("input");
const select: HTMLSelectElement = <HTMLSelectElement> document.querySelector("select");
const btn: HTMLButtonElement = <HTMLButtonElement> document.querySelector("button");
const output: HTMLOutputElement = <HTMLOutputElement> document.querySelector("output");

function run(x : string) : void {
    let value : string = select.options[select.selectedIndex].value;
    if(value == "u"){
        output.innerHTML = u(x);
    }
    if(value == "l"){
        output.innerHTML = l(x);
    }
}

function u(x : string) : string{
    return "uppered: " + x.toUpperCase();
}
function l(x : string) : string{
    return "lowered: " + x.toLowerCase();
}


btn.addEventListener('click', function(){
    run(input.value);
});
