using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS1
{
    public class SystemCall
    {
        public List<string> Arguments { get; private set; }

        public SystemCall(List<string> args)
        {
            this.Arguments = args;
        }

        public string Execute()
        {
            return "/n";
        }
    }
}
