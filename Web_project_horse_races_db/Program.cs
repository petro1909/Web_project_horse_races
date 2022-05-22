using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.SqlServer;
using Web_project_horse_races_db.Model;
using Web_project_horse_races_db.EntityFramework;
using Web_project_horse_races_db.Repository;

namespace Web_project_horse_races_db
{
    class Program
    {
        static void Main(string[] args)
        {

            //List<RaceParticipant> raceParticipants = new List<RaceParticipant>();
            //foreach (Horse horse in horses)
            //{
            //    raceParticipants.Add(new RaceParticipant((byte)horse.Id) { HorseId = horse.Id, RaceId = race.Id, Position = 0 });
            //}
            //race.RaceParticipants = raceParticipants;
            // List<User> users = userRep.GetAll();
            // foreach(User u in users)
            // {
            //     Console.WriteLine(u);
            // }
            // RaceRepository repository = new RaceRepository();

            //List<Race> races = repository.GetAll();
            unchecked
            {
                int r = int.MinValue - 127;

                string result = string.Empty;

                while (r >= 1)
                {
                    long reminder = r % 16;
                    if (reminder > 9)
                    {
                        result += (char)(reminder + 55);
                    }
                    else
                    {
                        result += reminder;
                    }

                    r /= 16;
                }

                char[] resultArr = result.ToCharArray();
                Array.Reverse(resultArr);
                Console.WriteLine(new string(resultArr));
            }
        }
    }
}
