using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBP.Models
{
    public interface IPersonnelRepository
    {
        IEnumerable<Personnel> GetPersonnel();
        //Personnel Get(int id);
        //Personnel Add(Personnel person);
        //void Remove(int id);
        //bool Update(Personnel person);
    }
}
