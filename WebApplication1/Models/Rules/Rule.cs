namespace WebApplication1.Models.Rules
{
    public class Rule : IRule
    {

        private readonly string _name;
        private readonly string _description;
        private bool _isEnabled;
        private int _triggercount;
        public Func<int, string> _runRule;
        //public string _run(int x);
        //private Action<int> _runRule;


        public Rule(string rName,
                    string rDescription,
                    Func<int, string> rFunc
            //Action<int> rFunc
            )
        {
            _name = rName;
            _description = rDescription;
            _triggercount = 0;
            _isEnabled = false;

            _runRule = rFunc;

        }

        public  string Name 
        {
            get { return _name; }
           
            
        }

        public string Description
        {
            get { return _description; }

        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; }

        }
        
        public int TriggerCount { get => _triggercount; set => _triggercount = value; }


        //public abstract string run(int x); 

        //public Action<int> RuleAction { get => _runRule; }

       //public Func<int, string> IRule.RunRule() => _runRule;


        //public bool selfValidator()
        //{
        //    //null check
        //    foreach()
        //}

    }
}
