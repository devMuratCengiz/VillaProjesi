using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.DataAccess.Abstract;
using Villa.DataAccess.Context;
using Villa.DataAccess.Repositories;
using Villa.Entity.Entities;

namespace Villa.DataAccess.EntitiyFramework
{
    public class EfQADal : GenericRepository<QA>, IQADal
    {
        public EfQADal(VillaContext context) : base(context)
        {
        }
    }
}
