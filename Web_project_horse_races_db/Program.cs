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
        public delegate int MathOperation(int i, int j);
        public static MathOperation operation;
        static void Main(string[] args)
        {
            operation += Substract;
            operation += Divide;
            
            GetInvocationalList(operation);
            //RaceRepository raceRepository = new RaceRepository();
            //raceRepository.DeleteAll();

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
        }

        public static void GetInvocationalList(Delegate del)
        {
            foreach(Delegate d in del.GetInvocationList())
            {
                Console.WriteLine(d.Target);
                Console.WriteLine(d.Method);
                Console.WriteLine();
            }
        }


        public static int Substract(int i, int j)
        {
            return i + j;
        }

        public static int Divide(int i, int j)
        {
            return i / j;
        }
    }
}
