using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst.DAO
{
    public class DaoFactory
    {

        public IDAO GetDaoManager(MODEL.BusinessDBContext context)
        {
            return new DaoManager(context);
        }

    }
}
