using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanDomainLayer.Entities.Products.Common
{
    public enum CpuGeneration
    {
        Intel_Gen11th, Intel_Gen12th, Intel_Gen10th, Intel_Gen9th, Intel_Gen8th, Intel_Gen7th, Intel_Gen6th
    }

    public enum DirectAnswer
    {
        بله, خیر
    }

    public enum MotherboardFormat
    {
        Standard_ATX, Micro_Atx,
    }

    public enum Numbers
    {
        یک, دو, سه, چهار, پنج, شش, هفت, هشت, نه, ده, صفر
    }

    public enum RamGen
    {
        DDR4, DDR3, DDR5
    }
}
