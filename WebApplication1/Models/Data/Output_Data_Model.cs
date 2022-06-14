using System.Text.Json;
using System.Text.Json.Serialization;
using WebApplication1.Models.Rules;

namespace WebApplication1.Models.Data
{
    public class Output_Data_Model
    {

        public string Results { get; set; }
        public Dictionary<String, int> Summary { get; set; }




        public Output_Data_Model(IEnumerable<Rule> rules, IEnumerable<string>outputstrings)
        {
            Results = "";
            Summary = new Dictionary<string, int>();


            var temp = outputstrings.Count();
            foreach (var output in outputstrings)
            {
                
                    Results = Results + output + " ";
                
                
            }

            Results = Results.Trim();
            
            foreach (var rule in rules)
            {
                Summary.Add(rule.Name, outputstrings.Where(s => s == rule.Name).Count());
                
            }
            Summary.Add("Integer", outputstrings.Count() - Summary.Sum(s => s.Value));


        }


    }
}
