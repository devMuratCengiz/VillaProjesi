using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Business.Abstract;
using Villa.DataAccess.Abstract;
using Villa.Entity.Entities;

namespace Villa.Business.Concrete
{
    public class QAManager : GenericManager<QA>, IQAService
    {
        public QAManager(IGenericDal<QA> genericDal) : base(genericDal)
        {
        }
    }
}
