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
            Bind<IPdfInserter>().To<PdfSharpPdfInserter>();
        }
    }
}
