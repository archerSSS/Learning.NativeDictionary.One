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
            
            Dictionary<int, int> dick = new Dictionary<int, int>();
            dick.Add(0, 12);
            dick.Add(1, 24);
            dick.Add(2, 36);
            int i;


            foreach (KeyValuePair<int, int> keyValue in dick)
            {
                i = keyValue.Value;
            }
            
            
        }
    }
}
