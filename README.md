# ExordiumTask
For Unity Programmer Assignment

1. 
Kretanje lika implementirano je u potpunosti prema zahtjevima te se za kretanje koriste tipke W,A,S,D ili strelice. Pripadajuće skripte vezane za zahtjeve su:
	CameraController - implementirano da kamera prati igrača 
	CharacterMovement - implementacija kretanja igrača pomoću Rigidbody2D 
Korištena je sprite sheet animacija napravljena prema sprite sheetu koji je priložen na dnu dokumenta sa uputama te je brzina animacije prilagođena brzini kretanja lika. Za environment su korišteni besplatni paketi preuzeti iz 
Asset storea. Osim što igrač collidea sa itemima, neki dijelovi environmenta su obavijeni colliderima(ne triggerima).

2.
Interakcija lika sa predmetima implementirana je pomoću skripte Interactable dok se PlayerController skripta koristi za detektiranje inputa igrača. Prema tome kada je zabilježen input igrača u skripti PlayerController, provjerava se 
u skripti Interactable je li igrač u radijusu predmeta te se s obzirom na uspjeh interakcije javlja odgovarajuća poruka u konzoli. Za interakciju s objektima koristi se tipka 'E'. 
Kao što je već spomenuto, za interakciju se koriste collideri u obliku triggera. Za bonus smatram da je djelomično ispunjen zato što je odabrana opcija br.2 međutim ne može se mijenjati način interakcije unutar igre.

3.
U donjem lijevom uglu ekrana nalaze se gumbi za uključivanje i isključivanje prozora za: 
	1. Inventory Panel,
	2. Equipement Panel,
	3. Attributes Panel
Prema zahtjevu gumbi nestaju na prilikom uključivanja panela a pojavljuju se nakon što je panel isključen pomoću gumba za isključivanje koji se nalazi na pojedinom panelu.

Shortcuts:
Za uključivanje Inventory Panela - 'I'
Za uključivanje Equipement Panela - 'J'
Za uključivanje Attributes Panela - 'K'
Uključivanje svih panela - 'Tab'

Shortcutevi su ostavareni dodavanjem novog inputa unutar Edit -> Project Settings -> Input, a funkcionalnost je unutar UI skripte za svaki panel: AttributesUI, InventoryUI i EquipUI

4.
Za Inventory Grid Screen korištene su statičke 4x8 vidljive čelije, a Equip Screen također ima 4 statičke čelije odnosno Equip Slota-a: Head, Torso, Main Hand i Off Hand. Za izradu jednog slota unutar Inventory Screena korištena 
je skripta InventorySlot unutar koje je pomoću EventSystems impelementirana logika za Drag & Drop i logika za equipanje itema u odgovarajući Equip Slot pomoću desnog klika ako je to moguće. Nažalost, niti pointer eventi ni draging and dropping eventi iz nekog 
razloga ne funkcioniraju iako je na svakom dijelu slota koji treba biti interaktivan uključen Raycast Targeting. Debuggiranjem nije otkirveno zbog čega niti jedan od tih eventa ne radi pa zbog toga Equipment Screen nema nikakvu funkcionalnost,
ali logika iza equip slotova i inventory slotova bi trebala biti ispravna. Iz istog razloga nije implementirano da se atributi ažuriraju nakon equipanja pojedinog itema zato što equipanje nije moglo biti testirano. 

Svaki slot ima Remove Item Button čija je funkcionalost implementirana također unutar InventorySlot skripte. Skripta EquipSlot nasljeđuje skriptu InventorySlot i služi kao proširenje kako bi se moglo provjeriti je li željeni item
tipa Equippable.

5.
Nakon što su itemi podignuti pojavljuju se unutar inventorija te je zadana količina uvijek 1. Ako se radi o itemima koji su stackable njihova količina se povećava dohvaćanjem novih itema, za regularne iteme se u konzoli i igraču pojavljuje poruka
da item nije tipa stackable, a ukoliko je dosegnuta maksimalna količina stackova pojavljuje se log i poruka da je dosegnuta maksimalna količina.
Ukoliko u inventoriju više nema mjesta, igraču i u konzoli se prezentira odgovarajuća poruka.

6.
Itemi su ostvareni kao scriptable object pomoću skripte Item. U istoj navedeni su svi atributi za iteme prema zahtjevima zadatka, a klasa EquippableItem nasljeđuje klasu Item. Objekte tipa Item i Equippable item moguće je stvarati unutar editora kao assete.
Funkcionalnosti inventorija ostvaruju se unutar klase Inventory u kojoj se nalaze Add i Remove funkcije koje vrše kontrolu dodavanja i micanja itema iz inventorija koji je ostvaren kao lista itema. U klasi InvenotryManger implementirana je logika za
drag and drop među slotovima inventorija. Također, ovdje se nalaze skripte poput Equip i Unequip koje služe kao funkcionalnost equippanja i unequippanja itema iz inventory slotova u equip slotove pomoću drag and dropa ili desnog klika.
Kao što je već spomenuto, funkcionalnsoti vezane za equip itema poput drag-a i drop-a te kombinacije sa desnim klikom ne funkcioniraju iz nepoznatog razloga u kojem se spomenuti eventi ne registriraju.

7. 
Svaka vrsta itema implementirana je unutar klase Item odnosno EquippableItem gdje se u pojedine atribute bilježe informacije o itemu poput stackable, picku-upable ili consumeable, ili vrste equippable itema. Većina atributa ostvarena je pomoću
enumeracija koje se nalaze u skripti Utils koja kreira namespace Character.Utils. Na scenu su defaultno dodane neke vrste itema:
	 - Apple -> Permanent usage
	 - Armor -> Pick-upable, Non-Stackable, Equippable(Armor)
	 - Beer -> Permanent usage
	 - Bread -> Permanent usage
	 - Helmet -> Pick-upable, Stackable, Limited(3), Equippable(Helmet)
	 - Sword -> Pick-upable, Non-Stackable, Equippable(Sword)
 	 - Shield -> Pick-upable, Non-Stackable, Equippable(Shield)
	 - Coal -> Pick-upable, Stackable, Unlimited
	 - Crystal -> Pick-upable, Stackable, Limited(2)
Implementirano je neograničeno spawnanje random itema u radijusu (1,1,0) vektorskog razamaka od pozicije charactera - pritiskom na tipku 'Space'

8.
Dodatna funkcionalnost kojom se dodaje glow na item kada je on u dosegu igrača smještena je u skriptu ItemGlow

9.
Verzioniranje je izvedeno pomoću GitHuba. Pojedine funkcionalnosti razvijane su na odgovarajućim granama nastalim iz grane "development". Prema zahtjevima finalna verzija nalazi se na branchu "production". 
Link repozitorija: https://github.com/arihus11/ExordiumTask.
Adresa exoridum.sandbox1@gmail.com dodana je među kolaboratore na projektu (poslan je zahtjev).
