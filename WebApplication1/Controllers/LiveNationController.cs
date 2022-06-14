using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Data;
using WebApplication1.Models.Rules;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LiveNationController : ControllerBase
    {
        //    private static readonly string[] Summaries = new[]
        //    {
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

       



        private readonly ILogger<LiveNationController> _logger;

        public LiveNationController(ILogger<LiveNationController> logger)
        {
            _logger = logger;
        }

       

        [HttpGet("{x}/{y}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Output_Data_Model> Get(int x,int y)
        {
              List<Rule> LiveNation_Rules = new List<Rule>
        {
                    new Rule(
                rName:"LiveNation",
                rDescription:"If the input number is a multiple of 3 and 5 then output 'LiveNation'",
                rFunc:delegate(int x)
                {
                    if(x%3 == 0 && x%5 == 0)
                    {

                        return "LiveNation";
                    }

                        return x.ToString();

                }
                ),
            new Rule(
                rName:"Live",
                rDescription:"If the input number is a multiple of 3 then output 'Live'",
                rFunc: delegate(int x)
                {
                    if(x%3 == 0)
                    {
                        return "Live";
                    }
                    else
                    {
                        return x.ToString();
                    }
                }
                ),
            new Rule(
                rName:"Nation",
                rDescription:"If the input number is a multiple of 5 then output 'Nation'",
                rFunc:delegate(int x)
                {
                    if(x%5 == 0)
                    {
                        return "Nation";
                    }
                    else
                    {
                        return x.ToString();
                    }
                }
                ),
          



        };

        System.Diagnostics.Debug.WriteLine(LiveNation_Rules);
            var ruleArray = validate_rules(LiveNation_Rules);
            System.Diagnostics.Debug.WriteLine(ruleArray);
            var base_data = gen_base_Data(x,y, ruleArray);
            System.Diagnostics.Debug.WriteLine(base_data);
            var outstrings = run_rule_loop(base_data);

            var outputdata = new Output_Data_Model(LiveNation_Rules.Where(r => r.IsEnabled == true), outstrings);

            return outputdata;
        }

        private Rule[] validate_rules(List<Rule>rules) 
        {
            var tempRules = rules;
        foreach (var rule in tempRules)
            {
                System.Diagnostics.Debug.WriteLine(rule.ToString);
                if (rule._runRule != null)
                {
                    rule.IsEnabled = true;
                }
            }
        return tempRules.ToArray();
        }
        
        

        private string[] run_rule_loop(Base_Data_Model data )
        {
            string[] outputStrings = new string[data.base_Array.Length];
            for (int i=0; i < data.base_Array.Length ; i++)
            {
                
                foreach(var rule in data.rules)
                {
                    if ( data.rules.Any(drule => drule.Name == outputStrings[i])) {
                        break;
                    }
                    else {
                    
                    
                    System.Diagnostics.Debug.WriteLine(data.base_Array[i]);
                    outputStrings[i] = rule._runRule(data.base_Array[i]);
                    System.Diagnostics.Debug.WriteLine(outputStrings[i]);
                    rule.TriggerCount++;
                    }

                }
            }
            return outputStrings;
        }

        private Base_Data_Model gen_base_Data(int x, int y, Rule[] rules) 
        {

            return new Base_Data_Model( x, y, rules);


        }

    }
}