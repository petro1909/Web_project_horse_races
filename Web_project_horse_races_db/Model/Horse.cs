using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_project_horse_races_db.Model
{
    public class Horse
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public byte Age { set; get; }
        public List<RaceParticipant> RaceParticipants { set; get; }

        public Horse()
        {
        }
        public Horse(string name, byte age)
        {
            this.Name = name;
            this.Age = age;
            this.RaceParticipants = new List<RaceParticipant>();
        }
        public override string ToString()
        {
            return $"Horse : [\n" +
                $"Name {Name}" +
                $"Age {Age}\n]\n";
        }
    }
}
