using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Covoiturage.Models.DAL
{
    public abstract class DALAbstract : IDisposable
    {
        protected BddContext bdd;
        public DALAbstract()
        {
            bdd = new BddContext();
        }

        ~DALAbstract()
        {
            Dispose();
        }

        public void Dispose()
        {
            bdd.Dispose();
        }
    }
}