using net_graphql.Models;
using net_graphql.Services;

namespace net_graphql.GraphQL {

    public class MutationMusicCollection {

        public MusicCollection GetMusicCollection() {
            var musicCollection = MusicCollectionService.FromJson();
            return musicCollection;
        }

        public bool AddMusicToCollection(Music music) {
            var musicCollection = GetMusicCollection();
            var newMusic = musicCollection.Musics.FirstOrDefault(x => x.Name == music.Name);

            if(newMusic == null){
                musicCollection.Musics.Add(music);
                MusicCollectionService.ToJson(musicCollection);
                return true;
            }
            
            return false;
        }

        public bool RemoveMusic(Guid id) {
            var musicCollection = GetMusicCollection();
            var music = musicCollection.Musics.FirstOrDefault(x => x.Id == id);

            if(musicCollection.Musics.Remove(music)){
                MusicCollectionService.ToJson(musicCollection);
                return true;
            }
            
            return false;
        }
        
    }
}