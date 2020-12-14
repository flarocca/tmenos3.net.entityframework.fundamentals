using Newtonsoft.Json;
using System;

namespace TMenos3.Net.EntityFramework.Fundamentals.Utils
{
    public static class ConsoleUtils
    {
        public static void WriteLine(object obj)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"{obj.GetType().Name}: {Serialize(obj)}");

            Console.ForegroundColor = originalColor;
        }

        static string Serialize(object obj) =>
            JsonConvert.SerializeObject(
                obj,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
    }
}
