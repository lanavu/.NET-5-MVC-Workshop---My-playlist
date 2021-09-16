# .NET5 MVC

Workshop
Velkommen til workshop med Knowit Experience! Her finner du instruksjoner til hvordan du får satt opp og kjørt en ny web applikasjon med .NET 5 og C# på din lokale maskin. Videre vil du få oppgaver som skal gjøre deg kjent med web applikasjonen. Temaet for workshoppen er å kunne opprette en enkel musikkspilleliste.

## Introduksjon - Opprett et nytt prosjekt

1. Last ned [.NET 5 SDK](https://dotnet.microsoft.com/download) - Software Development Kit

2. Åpne terminal hvis du har mac / linux, eller command prompt dersom du har Windows

3. Naviger deg til den mappen du ønsker å opprette prosjektet i

4. Opprett en tom mappe f.eks /MyPlaylist der prosjektet ditt skal ligge

```
mkdir MyPlaylist
```

5. Naviger deg inn i mappen og kjør følgende kommando for å opprette en ny dotnet web applikasjon:

```
dotnet new mvc
```

6. Start web applikasjonen:

```
dotnet run
```

7. Nå kan du se webapplikasjonen din kjøre på din lokale maskin:
   http://localhost:5000 eller https://localhost:5001

> Trykk Ctrl + C, for å avslutte applikasjonen

8. Bli kjent med applikasjonen ved å trykke deg gjennom fanene/sidene "Home" og "Privacy"

## Åpne prosjektet i Visual Studio Code

Videre skal vi se på selve koden for applikasjonen

1. Last ned [Visual studio code](https://code.visualstudio.com/)

2. Åpne Visual Studio Code

3. Åpne prosjektet ditt i Visual Studio Code

```
File >> Open Folder >> ... MyPlaylist
```

4. Innstaller gjerne extensions for C# for å gjøre utviklingen litt enklere

<!---Snakk om MVC-modellen på white board--->

Her ser du en MVC-struktur, med mappe for **Models**, **Views** og **Controllers**. Naviger deg litt frem og tilbake mellom filene, for å bli kjent med strukturen.

## Del 1 - Bli kjent med MVC

### 1.1 Opprett en ny side som heter "Playlist"

1. Naviger deg til mappen /Controllers, og opprett en ny fil som heter PlaylistController.cs

```
/Controllers/PlaylistController.cs
```

```csharp
using Microsoft.AspNetCore.Mvc;

namespace MyPlaylist.Controllers
{
    public class PlaylistController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Playlist";
            return View();
        }
    }
}
```

`using` fungere på samme måte som `import` i java.

2. Naviger deg til mappen /Views, og opprett en undermappe "Playlist" og under der, en fil som heter "Index.cshtml".

```
/Views/Playlist/Index.cshtml
```

Dette blir viewet til den nye siden vi lager. Legg til en overskrift på siden med tittelen vi definerte i controlleren, og en paragraf med en valgfri tekst.

Du kan hente ut tittelen satt i **PlaylistController** ved å skrive følgende i **/Playlist/Index.cshtml**.

```
<h1>@ViewData["Title"]</h1>
```

3. Naviger deg til partial viewet `/Shared/_Layout.cshtml` og legg til et nytt menypunkt i headeren som du kaller "Playlist". Legg merke til attributtene.

<!--- asp-controller: MyPlaylist --->
<!--- asp-action: Index --->

4. Lagre alle filene og kjør prosjektet på nytt i terminal/command prompt

```
Ctrl + C
```

```
dotnet run
```

5. Se oppdateringene på http://localhost:5000 eller https://localhost:5001

Vi har ikke data for playlist ennå, og kommer tilbake til dette etter at vi har satt opp data.

Til nå har vi opprettet en side "Playlist" kun ved hjelp av **Controller** og **View**. Videre ser vi på hvordan vi involverer **Model**.

### 1.2 Opprett en ny side som heter "Track"

1. Opprett både **Controller** og **View** for track. Husk navnekonvensjonen til MVC.

Test at siden _Track_ fungerer

```
http://localhost:5000/Track
```

2. Videre skal du opprette en **Model** for Track. Den oppretter du under mappen _Models_. Lag en ny c#-fil som heter **Track**.

```
/Models/Track.cs
```

Modellen **Track** skal inneholde følgende egenskaper:

| Type   | Name     |
| ------ | -------- |
| int    | Id       |
| string | Title    |
| string | Artist   |
| int    | NumPlays |

Vi kan definere egenskaper(properties) på følgende måte:

```csharp
public type Name { get; set; }
```

Vi trenger ikke å skrive egne getters og setters i C#.

3. Nå kan vi bruke modellen i TrackController ved å opprette en ny instans i **TrackController** og deretter sende modellen gjennom til **View**

Se om du kan opprette et Track-objekt i **TrackController**, sette Title til "My track title", og dermed sende modellen/objektet til **View**.

I Index.cshtml ønsker vi å ta imot Track som modell. Et view tar imot en modell for å kunne vise data fra modellene. For å kunne vise Track-data i index.cshtml skriver vi følgende øverst i Index.cshtml:

```
@model Track
```

Index.cshtml vil da vite at den skal ta imot Track-data. Du kan f.eks få printet ut verdien slik:

```html
<h1>@Model.Title</h1>
```

MVC vil lete i Views etter en mappe basert på kontrollernavnet. Hvis kontrolleren heter "TrackController" vil MVC automatisk lete etter mappen "Track" under Views for å finne tihørende Views. MVC vil deretter hente ut Views basert på metodenavnene i kontrolleren. Dersom vi har en metode som heter Index(), vil MVC lete etter Index.cshtml.

## Del 2 - Oppsett av data

### 2.1. Legg til Mockdata fra SampleTracks.cs

Last ned `SampleTracks.cs` og legg filen inn i rotmappen til prosjektet. Sjekk at filen inneholder riktig namespace. Det må være det samme som det du har kalt prosjektet ditt. SampleTracks.cs bruker modellen **Track** for å lagre en sang.
Du får en track ved å kalle:

```csharp
new SampleTracks().GetTrackById(id);
```

Id er lagt inn som et løpenummer i listen av sanger. Den første sangen har Id=0.

Du får en liste av tracks ved å kalle:

```csharp
new SampleTracks().GetAllTracks();
```

### 2.2. Hent data fra `SampleTracks.cs` til Track-siden.

Vi skal videre se på hvordan vi kan hente ut Track-data dynamisk. Hver sang trenger sin egen Track-side, og vi må vite hvilken Track-modell brukeren etterspør. Dette skal håndteres i `TrackController.cs` ved at brukeren/clienten kan sende med en parameter, i dette tilfellet en **Id**.

Ettersom vi har ca 30 tracks, har vi tilsvarende antall Track-modeller fordi vi trenger én Modell per track.

For å kunne styre hvilken Track-modell som sendes til Index.cshtml, må vi gå inn i kontrolleren for å håndtere hvilken Track-modell som skal sendes når.

1. Endre logikk i TrackController.

TrackController.cs bør se slik ut:

```csharp
using Microsoft.AspNetCore.Mvc;
using MyPlaylist.Models;
using System;

namespace MyPlaylist.Controllers
{
    public class TrackController : Controller
    {
        public IActionResult Index()
        {
            var trackModel = ...
            return View(trackModel);
        }
    }
}
```

2. Vi ønsker å styre hvilken Track-modell som skal sendes med i "return View(trackModel)". I modellen Track.cs har vi satt opp `Id` som en egenskap, og ønsker å styre det ved hjelp av denne verdien. Index() bør derfor ta imot en Id som parameter.

Bruk GetTrackById(id) i SampleTracks for å returnere en Track basert på id:

```csharp
new SampleTracks().GetTrackById(id);
```

3. Kjør applikasjonen, og sjekk om du får ut en Track basert på Id 1:

```
http://localhost:5000/Track/Index/1
```

Dersom vi bruker parametre må vi også ha med navnet på **View** med i URLen, i dette tilfellet **Index**.

## Del 3 - Models vs ViewModels

Får å bruke reell data vil som regel en MVC-applikasjon være koblet mot en database. For å kunne bruke data fra databaser trenger vi å representere data i applikasjonen som modeller. Det er ikke alltid vi ønsker å vise data til brukeren på samme måte som modellene kan gjenspeile. F.eks synes vi kanskje ikke at det er relevant å vise én og én track om gangen. Selv om MVC står for Model View Controller, er det vanlig å introdusere noe som kalles en `ViewModel` som skal gjenspeile hvordan vi skal vise data i et View. I vår applikasjon ønsker vi å vise alle tracks i en liste for å lage en spilleliste. Et view kan kun ta imot én modell om gangen, og vi har 30 Track-modeller vi ønsker å vise samtidig. For å løse dette introduserer vi en `PlaylistViewModel` som skal være en `ViewModel` som inneholder en samling av alle Track-modellene.

### 3.1 Opprett en ViewModel for Playlist

I "Playlist" ønsker vi et view der vi viser fram en spilleliste med tilhørende sanger. Spillelisten skal ha et navn. Vi begynner med å opprette en viewModel for Playlist. Det går også an å legge ViewModels under Models, men det er vanlig å legge det i en egen mappe.

1. Opprett en ny mappe som heter **ViewModels** på samme nivå som **Models**.

2. Opprett en ny fil med en playlist-viewModel som har egenskapen "Name" med `get` og `set`.

```
/ViewModels/PlaylistViewModel.cs
```

NB! Husk riktig namespace (MyPlaylist.ViewModels).

2. Definer PlaylistViewModel som modell i PlaylistController. Sett et navn til spillelisten, og send med modellen i det du returnerer viewet i Index-metoden. Husk å ha med `using MyPlaylist.ViewModels;` for å kunne bruke `PlaylistViewModel`.

```csharp
var model = new PlaylistViewModel();
model.Name = "My favourite songs";
return View(model);
```

Husk at Index.cshtml under /Views/Playlist/ bør inneholde hvilken modell som sendes gjennon kontrolleren, som i dette tilfellet er en PlaylistViewModel (@model MyPlaylist.ViewModels.PlaylistViewModel).

3. Vis spillelistens navn i viewet ved hjelp av:

```
@Model.Name
```

4. Legg til en ny egenskap i PlaylistViewModel:

```csharp
    public List<Track> Playlist { get; set; }
```

Husk å importere `using System.Collections.Generic` for å kunne bruke `List<T>`.

5. Gå til PlaylistController, og sett model.Playlist til en liste av Tracks.
   Bruk metoden fra SampleTracks til å gjøre dette:

```csharp
new SampleTracks().GetAllTracks();
```

6. I Index.cshtml kan vi bruke en foreach-løkke for å iterere gjennom `Playlist`. For å bruke c#-kode i et view setter vi `@` foran:

```html
<table class="table table-striped">
  <thead>
    <tr>
      <th>Title</th>
      <th>Artist</th>
      <th>Plays</th>
    </tr>
  </thead>
  <tbody>
    @foreach(var track in @Model.Playlist) {
    <tr>
      <td>@track.Title</td>
      <td>@track.Artist</td>
      <td>@track.NumPlays</td>
    </tr>
    }
  </tbody>
</table>
```

Vi bruker bootstrap sin table-tag for å lage en tabell med track-data.

## Del 4 - Ekstraoppgaver

### 4.1. Lag en spilleliste som viser sangene alfabetisk

### 4.2. Link sangene i spillelisten til Track-siden med riktig id (bruk asp-attributter)

### 4.3. Lag en spilleliste som viser sangene etter antall avspillinger med flest avspillinger øverst.
