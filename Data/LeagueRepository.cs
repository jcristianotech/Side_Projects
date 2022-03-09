using JohnTestWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohnTestWebApp.Data
{
    internal class LeagueRepository
    {
        private static List<TeamViewModel> league;

        static LeagueRepository()
        {
            league = new List<TeamViewModel>();

            league.Add(
                new TeamViewModel()
                {
                    Id = 1,
                    Conference = TeamConference.Eastern,
                    Name = "Cedar Rapids RoughRiders",
                    YearFounded = 1999,
                    Arena = "ImOn Ice Arena",
                    Capacity = 4000,
                    City = "Cedar Rapids, IA"
                });

            league.Add(
                new TeamViewModel()
                {
                    Id = 2,
                    Conference = TeamConference.Eastern,
                    Name = "Chicago Steel",
                    YearFounded = 2000,
                    Arena = "Fox Valley Ice Arena",
                    Capacity = 2800,
                    City = "Geneva, IL"
                });

            league.Add(
                new TeamViewModel()
                {
                    Id = 3,
                    Conference = TeamConference.Eastern,
                    Name = "Dubuque Fighting Saints",
                    YearFounded = 2010,
                    Arena = "Mystique Ice Centre",
                    Capacity = 3079,
                    City = "Dubuque, IA"
                });

            league.Add(
                new TeamViewModel()
                {
                    Id = 4,
                    Conference = TeamConference.Eastern,
                    Name = "Green Bay Gamblers",
                    YearFounded = 1994,
                    Arena = "Resch Center",
                    Capacity = 8709,
                    City = "Green Bay, WI"
                });

            league.Add(
                new TeamViewModel()
                {
                    Id = 5,
                    Conference = TeamConference.Eastern,
                    Name = "Madison Capitols",
                    YearFounded = 2014,
                    Arena = "Bob Suter's Capitol Ice Arena",
                    Capacity = 2611,
                    City = "Middleton, WI"
                });

            league.Add(
                new TeamViewModel()
                {
                    Id = 6,
                    Conference = TeamConference.Eastern,
                    Name = "Muskegon Lumberjacks",
                    YearFounded = 2010,
                    Arena = "Mercy Health Arena",
                    Capacity = 5100,
                    City = "Muskegon, MI"
                });

            league.Add(
                new TeamViewModel()
                {
                    Id = 7,
                    Conference = TeamConference.Eastern,
                    Name = "Team USA",
                    YearFounded = 1996,
                    Arena = "USA Hockey Arena",
                    Capacity = 3504,
                    City = "Plymouth, MI"
                });

            league.Add(
                new TeamViewModel()
                {
                    Id = 8,
                    Conference = TeamConference.Eastern,
                    Name = "Youngstown Phantoms",
                    YearFounded = 2003,
                    Arena = "Covelli Centre",
                    Capacity = 5717,
                    City = "Youngstown, OH"
                });

            league.Add(
                new TeamViewModel()
                {
                    Id = 9,
                    Conference = TeamConference.Western,
                    Name = "Des Moines Buccaneers",
                    YearFounded = 1980,
                    Arena = "Buccaneer Arena",
                    Capacity = 4161,
                    City = "Urbandale, IA"
                });

            league.Add(
                new TeamViewModel()
                {
                    Id = 10,
                    Conference = TeamConference.Western,
                    Name = "Fargo Force",
                    YearFounded = 2008,
                    Arena = "Scheels Arena",
                    Capacity = 4000,
                    City = "Fargo, ND"
                });

            league.Add(
                new TeamViewModel()
                {
                    Id = 11,
                    Conference = TeamConference.Western,
                    Name = "Lincoln Stars",
                    YearFounded = 1996,
                    Arena = "Ice Box",
                    Capacity = 4212,
                    City = "Lincoln, NE"
                });

            league.Add(
                new TeamViewModel()
                {
                    Id = 12,
                    Conference = TeamConference.Western,
                    Name = "Omaha Lancers",
                    YearFounded = 1986,
                    Arena = "Ralston Arena",
                    Capacity = 4000,
                    City = "Ralston, NE"
                });

            league.Add(
                new TeamViewModel()
                {
                    Id = 13,
                    Conference = TeamConference.Western,
                    Name = "Sioux City Musketeers",
                    YearFounded = 1972,
                    Arena = "Fleet Farm Arena",
                    Capacity = 9500,
                    City = "Sioux City, IA"
                });

            league.Add(
                new TeamViewModel()
                {
                    Id = 14,
                    Conference = TeamConference.Western,
                    Name = "Sioux Falls Stampede",
                    YearFounded = 1980,
                    Arena = "Denny Sanford Premier Center",
                    Capacity = 4047,
                    City = "Sioux Falls, SD"
                });

            league.Add(
                new TeamViewModel()
                {
                    Id = 15,
                    Conference = TeamConference.Western,
                    Name = "Tri-City Storm",
                    YearFounded = 2000,
                    Arena = "Viaero Event Center",
                    Capacity = 4047,
                    City = "Kearney, NE"
                });

            league.Add(
                new TeamViewModel()
                {
                    Id = 16,
                    Conference = TeamConference.Western,
                    Name = "Waterloo Black Hawks",
                    YearFounded = 1962,
                    Arena = "Young Arena",
                    Capacity = 3500,
                    City = "Waterloo, IA"
                });
        }

        /*public static void Create(TeamViewModel team)
        {
            int maxId = 0;
            if (league?.Any() == true)
            {
                maxId = league.Max(r => r.Id);
            }

            team.Id = maxId + 1;

            league.Add(team);
        }*/ 
        
        public void Create(TeamViewModel team)
        {
            int maxId = 0;
            if (league?.Any() == true)
            {
                maxId = league.Max(r => r.Id);
            }

            team.Id = maxId + 1;

            league.Add(team);
        }

        public TeamViewModel GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return league.FirstOrDefault(r => r.Id == id);
        }

        public List<TeamViewModel> GetAll()
        {
            return league;
        }

        public bool Update(TeamViewModel team)
        {
            if (team == null)
            {
                return false;
            }

            TeamViewModel teamToUpdate = null;
            foreach (TeamViewModel existing in league)
            {
                if (existing.Id == team.Id)
                {
                    teamToUpdate = existing;
                }
            }
            if (teamToUpdate == null)
            {
                return false;
            }
            else
            {
                teamToUpdate.Conference = team.Conference;
                teamToUpdate.Name = team.Name;
                teamToUpdate.YearFounded = team.YearFounded;
                teamToUpdate.Arena = team.Arena;
                teamToUpdate.Capacity = team.Capacity;
                teamToUpdate.City = team.City;

                return true;
            }
        }

        public void Delete(int? id)
        {
            TeamViewModel theTeam = league.FirstOrDefault(x => x.Id == id);
            if (theTeam != null)
            {
                league.Remove(theTeam);
            }
        }


    }
}