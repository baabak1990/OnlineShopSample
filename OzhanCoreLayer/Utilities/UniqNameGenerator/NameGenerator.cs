using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanCoreLayer.Utilities.UniqNameGenerator
{
    public static  class NameGenerator
    {
        public static string UniqName()
        {
            return Guid.NewGuid().ToString().Replace("_","");
        }
    }
}
