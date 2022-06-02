using System.Text;
using net_graphql.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace net_graphql.Services {

    public class MusicCollectionService {

        private const string JsonFile = "musics.json";

        //Deserialize
        public static MusicCollection FromJson() {
            if(File.Exists(JsonFile)) {
                var jsonContent = File.ReadAllText(JsonFile, Encoding.UTF8);
                return JsonConvert.DeserializeObject<MusicCollection>(jsonContent);
            }
            
            return new();
        }

        //Serialize
        public static void ToJson(MusicCollection musics) {
            var jsonContent = JsonConvert.SerializeObject(musics, new JsonSerializerSettings {
                ContractResolver = new DefaultContractResolver {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                Formatting = Formatting.Indented
            });

            File.WriteAllText(JsonFile, jsonContent);
        }
    }


}