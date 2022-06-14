using WebApplication1.Models.Rules;

namespace WebApplication1.Models.Data
{
    public class Base_Data_Model

    {
        private int x;

        private int y;

        public int[] base_Array;

        public Rule[] rules;



        public Base_Data_Model(int x, int y, Rule[] rules)
        {
            this.x = x;
            this.y = y;
            base_Array = Enumerable.Range(x, y).ToArray();
            this.rules = rules;
        }
    }
}