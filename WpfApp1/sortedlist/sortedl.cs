using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    class Sortedl
    {
        public IList<string> lis=new List<string>() { };
        public  Sortedl()
        {
        }
        public Sortedl Adds(string t)
        {
            lis.Add(t);

            IList<string> tem =new List<string>();
            IList<string> ten = lis;
            if (lis.Count < 1) {  return this;
            }
            int[] d = new int[ten.Count];
            Find:

           while ( ten.Count>0){
                int min = (int)Convert.ToChar(ten[0][0]);
                int z = 0;
                for (int i = 1; i < ten.Count; i++) {
                d[i] = (int)Convert.ToChar(ten[i][0]);
                if (min > d[i]) { min = d[i]; z = i; }
                }
                tem.Add(lis[z]);ten.RemoveAt(z);goto Find;
            }
            lis = tem;
            return this;
        }
        
    }
}
