using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockbuster_Lab
{
    abstract class Movie
    {
        public string Title { get; set; }
        public Genre Category { get; set; }
        public int Runtime { get; set; }
        public string Scenes { get; set; }
        public List<string> SceneList => GetScenes(Scenes);

        public enum Genre
        {
            Drama,
            Comedy,
            Horror,
            Romance,
            Action
        }
        public Movie(string Title, Genre Category, int Runtime, string Scenes)
        {
            this.Title = Title;
            this.Category = Category;
            this.Runtime = Runtime;
            this.Scenes = Scenes;
        }
        public override string ToString()
        {
            return $"Title: {Title}\nCategory: {Category}\nRuntime: {Runtime}";
        }
        public virtual void PrintScenes(List<string> SceneList)
        {
            for (int i = 0; i < SceneList.Count; i++)
            {
                Console.Write($"{i}: ");
                Console.WriteLine(SceneList[i]);
            }
        }
        public abstract void Play(); //both Play() overrides cycle through the "rest" of the movie.  
      
        public List<string> GetScenes(string Scenes)
        { 
            List<string> SceneList = Scenes.Split(',').ToList();
            return SceneList;
        }
    }
}
