using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using ProjectPlanner.Models.Abstracts;
using ProjectPlanner.Models.Classes;
using ProjectPlanner.Models.Interfaces;

namespace ProjectPlanner.Models.Data
{
    internal static class ManagementDB
    {
        internal static IList<IBranch> Load()
        {
            try
            {
                string file = File.ReadAllText("Projects.json", Encoding.UTF8);
                IList<IBranch>? mainBranch = JsonSerializer.Deserialize<List<Branch>>(file)?.Cast<IBranch>().ToList(); 
                return mainBranch ?? new List<IBranch>();
            }
            catch (FileNotFoundException)
            {
                File.WriteAllText("Projects.json", "");
                return new List<IBranch>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
                return new List<IBranch>();
            }
        }

        public static void Save(IList<IBranch> projetos)
        {
            JsonSerializerOptions configSerializer = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // UTF-8
                WriteIndented = true // Formata o JSON para legibilidade
            };
            string json = JsonSerializer.Serialize(projetos.OfType<BranchBase>().ToList(), configSerializer);
            File.WriteAllText("Projects.json", json, Encoding.UTF8);
        }
    }
}
