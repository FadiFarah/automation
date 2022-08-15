using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace JSON
{
    public class Tests
    {
        private JToken jsonBeatles;
        private JToken jsonFilms;

        [SetUp]
        public void Setup()
        {
            using (var sr = new StreamReader(@"..//..//..//Beatles.json"))
            {
                var reader = new JsonTextReader(sr);
                jsonBeatles = JObject.Load(reader);
            }

            using (var sr = new StreamReader(@"..//..//..//films.json"))
            {
                var reader = new JsonTextReader(sr);
                jsonFilms = JArray.Load(reader);
            }
        }

        [Test]
        public void There_are_four_artists()
        {
            JObject json = JObject.Parse(jsonBeatles.ToString());
            var artists = (JArray)json["Beatles"]["Artists"];
            Assert.That(artists.Count, Is.EqualTo(4));
        }

        [Test]
        public void Two_are_dead_and_two_are_alive()
        {
            JObject json = JObject.Parse(jsonBeatles.ToString());
            var artists = (JArray)json["Beatles"]["Artists"];
            int aliveCount = 0, deadCount = 0;
            foreach(var artist in artists)
            {
                bool isAlive = artist["IsAlive"].ToString() == "Yes" ? true : false;
                if (isAlive) aliveCount++;
                else deadCount++;
            }
            Assert.That(aliveCount, Is.EqualTo(2));
            Assert.That(deadCount, Is.EqualTo(2));
        }

        [Test]
        public void Ringo_plays_drums()
        {
            JObject json = JObject.Parse(jsonBeatles.ToString());
            var artists = (JArray)json["Beatles"]["Artists"];
            var ringo = artists.FirstOrDefault(i => i["Name"].ToString() == "Ringo Starr");
            Assert.That(ringo["Plays"].ToString(), Is.EqualTo("Drums"));
        }

        [Test]
        public void Bilingual_films()
        {
            var moviesList = jsonFilms.ToList();
            var bilingualFilms = moviesList.FindAll(a => a["Language"].ToString().Contains(","));
            foreach(var i in bilingualFilms)
            {
                Console.WriteLine(i);
            }
        }

        [Test]
        public void Crime_genre_movies_number()
        {
            var moviesList = jsonFilms.ToList();
            var crimeFilms = moviesList.FindAll(a => a["Genre"].ToString().Contains("Crime"));
            foreach (var i in crimeFilms)
            {
                Console.WriteLine(i);
            }
        }

        [Test]
        public void Movie_actors_before_2010()
        {
            var moviesList = jsonFilms.ToList();
            var actorsOfMoviesBefore2010 = moviesList.FindAll(a => a["Type"].ToString() == "movie" && int.Parse(a["Year"].ToString()) < 2010).Select(a => a["Actors"].ToString()).ToList();
            foreach (var i in actorsOfMoviesBefore2010)
            {
                Console.WriteLine(i);
            }
        }

        [Test]
        public void average_IMDB_rating()
        {
            var moviesList = jsonFilms.ToList();
            var ratings = moviesList.FindAll(a => a["Type"].ToString() == "movie" && long.TryParse(a["imdbVotes"].ToString().Replace(",", ""), out long num) && num > 200000)
                .Select(a => double.Parse(a["imdbRating"].ToString())).ToList();
            double avg = 0;
            foreach (var r in ratings) avg += r;
            Console.WriteLine(avg / ratings.Count);
        }
    }
}