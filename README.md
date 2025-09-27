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

## Exempel på användning
Välj ett alternativ:
1.	Lägg till anteckning
2.	Ta bort anteckning
3.	Sök anteckning på datum
4.	Uppdatera anteckning
5.	Lista alla anteckningar
6.	Läs från fil
7.	Spara till fil
8.	Avsluta

Ditt val: 1 Ange datum (ÅÅÅÅ-MM-DD): 2025-09-28 
Skriv din anteckning: Lärde mig om Dictionary i C# idag! 
Anteckningen har lagts till.


## Reflektion

Jag valde att använda en `Dictionary<DateTime, DiaryEntry>` som datastruktur för att snabbt kunna slå upp, uppdatera och ta bort anteckningar baserat på datum. Det ger effektivitet och enkel kod, men innebär att endast en anteckning per datum är möjlig. Filhanteringen sker i JSON-format, vilket är både läsbart och lätt att serialisera/deserialisera i C#. All filhantering och användarinput är innesluten i try/catch-block för att hantera fel på ett kontrollerat sätt, och fel loggas till en separat fil (`error.log`). Inputvalidering säkerställer att användaren inte kan ange ogiltiga datum eller tomma texter, vilket gör appen robust och användarvänlig. Gränssnittet är tydligt med färgade meddelanden för att guida användaren. 

Sammantaget är lösningen enkel att underhålla och vidareutveckla.

---

## Mappstruktur
/Dagboksappen /Dagboksappen/    

# C#-projektfiler README.md .gitignore
