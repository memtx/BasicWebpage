class ParsedData
{
    constructor()
    {
        this.soutezNazev = "Pohár špatného Javascriptu 2026";
        this.soutezDatum = "2.7. 2026";

        this.posledniZmena = new Date("2026-07-02T15:08:34");

        this.kategorie = ["Muži", "Ženy"]

        this.teamy = [
            {jmeno: "Vyšní Lhoty",levy: "00:14.154", pravy:"00:16.134", kategorie:"Ženy"},
            {jmeno: "Nižní Lhoty",levy: "00:13.134", pravy:"00:15.134", kategorie: "Muži" },
            {jmeno: "Raškovice",levy: "00:45.134", pravy:"01:14.136", kategorie: "Muži"},
            {jmeno: "Bahno",levy: "NP", pravy:"NP", kategorie: "Muži"},
            {jmeno: "Žabeň",levy: "00:24.134", pravy:"00:24.136", kategorie: "Muži"},
            {jmeno: "Krásná Mohelnice",levy: "", pravy:"", kategorie: "Muži"},
            {jmeno: "Nošovice",levy: "", pravy:"", kategorie: "Ženy"},
            {jmeno: "Palkovice",levy: "", pravy:"", kategorie: "Muži"},
            {jmeno: "Pražmo",levy: "", pravy:"", kategorie: "Muži"}
        ];
    }
}

let data = new ParsedData();