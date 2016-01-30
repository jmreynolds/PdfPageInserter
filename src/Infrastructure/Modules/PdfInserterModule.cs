using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Ninject.Modules;
using Service;

namespace Infrastructure.Modules
{
    public class PdfInserterModule : NinjectModule
    {
        public PdfInserterModule()
        {
            
        }

        public override void Load()
        {
            Bind<IPdfInserter>().To<PdfInserter>();
        }
    }
}
