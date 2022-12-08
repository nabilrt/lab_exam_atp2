using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExamDataAccessLayer.Interfaces
{
    public interface IOperations<CLASS,Id,RET,STR>
    {
         List<CLASS> getALL();

        CLASS get(Id id);

        CLASS Add(CLASS cls);

        RET Update(CLASS cls);

        RET Delete(Id id);
       
    }
}
