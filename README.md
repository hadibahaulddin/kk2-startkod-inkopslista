# Kunskapskontroll 2 – Robust inköpslista

## Felrapport

### Fel 1 
Så som du nämnde, programmet kraschade direkt från början med ett IndexOutOfRangeExeption i Load(). Jag uppafattde att problemet låg i hur filen sparas och läses, att varje vara sparas på en egen rad som "pris;namn", och efter varje rad läggs en radbrytning, även efter den sista. Filen slutar alltså alltid med en tom rad. När programmet sedan läste in filen delade det varje rad vid semikolonet, även den tomma raden längst ner. Eftersom den raden inte har något semikolon finns det ingen andra del att hämta namnet ifrån, och då kraschade programmet. Samtidigt delade Load() bara på en del av radbrytningen, så ett osynligt tecken (\r) hängde med i slutet av varje namn. För att lösa detta så bytte jag till File.ReadAllLines istället, min justering i koden gör att det delar upp filen i rader istället på rätt sätt utan att lämna kvar något skräptecken. Jag lade också till en kontroll som hoppar över rader som saknar antingen pris eller namn, så att en tom eller trasig rad inte längre kan få programmet att krascha. 
