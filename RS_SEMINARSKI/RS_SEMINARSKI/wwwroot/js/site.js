// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var connection = new signalR.HubConnectionBuilder().withUrl("/notHub").build();

connection.on("prijemDekoracije", function (cijena, tip, slika,naziv,dekoracijaid) {


    


    var glavni = document.getElementById("glavni");
    var noviCvijet = document.createElement("div");
    noviCvijet.style.float = "left";
    noviCvijet.style.width = "28%";
    noviCvijet.style.height = "40%";
    noviCvijet.style.marginTop = "30px";
    noviCvijet.style.marginLeft = "10px";
    noviCvijet.style.marginBottom = "25px";
    var novaSlika = document.createElement("div");
    novaSlika.style.width = "100%";
    novaSlika.style.height = "50%";
    novaSlika.style.border = "none";
    novaSlika.style.backgroundPosition = "center";
    novaSlika.style.backgroundSize = "cover";
    var slikaa = document.createElement("img");
    slikaa.src = "../Slike/" + slika;
    slikaa.style.height = "100%";
    slikaa.style.width = "100%";
    slikaa.border.radius = "none";
    slikaa.style.backgroundPosition = "center";
    slikaa.style.backgroundSize = "cover";
    glavni.appendChild(noviCvijet).appendChild(novaSlika).appendChild(slikaa);
   
    var opis = document.createElement("div");
    opis.style.backgroundColor = "whitesmoke";
    opis.style.opacity = "0.7";
    opis.style.width = "100%";
    opis.style.height = "30%";
    opis.style.fontFamily = "Calibri";
    opis.style.textAlign = "center";
    opis.style.paddingTop = "20px";

    var labela1 = document.createElement("label");
    labela1.style.fontSize = "13px";
    labela1.style.opacity = "1";
    labela1.textContent = "Naziv dekoracije: " + naziv;
    var labela2 = document.createElement("label");
    labela2.style.fontSize = "13px";
    labela2.style.opacity = "1";
    labela2.textContent = "\nTip dekoracije: " + tip;
    var labela3 = document.createElement("label");
    labela3.style.fontSize = "13px";
    labela3.style.opacity = "1";
    labela3.textContent = "\nCijena: " + cijena;
    var breakk= document.createElement("br");

    opis.appendChild(labela1);
    opis.appendChild(labela2);
    opis.appendChild(breakk);
    opis.appendChild(labela3);
 
    glavni.appendChild(noviCvijet).appendChild(opis);
        var buttons = document.createElement("div");
        buttons.style.backgroundColor = "transparent";
        buttons.style.width = "100%";
        buttons.style.height = "20%";
        var dugme = document.createElement("button");
        dugme.style.color = "black";
        dugme.style.position = "relative";
        dugme.style.marginLeft = "26px";
        dugme.style.marginTop = "15px";
        dugme.style.backgroundColor = "whitesmoke";
        dugme.style.width = "260px";
        dugme.style.height = "30px";
        dugme.style.borderRadius = "10px";
        dugme.style.border = "none";
        dugme.style.opacity = "0.7";
    dugme.textContent = "Dodaj u rezervaciju";
    var KorisnikID = document.getElementById("korisnik").value;
    console.log(KorisnikID);
    dugme.addEventListener('click', function () {
        console.log(KorisnikID);
        window.location.replace("/Dekoracija/DodajURezervaciju?KorisnikID=" + KorisnikID + "&DekoracijaID=" + dekoracijaid);

    });
    buttons.appendChild(dugme);
    glavni.appendChild(noviCvijet).appendChild(buttons);
   
});
connection.on("prijemPozivnica", function (cijena,opiss, slika, pozivnicaid) {





    var glavni = document.getElementById("glavni");
    var noviCvijet = document.createElement("div");
    noviCvijet.style.float = "left";
    noviCvijet.style.width = "28%";
    noviCvijet.style.height = "40%";
    noviCvijet.style.marginTop = "30px";
    noviCvijet.style.marginLeft = "10px";
    noviCvijet.style.marginBottom = "25px";
    var novaSlika = document.createElement("div");
    novaSlika.style.width = "100%";
    novaSlika.style.height = "50%";
    novaSlika.style.border = "none";
    novaSlika.style.backgroundPosition = "center";
    novaSlika.style.backgroundSize = "cover";
    var slikaa = document.createElement("img");
    slikaa.src = "../Slike/" + slika;
    slikaa.style.height = "100%";
    slikaa.style.width = "100%";
    slikaa.border.radius = "none";
    slikaa.style.backgroundPosition = "center";
    slikaa.style.backgroundSize = "cover";
    glavni.appendChild(noviCvijet).appendChild(novaSlika).appendChild(slikaa);

    var opis = document.createElement("div");
    opis.style.backgroundColor = "whitesmoke";
    opis.style.opacity = "0.7";
    opis.style.width = "100%";
    opis.style.height = "30%";
    opis.style.fontFamily = "Calibri";
    opis.style.textAlign = "center";
    opis.style.paddingTop = "20px";

    var labela1 = document.createElement("label");
    labela1.style.fontSize = "13px";
    labela1.style.opacity = "1";
    labela1.textContent = "Cijena pozivnice: " + cijena;
    var labela2 = document.createElement("label");
    labela2.style.fontSize = "13px";
    labela2.style.opacity = "1";

    labela2.textContent = "\nOpis pozivnice: " + opiss;
    //var labela3 = document.createElement("label");
    //labela3.style.fontSize = "13px";
    //labela3.style.opacity = "1";
    //labela3.textContent = "\nCijena: " + cijena;
    var breakk = document.createElement("br");

    opis.appendChild(labela1);
    opis.appendChild(breakk);
    opis.appendChild(labela2);
   
    glavni.appendChild(noviCvijet).appendChild(opis);
    console.log("1");
    var buttons = document.createElement("div");
    console.log("1");
    buttons.style.backgroundColor = "transparent";
    console.log("1");
    buttons.style.width = "100%";
    console.log("1");
    buttons.style.height = "20%";
    console.log("1");
    var dugme = document.createElement("button");
    console.log("1");
    dugme.style.color = "black";
    console.log("1");
    dugme.style.position = "relative";
    console.log("1");
    dugme.style.marginLeft = "26px";
    console.log("1");
    dugme.style.marginTop = "15px";
    console.log("1");
    dugme.style.backgroundColor = "whitesmoke";
    console.log("1");
    dugme.style.width = "260px";
    console.log("1");
    dugme.style.height = "30px";
    console.log("1");
    dugme.style.borderRadius = "10px";
    console.log("1");
    dugme.style.border = "none";
    console.log("1");
    dugme.style.opacity = "0.7";
    console.log("1");
    dugme.textContent = "Dodaj u rezervaciju";
    console.log("1");
    var KorisnikID = document.getElementById("korisnik").value;
    console.log("1");
    console.log(KorisnikID);
    dugme.addEventListener('click', function () {
        console.log(KorisnikID);
        window.location.replace("/Pozivnica/DodajURezervaciju?KorisnikID=" + KorisnikID + "&PozivnicaID=" + pozivnicaid);

    });
    buttons.appendChild(dugme);
    glavni.appendChild(noviCvijet).appendChild(buttons);

});


connection.on("prijemCvijeca", function (cijena, naziv, slika, tip, cvijeceid) {


    var glavni = document.getElementById("glavni");
    var noviCvijet = document.createElement("div");
    noviCvijet.style.float = "left";
    noviCvijet.style.width = "28%";
    noviCvijet.style.height = "40%";
    noviCvijet.style.marginTop = "30px";
    noviCvijet.style.marginLeft = "10px";
    noviCvijet.style.marginBottom = "25px";
    var novaSlika = document.createElement("div");
    novaSlika.style.width = "100%";
    novaSlika.style.height = "50%";
    novaSlika.style.border = "none";
    novaSlika.style.backgroundPosition = "center";
    novaSlika.style.backgroundSize = "cover";
    var slikaa = document.createElement("img");
    slikaa.src = "../Slike/" + slika;
    slikaa.style.height = "100%";
    slikaa.style.width = "100%";
    slikaa.border.radius = "none";
    slikaa.style.backgroundPosition = "center";
    slikaa.style.backgroundSize = "cover";
    glavni.appendChild(noviCvijet).appendChild(novaSlika).appendChild(slikaa);

    var opis = document.createElement("div");
    opis.style.backgroundColor = "whitesmoke";
    opis.style.opacity = "0.7";
    opis.style.width = "100%";
    opis.style.height = "30%";
    opis.style.fontFamily = "Calibri";
    opis.style.textAlign = "center";
    opis.style.paddingTop = "20px";

    var labela1 = document.createElement("label");
    labela1.style.fontSize = "13px";
    labela1.style.opacity = "1";
    labela1.textContent = "Naziv: " + naziv;
    var labela2 = document.createElement("label");
    labela2.style.fontSize = "13px";
    labela2.style.opacity = "1";
    labela2.textContent = "\nTip: " + tip;
    var labela3 = document.createElement("label");
    labela3.style.fontSize = "13px";
    labela3.style.opacity = "1";
    labela3.textContent = "\nCijena: " + cijena;
    var breakk = document.createElement("br");

    opis.appendChild(labela1);
    opis.appendChild(labela2);
    opis.appendChild(breakk);
    opis.appendChild(labela3);

    glavni.appendChild(noviCvijet).appendChild(opis);
    var buttons = document.createElement("div");
    buttons.style.backgroundColor = "transparent";
    buttons.style.width = "100%";
    buttons.style.height = "20%";
    var dugme = document.createElement("button");
    dugme.style.color = "black";
    dugme.style.position = "relative";
    dugme.style.marginLeft = "26px";
    dugme.style.marginTop = "15px";
    dugme.style.backgroundColor = "whitesmoke";
    dugme.style.width = "260px";
    dugme.style.height = "30px";
    dugme.style.borderRadius = "10px";
    dugme.style.border = "none";
    dugme.style.opacity = "0.7";
    dugme.textContent = "Dodaj u rezervaciju";
    var KorisnikID = document.getElementById("korisnik").value;
    console.log(KorisnikID);
    dugme.addEventListener('click', function () {
        console.log(KorisnikID);
        window.location.replace("/Cvijece/DodajURezervaciju?KorisnikID=" + KorisnikID + "&CvijeceId=" + cvijeceid);

    });
    buttons.appendChild(dugme);
    glavni.appendChild(noviCvijet).appendChild(buttons);

});



connection.start().then(function () {
    console.info("started signalR hub");

}).catch(function (err) {
    return console.error(err.toString());
});
