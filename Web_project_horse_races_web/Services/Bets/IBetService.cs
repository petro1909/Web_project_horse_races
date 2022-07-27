using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.Model;
using System.Reflection;

namespace Web_project_horse_races_web.Services.Bets
{
    public interface IBetService
    {
        public static IBetService CreateService(string betTypeName)
        {
            string implBetServiceName = $"{betTypeName}BetService";
            Type betInterfaceType = typeof(IBetService);
            Type betImplementedType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => betInterfaceType.IsAssignableFrom(t) && !t.IsInterface && t.Name == implBetServiceName);
            IBetService betServiceInstance = (IBetService)Activator.CreateInstance(betImplementedType);
            return betServiceInstance;
        }

        public bool CalculateBet(UserBet bet);
        public double CalculateBetCoefficient(List<BookmakerBet> bbets);
    }
}
