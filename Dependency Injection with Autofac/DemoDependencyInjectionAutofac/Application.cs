using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDependencyInjectionAutofac
{
    public class Application : IApplication
    {
        private readonly IBusinessLogic _bussinessLogic;

        public Application(IBusinessLogic businessLogic)
        {
            _bussinessLogic = businessLogic;
        }

        public void Run()
        {
            _bussinessLogic.ProcessData();
        }
    }
}
