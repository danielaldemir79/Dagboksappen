# Dagboksappen
En enkel och robust konsolapplikation för att skriva, spara, söka, uppdatera och ta bort dagboksanteckningar. Programmet är utvecklat i C# och .NET 8 och använder en Dictionary för effektiv hantering av anteckningar.

---

## Funktioner

- Lägg till ny anteckning (med datum och text)
- Ta bort anteckning
- Lista alla anteckningar (sorterade efter datum)
- Sök anteckning på datum
- Uppdatera befintlig anteckning
- Spara och ladda anteckningar till/från fil (JSON-format)
- Felhantering och loggning till `error.log`
- Tydlig inputvalidering och användarvänligt gränssnitt

---

## Så kör du appen
1. Klona repot och öppna lösningen i Visual Studio 2022.
2. Bygg och kör projektet (F5 eller Ctrl+F5).

## Exempel på I/O
1.	Lägg till anteckning
2.	Ta bort anteckning ...
----------------------------   
3.	Ditt val: 1
4.	Ange datum (ÅÅÅÅ-MM-DD): 2025-09-28
5.	Skriv din anteckning: Idag lärde jag mig om Dictionary i C#.
----------------------------
6.	Anteckningen har lagts till.

## Reflektion
Jag valde att använda en `Dictionary<DateTime, DiaryEntry>` för att snabbt kunna slå upp, uppdatera och ta bort anteckningar baserat på datum. Det gör koden effektiv och enkel att förstå, men begränsar till en anteckning per datum. Jag valde JSON som filformat för att det är lättläst och enkelt att serialisera i C#. Felhantering sker med try/catch och fel loggas till en separat fil, vilket gör appen robust mot t.ex. filfel eller felaktig inmatning. Inputvalidering säkerställer att användaren inte kan ange ogiltiga datum eller tomma texter.
