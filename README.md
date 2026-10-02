# Kunskapskontroll 2 – Robust inköpslista

## Felrapport

### Fel 1

Så som du nämnt, så kraschade programmet direkt från början med ett IndexOutOfRangeExeption i Load(). Jag uppafattde att problemet låg i hur filen sparas och läses, att varje vara sparas på en egen rad som "pris;namn", och efter varje rad läggs en radbrytning, även efter den sista. Filen slutar alltså alltid med en tom rad. När programmet sedan läste in filen så delade det varje rad vid semikolonet, även den tomma raden längst ner. Eftersom den raden inte har något semikolon finns det ingen andra del att hämta namnet ifrån, och då kraschade programmet. Samtidigt delade Load() bara på en del av radbrytningen, så ett osynligt tecken (\r) hängde med i slutet av varje namn. För att lösa detta så bytte jag till File.ReadAllLines istället, min justering i koden gör att det delar upp filen i rader istället på rätt sätt utan att lämna kvar något skräptecken. Jag lade också till en kontroll som hoppar över rader som saknar antingen pris eller namn, så att en tom eller trasig rad inte längre kan få programmet att krascha.

### Fel 2

När programmet väl startade så visade det en totalsumma på 121 kr, men när jag räknade själv efter för hand så insåg jag att 15 + 32 + 89 = 136 kr. Skillnaden var exakt 15 kr, som är priset på mjölken, som ligger först i listan. Programmet kraschade inte, utan räknade bara fel, det var en bra luring av Tomas för att det är en lätt fel att missa. Problemet låg i for-loopen i Total(), som började på i = 1, men så som jag hittils vet så börjar C# listor på index 0, så den första varan ligger på items[0]. Eftersom loopen började ett steg för sent så hoppades den första varan alltid över och kom aldrig med i summan. Alltså min lösning var att ändra startvärdet från i = 1 till i = 0, så att loopen nu börjar från den första varan och räknar med alla varor i listan.
