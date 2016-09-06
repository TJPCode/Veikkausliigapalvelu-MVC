# Veikkausliigapalvelu MVC (jatkokehitetty) - C# / HTML / CSS / JSON / JAVASCRIPT

Työkalut: Visual Studio 2013, SQL Server 2014 Management Studio.

--------------------------------------------

Palvelun ominaisuudet:

-Etusivulla slider, joka pyörittää kahta eri kuvaa.

-Rss-syötteet etusivulle kolmelta eri tarjoajalta eli Ilta-sanomilta, Iltalehdeltä ja Mtv sportilta. Syötteet ovat partial viewissä eli kun valitaan toinen tarjoaja, vain partial view päivittyy, eikä koko etusivua ladata uusiksi.

-Näyttää kaikki kauden 2015 ottelut. Otteluita voi etsiä haluamaltaan ajanjaksolta.

-Yksittäisen ottelun tapahtumia voi katsella painamalla info-ikonia. Tapahtumat saatavilla vain alkukauden otteluista.

-Kaksi kauden 2015 sarjataulukkoa. Toisen data haetaan tietokannasta ja toisen json-tiedostosta. Tietokannan sarjataulukkoa voi muokata muuttamalla joukkueen nimeä, voittoja, tasapelejä, häviöitä, tehtyjä maaleja ja päästettyjä maaleja. Muutokset voi tallentaa tietokantaan.

--------------------------------------------

Tulokset-välilehti näyttää json-tiedostosta kerätyt ottelukohtaiset tiedot eli pelipäivämäärät, kellonajat, joukkueet, joukkueiden logot ja lopputulokset. Käyttäjä voi filteröidä näytettäviä otteluita valitsemalla kahdella päivämääräkentällä ajanjakson, jolloin otteluita on pelattu. Palvelu näyttää aikajakson aikana pelatut ottelut ja ilmoittaa niiden määrän.

Päivämääräkentissä on estetty alku -ja loppupäivämäärän ristiriidat eli alkupäivämäärä ei voi olla suurempi kuin loppupäivämäärä ja toisinpäin. Etsi-nappi on disabloitu, kunnes molempiin päivämääräkenttiin on valittu päivä. Nappi disabloituu, kun haku on tehty. Päivämääräkenttä on toteutettu jQueryn datepickerillä, joka on oletuksena englanninkielinen. Lisätyllä datepicker-fi.js -tiedostolla se kääntyy kuitenkin myös suomeksi.

Päivämäärien oletuspäivää on muokattu alkamaan huhtikuusta 2015 ja loppumaan marraskuuhun 2015, jotta haun testaaminen olisi helpompaa. Kaikki json-tiedostossa olevat ottelut on pelattu huhtikuun ja lokakuun sisällä vuonna 2015. Otteluita tuona aikana oli 198.

--------------------------------------------

Files-kansiossa on scripti LeagueTable-taulun luomiseksi SSMS:ssa, mutta tietokanta nimeltään LeagueDb tulee luoda itse Databases-kansion juureen. Visual studio kannattaa ajaa varmuuden vuoksi adminina, jotta yhteys tietokantaan saadaan ongelmitta. Myös Web.config tiedoston connectionStringistä tulee vaihtaa serverin nimi 'data source=TJ-PC\SQLEXPRESS;' vastaamaan omaa serveriä.
