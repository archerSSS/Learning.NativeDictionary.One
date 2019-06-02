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

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("wasd", null);
            string str;
            int i = dic.Count;
            foreach (KeyValuePair<string, string> kvp in dic)
            {
                str = kvp.Value;
            }


            //int i13 = nat.HashFun("f"); //8
        }
    }
}
