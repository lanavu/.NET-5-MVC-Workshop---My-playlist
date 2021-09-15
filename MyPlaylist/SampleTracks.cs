using MyPlaylist.Models;
using System.Collections.Generic;

namespace MyPlaylist
{
    public class SampleTracks
    {
        List<Track> tracks = new List<Track>(30);

        public SampleTracks()
        {
            tracks.Add(new Track { Id = 0, Title = "Sick boy", Artist = "The Chainsmokers", NumPlays =  6135077 });
            tracks.Add(new Track { Id = 1, Title = "Perfect", Artist = "Ed Sheeran", NumPlays = 10050000 });
            tracks.Add(new Track { Id = 2, Title = "Havana", Artist = "Camila Cabello Feat. Young Thug", NumPlays = 7400813 });
            tracks.Add(new Track { Id = 3, Title = "rockstar", Artist = "Post Malone Feat. 21 Savage", NumPlays = 8961661 });
            tracks.Add(new Track { Id = 4, Title = "Filthy", Artist = "Justin Timberlake", NumPlays =  633283 });
            tracks.Add(new Track { Id = 5, Title = "Dusk Till Dawn", Artist = "ZAYN Feat. Sia", NumPlays =  7002123 });
            tracks.Add(new Track { Id = 6, Title = "Feel It Still", Artist = "Portugal. The Man", NumPlays =  9658657 });
            tracks.Add(new Track { Id = 7, Title = "Échame La Culpa", Artist = "Luis Fonsi & Demi Lovato", NumPlays = 2221652 });
            tracks.Add(new Track { Id = 8, Title = "Let You Down", Artist = "NF", NumPlays = 3091658 });
            tracks.Add(new Track { Id = 9, Title = "River", Artist = "Eminem Feat. Ed Sheeran", NumPlays = 1304326});
            tracks.Add(new Track { Id = 10, Title = "New Rules", Artist = "Dua Lipa", NumPlays = 6012272 });
            tracks.Add(new Track { Id = 11, Title = "Him & I", Artist = "G-Eazy & Halsey", NumPlays = 1771741 });
            tracks.Add(new Track { Id = 12, Title = "Best Friend", Artist = "Sofi Tukker Feat. NERVO & The Knocks & Alisa Ueno", NumPlays = 2293012 });
            tracks.Add(new Track { Id = 13, Title = "Bum Bum Tam Tam", Artist = "MC Fioti Feat. J Balvin & Future & Stefflon Don & Juan Magan", NumPlays = 474331 });
            tracks.Add(new Track { Id = 14, Title = "I Miss You", Artist = "Clean Bandit Feat. Julia Michaels", NumPlays = 1395449 });
            tracks.Add(new Track { Id = 15, Title = "Whatever It Takes", Artist = "Imagine Dragons", NumPlays = 3092297 });
            tracks.Add(new Track { Id = 16, Title = "No Roots", Artist = "Alice Merton", NumPlays = 4565549 });  
            tracks.Add(new Track { Id = 17, Title = "How Long", Artist = "Charlie Puth", NumPlays =  2660558}); 
            tracks.Add(new Track { Id = 18, Title = "Wolves", Artist = "Selena Gomez & Marshmello", NumPlays = 2302853 }); 
            tracks.Add(new Track { Id = 19, Title = "Katchi", Artist = "Ofenbach vs. Nick Waterhouse", NumPlays =  4649332}); 
            tracks.Add(new Track { Id = 20, Title = "Finesse (Remix)", Artist = "Bruno Mars & Cardi B", NumPlays =  276790}); 
            tracks.Add(new Track { Id = 21, Title = "Believe", Artist = "Eminem", NumPlays = 196727}); 
            tracks.Add(new Track { Id = 22, Title = "What Lovers Do", Artist = "Maroon 5 Feat. SZA", NumPlays = 6400961 }); 
            tracks.Add(new Track { Id = 23, Title = "Anywhere", Artist = "Rita Ora", NumPlays = 2040001}); 
            tracks.Add(new Track { Id = 24, Title = "Breathe", Artist = "Jax Jones Feat. Ina Wroldsen", NumPlays = 893340}); 
            tracks.Add(new Track { Id = 25, Title = "Cola (Club Mix)", Artist = "CamelPhat & Elderbrook", NumPlays = 3046590}); 
            tracks.Add(new Track { Id = 26, Title = "Leave A Light On", Artist = "Tom Walker", NumPlays =  1407732}); 
            tracks.Add(new Track { Id = 27, Title = "Silence", Artist = "Marshmello Feat. Khalid", NumPlays =  3000351}); 
            tracks.Add(new Track { Id = 28, Title = "Mi Gente", Artist = "J Balvin & Willy William Feat. Beyoncé", NumPlays = 10714655}); 
            tracks.Add(new Track { Id = 29, Title = "Too Good At Goodbyes", Artist = "Sam Smith", NumPlays =  4421282}); 
            tracks.Add(new Track { Id = 30, Title = "No Limit", Artist = "G-Eazy Feat. A$AP Rocky & Cardi B", NumPlays =  2256383}); 
        }
        public Track GetTrackById(int id){
            if(id >= tracks.Count || id < 0){
                return null;
            }
            return tracks[id];
        }
        public List<Track> GetAllTracks(){
            return tracks;
        }
    }    
}