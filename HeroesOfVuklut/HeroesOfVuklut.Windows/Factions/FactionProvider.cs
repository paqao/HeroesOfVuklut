using HeroesOfVuklut.Shared.Factions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesOfVuklut.Shared;
using System.IO;
using Newtonsoft.Json;
using HeroesOfVuklut.Engine.DI;

namespace HeroesOfVuklut.Windows.Factions
{
    [ServiceInject(typeof(FactionProvider), typeof(IFactionProvider))]
    public class FactionProvider : IFactionProvider
    {
        private IList<FactionAspect> _factions = new List<FactionAspect>();
        public void LoadConfiguration()
        {
            _factions.Clear();

            FactionConfiguration factionsConf;
            using (var textReader = File.OpenText("data/factions.json"))
            {
                string fileContent = textReader.ReadToEnd();
                factionsConf = JsonConvert.DeserializeObject<FactionConfiguration>(fileContent);
            }

            foreach (var item in factionsConf.Factions)
            {
                _factions.Add(new FactionAspect
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
        }
        public FactionAspect GetFaction(int id)
        {
            return _factions.FirstOrDefault(f => f.Id == id);
        }
    }
}
