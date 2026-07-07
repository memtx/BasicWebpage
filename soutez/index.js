let el_categories = document.getElementById("categories");
let el_statistics = document.getElementById("statistics");
let el_allTeams   = document.getElementById("allTeams");

//==== funkce ====

let sortedTeams = [];
let sortPosition = {};

function strMax(a, b)
{
    if(a > b)
        return a
    else
        return b
}

function loadLeaderboard(category="Vše", sorted = false)
{
    let sortCounter = {}
            

    for(let category of data.kategorie)
    {
        sortCounter[category] = 1;
        sortPosition[category] = {}
    }

    for(let team of sortedTeams)
    {
        sortPosition[team.kategorie][team.jmeno] = sortCounter[team.kategorie];
        sortCounter[team.kategorie]++;
    }

    let teams;
    if(sorted)
        teams = sortedTeams;
    else 
        teams = data.teamy;

    el_statistics.innerHTML = `
        <tr>
            <th>Tým</th>
            <th>LP</th>
            <th>PP</th>
            <th>Výsledný čas</th>
            <th>Pozice v kategorii</th>
        </tr>`;
     

    firstTimelessFound = false;

    for(let team of teams)
    {
        
        if(team.kategorie == category || category === "Vše")
        {
            let row = document.createElement("tr");
            let name = document.createElement("td");
            name.innerText = team.jmeno;
            row.appendChild(name);
            let lp = document.createElement("td");
            lp.innerText = team.levy;
            row.appendChild(lp);
            let pp = document.createElement("td");
            pp.innerText = team.pravy;
            row.appendChild(pp);
            let final = document.createElement("td");
            final.innerText = strMax(team.levy, team.pravy);
            row.appendChild(final);
            
            let position = sortPosition[team.kategorie][team.jmeno];
            let el_position = document.createElement("td");

            if(team.levy.length > 0)
            {
                el_position.innerText = position;
                

                switch(position)
                {
                    case 1:
                        row.classList.add("statsFirst")
                        break;
                    case 2:
                        row.classList.add("statsSecond")
                        break;
                    case 3:
                        row.classList.add("statsThird")
                        break;
                }
            }
            row.appendChild(el_position);
            
            if(firstTimelessFound == false && team.levy.length == 0)
            {
                row.classList.add("statsHighlight")
                firstTimelessFound = true;
            }
            el_statistics.appendChild(row);
        }
    }
}

function setActiveButton(btn)
{
    let parent = btn.parentElement;
    for(let child of parent.children)
        child.classList.remove("active");   
   
    btn.classList.add("active");
}

//porovnávací funkce pro třídění týmů dle časů
function timeComp(a, b)
{
    if(a.pravy.length == 0) return 1; 
    if(b.pravy.length == 0) return -1; 
    
    return (strMax(a.levy, a.pravy) > strMax(b.levy, b.pravy));
}
//==== inicializace ====


if (window.location.href.indexOf("archiv") == -1)
    setTimeout(()=>{location.reload();}, 30000);
/*
//restart timeoutu při tabnutí pryč (asi není třeba)
document.addEventListener("visibilitychange", () => 
{
    if (document.visibilityState === "visible") 
    { setTimeout(()=>{location.reload()}, 20000); }
    else
    { clearTimeout(refreshTimeout); }
})*/


//proměnná data je načtena v html headeru z parsedData.js
document.getElementById("pageTitle").innerText = data.soutezNazev;
document.getElementById("poharTitul").innerText = data.soutezNazev;
document.getElementById("poharDatum").innerText = data.soutezDatum;

sortedTeams = data.teamy.toSorted(timeComp);

let currentCategory = data.kategorie[0];

let categoryVse = document.createElement("button");
categoryVse.innerText = "Vše";
categoryVse.classList.add(["active"]);  
categoryVse.onclick = ()=>{loadLeaderboard(); setActiveButton(categoryVse);}
el_categories.appendChild(categoryVse);

let loopCounter = 0;
for(let category of data.kategorie)
{
    let el = document.createElement("button");
    el.innerText = data.kategorie[loopCounter];

    const temp = data.kategorie[loopCounter]
    el.onclick = ()=> {loadLeaderboard(temp); setActiveButton(el); }

    el_categories.appendChild(el);
    loopCounter++;
} 
/*
appendAllStatistics(data.kategorie);
loadTeams();
*/
loadLeaderboard();

