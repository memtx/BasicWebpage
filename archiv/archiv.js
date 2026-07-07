let el_rozcestnik = document.getElementById("rozcestnik");

for(let cesta of archiv)
{
    let a = document.createElement("a");
    a.innerText = cesta["jmeno"];
    a.href = cesta["cesta"];

    el_rozcestnik.appendChild(a);
}