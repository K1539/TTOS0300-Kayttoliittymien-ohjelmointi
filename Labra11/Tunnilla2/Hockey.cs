using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.ICT
{
    public class HockeyTeam
    {
        public string Name { get; set; }
        public string City { get; set; }
        //Constructor
        public HockeyTeam()
        {
            Name = "";
            City = "none";
        }
        public HockeyTeam(string teamName)
        {
            Name = teamName;
            City = "";
        }
        public HockeyTeam(string teamName, string city)
        {
            Name = teamName;
            City = city;
        }
        public override string ToString()
        {
            return Name + "@" + City;
        }
    }

    public class HockeyLeague
    {
        ObservableCollection<HockeyTeam> teams = new ObservableCollection<HockeyTeam>();
        //Constructor
        public HockeyLeague()
        {
            teams.Add(new HockeyTeam("HIFK", "Helsinki"));
            teams.Add(new HockeyTeam("Jokerit"));
            teams.Add(new HockeyTeam("JYP", "Jyväskylä"));
            teams.Add(new HockeyTeam("Kalpa"));
            teams.Add(new HockeyTeam("Lukko", "Rauma"));
            teams.Add(new HockeyTeam("KooKoo", "Kouvola"));
        }
        //Methods
        public ObservableCollection<HockeyTeam> GetTeams()
        {
            return teams;
        }
    }
}
