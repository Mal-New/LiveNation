using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Rules
{
     interface IRule
    {
        [Required(ErrorMessage = "Name is required.")]
         string Name { get;  }

         string Description { get; }
         bool IsEnabled { get; set; }
        int TriggerCount { get; set; }

        //public abstract string Run(int x);

        //Func<int,string> RunRule();

        //[Required(ErrorMessage = "RuleAction is required.")]
        //Action<int> RuleAction { get; }
        ////delegate string TAction(int x);
    }
}
