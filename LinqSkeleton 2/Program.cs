using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
                IEnumerable<Artist> MVArtist = Artists.Where(artist => artist.Hometown=="Mount Vernon");
                foreach(Artist x in MVArtist)
                {
                    System.Console.WriteLine($"{x.ArtistName}, {x.Age} is from Mount Vernon");
                }
            //Who is the youngest artist in our collection of artists?
             var babyArtist = Artists.OrderBy(i => i.Age).Take(1);
             foreach(Artist i in babyArtist){
                 System.Console.WriteLine(i.ArtistName + " " + i.Age + " is the youngest artisit.");
             }

            //Display all artists with 'William' somewhere in their real name
                IEnumerable<Artist> artistQuery =
                    from artist in Artists
                    where artist.RealName.Contains("William")
                    select artist;
                foreach(Artist x in artistQuery)
                {
                    System.Console.WriteLine($"Artists with 'William': {x.ArtistName},{x.RealName} {x.Age}");
                }

            //Display the 3 oldest artist from Atlanta
            var AtlantaArtist = Artists.OrderByDescending(a => a.Age).Where(a => a.Hometown=="Atlanta").Take(3);
            foreach(Artist a in AtlantaArtist)
            {
                System.Console.WriteLine(a.RealName + " " + a.Age + " is one of the 3 oldest artist from Atlanta.");
            }

            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            var groupName = (from g in Groups
                join a in Artists
                on g.Id equals a.GroupId
                where a.Hometown != "New York City"
                group g by g.GroupName
                into gGroups
                select gGroups);
                foreach(var g in groupName)
                {
                    System.Console.WriteLine("Groups that have members that are not from New York City: {0} ",g.Key);
                }

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            var artists = (
                from a in Artists
                join g in Groups
                on a.GroupId equals g.Id
                where g.GroupName =="Wu-Tang Clan"
                select a
            );
            foreach(Artist a in artists)
            {
                System.Console.WriteLine("All members of the group 'Wu-Tang Clan:{0}'", a.ArtistName);
            }

            IEnumerable<Artist> StageName =
                    from artist in Artists
                    where artist.RealName == artist.ArtistName
                    select artist;
                foreach(Artist x in StageName)
                {
                    System.Console.WriteLine($"Artist name is real name: {x.ArtistName},{x.RealName} {x.Age}");
                }
        }
    }
}
