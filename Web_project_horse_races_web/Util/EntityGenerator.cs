using Microsoft.AspNetCore.Mvc;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;

namespace Web_project_horse_races_web.Util
{
    public class EntityGenerator
    {

        static Random random = new Random();

        private static User CreateRandomUser(int i, bool upper)
        {
            //var randomizer = RandomizerFactory.GetRandomizer(new FieldOptionsEmailAddress());
            //string email = randomizer.Generate(upper) + i;


            string email = Guid.NewGuid().ToString() + "@gmail.com";
            var randomizer = RandomizerFactory.GetRandomizer(new FieldOptionsFirstName());
            string name = randomizer.Generate();



            User user = new User(name, email, name) { RoleId = 3 };
            return user;
        }

        public static List<User> CreateRandomUsers(int count, int startIndex)
        {
            List<User> users = new List<User>();
            for(int i = startIndex; i < startIndex + count; i++)
            {
                User user = new User($"user_{i}", $"user_{i}@gmail.com", "1") { RoleId = 3};
                //users.Add(CreateRandomUser(1, false));
                users.Add(user);
            }
            return users;

        }


        public static Horse CreateRandomHorse()
        {
            var randomizer = RandomizerFactory.GetRandomizer(new FieldOptionsFirstName());
            string name = randomizer.Generate();

            int age = random.Next(1, 40);

            Horse horse = new Horse(name, (byte)age);
            return horse;
        }

        public static List<Horse> CreateRandomHorses(int count)
        {
            List<Horse> horse = new List<Horse>(count);
            for (int i = 0; i < horse.Capacity; i++)
            {
                horse.Add(CreateRandomHorse());
            }
            return horse;
        }


        //public Race CreateRandomRace()
        //{

        //}

        //public List<Race> CreateRandomRaces()
        //{

        //}

    }
}
