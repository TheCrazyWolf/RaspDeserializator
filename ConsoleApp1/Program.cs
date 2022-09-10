using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string url = "https://asu.samgk.ru/api/schedule/313/2022-09-12/";

            var client = new WebClient();
            string json = client.DownloadString(url);


            Root lessons = JsonSerializer.Deserialize<Root>(json);

            foreach (var item in lessons.lessons)
            {
                Console.WriteLine($"{item.num} {item.title} {item.teachername} {item.cab}");
            }

        }
    }

    [Serializable]
    public class Lesson
    {
        public string title { get; set; }
        public string num { get; set; }
        public string teachername { get; set; }
        public object nameGroup { get; set; }
        public string cab { get; set; }
        public string resource { get; set; }
    }

    [Serializable]
    public class Root
    {
        public string date { get; set; }
        public List<Lesson> lessons { get; set; }
    }


}
