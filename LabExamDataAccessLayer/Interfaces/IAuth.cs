using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExamDataAccessLayer.Interfaces
{
    public interface IAuth<CLASS>
    {
        CLASS Login(string username,string password);
    }
}
