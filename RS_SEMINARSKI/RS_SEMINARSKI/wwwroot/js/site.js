// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var connection = new signalR.HubConnectionBuilder().withUrl("/notHub").build();

connection.on("prijemDekoracije", function (cijena, tip, slika) {


    //<div class="cvijet">
    //    <div id="slika"><img id="prikazSlike" src="~/Slike/@x.PutanjaDoSlike" /> </div>
    //    <div id="opis">
    //        <label class="zaFont">Naziv dekoracije: @x.NazivDekoracije</label><br />
    //        <label class="zaFont">Tip dekoracije: @x.TipDekoracije</label><br />
    //        <label class="zaFont">Cijena: @x.CijenaDekoracije KM</label><br />
    //        <label class="zaFont" hidden>DekoracijaID @x.DekoracijaID</label><br />
    //    </div>
    //    <div id="buttons">
    //        @if (Model.RolaID == 1)
    //                {
    //                    <button class="btn2" style="color:mediumseagreen" onclick="window.location = '/Dekoracija/EvidentirajDekoraciju?KorisnikID=@Model.KorisnikID&DekoracijaID=@x.DekoracijaID'">Uredi dekoraciju</button>
    //                    <button class="btn2" style="color: indianred" onclick="window.location = '/Dekoracija/ObrisiDekoraciju?KorisnikID=@Model.KorisnikID&DekoracijaID=@x.DekoracijaID'">Obrisi</button>

    //        }
    //                else
    //                {
    //            <button id="btn3" style="color: black" onclick="window.location = '/Dekoracija/DodajURezervaciju?KorisnikID=@Model.KorisnikID&DekoracijaID=@x.DekoracijaID'">Dodaj u rezervaciju</button>

    //        }
    //    </div>
    //            @*<div id="Brisanje">
    //    </div>*@
    //        </div>


    var glavni = document.getElementById("glavni");
    var noviCvijet = document.createElement("div");
    var novaSlika = document.createElement("div");
    var slikaa = document.createElement("img");
    slikaa.src = "../Slike/" + slika;
    slikaa.style.height = "200px";
    slikaa.style.width = "251px";
    glavni.appendChild(noviCvijet).appendChild(novaSlika).appendChild(slikaa);
    
    
    console.info("radi");
});

connection.start().then(function () {
    console.info("started signalR hub");

}).catch(function (err) {
    return console.error(err.toString());
});
