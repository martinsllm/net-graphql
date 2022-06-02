using net_graphql.Models;
using net_graphql.Services;

namespace net_graphql.GraphQL {

    public class QueryMusicCollection {
        
        public MusicCollection GetMusicCollection() {
            var musicCollection = MusicCollectionService.FromJson();
            return musicCollection;
        }

        public Music GetMusic(Guid id) {
            var musicCollection = MusicCollectionService.FromJson();
            var music = musicCollection.Musics.FirstOrDefault(x => x.Id == id);
            
            return (music != null) ? music : null;
        }
        
    }

}