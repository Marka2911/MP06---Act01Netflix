using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02___Act01Netflix.DAO
{
    public class DAOFactoryNetflix
    {
        public IDAONetflix CrearNetflixDao()
        {
            return new IDAONetflixImpementation();
        }
    }
}
