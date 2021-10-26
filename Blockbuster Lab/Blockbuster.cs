using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockbuster_Lab
{
    class Blockbuster
    {
        public List<Movie> Movies { get; set; } = new List<Movie>();

        public Movie Predator = new VHS("Predator", Movie.Genre.Action, 120, "Start,All the dudes get in a helicopter,Predator murders a few of them,More guys killed by Predator,Arnold says \"KILL ME! CMON! WHAT ARE YOU WAITING FOR?\",Credits");
        public Movie TheShining = new VHS("The Shining", Movie.Genre.Horror, 160, "Start,Jack seems OK,Jack is not OK,\"Red Rum Red Rum\",Jack tries to kill family,Credits");
        public Movie Departed = new DVD("The Departed", Movie.Genre.Drama, 110, "Start,Jack Nicholson is a gangster,Apparently everyone is a gangster,Mental health crisis,Leo cracks the case,Everyone dies,Credits");
        public Movie Casablanca = (new VHS("Casablanca", Movie.Genre.Romance, 130, "Start,Play it again Sam,Here's looking at you kid,Someone flies away in a plane,Credits"));
        public Movie ToyStory = (new DVD("Toy Story", Movie.Genre.Drama, 90, "Start,Buzz shows up,Woody tries to kill Buzz,Buzz and Woody almost die,Both team up to escape,Now they are best friends,Credits"));
        public Movie BillyMadison = (new DVD("Billy Madison", Movie.Genre.Comedy, 100, "Start,Billy goes to school,School is tough for Billy,Peeing your pants is cool,Billy competes in academic decathlon,credits"));

        public Blockbuster()
        {
            Movies.Add(Predator);
            Movies.Add(TheShining);
            Movies.Add(Departed);
            Movies.Add(Casablanca);
            Movies.Add(ToyStory);
            Movies.Add(BillyMadison);
            //Movies.OrderBy(Movie => Movie.Title).ToList();

        }
        public virtual void PrintScenes(List<string> SceneList)
        {

            for (int i = 0; i < SceneList.Count; i++)
            {
                Console.Write($"{i + 1}: ");
                Console.WriteLine(SceneList[i]);
            }
        }
        public List<string> GetScenes(string Scenes)
        {
            List<string> SceneList = Scenes.Split(',').ToList();
            return SceneList;
        }
        public void PrintMovies()
        {

            Movies.OrderBy(Movie => Movie.Title).ToList();
            for (int i = 1; i < Movies.Count; i++)
            {
                
                Console.WriteLine($"{i}: {Movies.OrderBy(Movie => Movie.Title).ToList()[i].Title}"); //SORTED LIST!!
            }
        }
        public Movie CheckOut() 
        {
            Console.WriteLine("\nWhich movie would you like to check out?\n");
            PrintMovies();
            bool rent = true;
            Movie m;
            while (rent)
            {
                try
                {
                    int userInput = int.Parse(Console.ReadLine());

                    if (userInput > 0 && userInput < Movies.Count)
                    {
                        m = Movies.OrderBy(Movie => Movie.Title).ToList()[userInput];
                        Console.WriteLine($"Checking out " + m);
                        return m;
                        
                    }
                    else
                    {
                        Console.WriteLine($"That is not a valid movie.  Please select a movie between 1 and {Movies.Count - 1}.");
                        continue;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"Please input a number from 1 to {Movies.Count - 1} to continue");
                    continue;
                }

            }
            
            return CheckOut();
        }
        public static bool ContinueLoop(string question)
        {
            string response = GetInput(question);
            if (response.ToLower() == "y")
            {
                return true;
            }
            else if (response.ToLower() == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid input.  Please input \"y\" or \"n\".\n");
                return ContinueLoop(question);
            }
        }
        public static string GetInput(string prompt)
        {
            Console.Write(prompt);
            string output = Console.ReadLine();
            return output;
        }
    }
}


