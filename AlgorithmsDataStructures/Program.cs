using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures
{
    public class Program
    {
        public static void Main(String[] args)
        {
            
            Dictionary<int, int> dic = new Dictionary<int, int>();
            dic.Add(0, 12);
            dic.Add(1, 24);
            dic.Add(2, 36);
            int i;


            foreach (KeyValuePair<int, int> keyValue in dic)
            {
                i = keyValue.Value;
            }
            
            
        }
    }
}
