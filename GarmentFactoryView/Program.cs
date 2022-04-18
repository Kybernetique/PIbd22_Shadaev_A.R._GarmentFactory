using System;
using System.Windows.Forms;
using GarmentFactoryBusinessLogic.BusinessLogics;
using GarmentFactoryContracts.BusinessLogicsContracts;
using GarmentFactoryContracts.StoragesContracts;
<<<<<<< HEAD
using GarmentFactoryFileImplement.Implements;
using Unity;
using Unity.Lifetime;
=======
using GarmentFactoryDatabaseImplement.Implements;
using GarmentFactoryFileImplement;
>>>>>>> 2513276c292aa09cc28ebb7d673499f79fd57502

namespace GarmentFactoryView
{
    static class Program
    {
        private static IUnityContainer container = null;

        public static IUnityContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = BuildUnityContainer();
                }
                return container;
            }
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<ITextileStorage,
            TextileStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderStorage, OrderStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IGarmentStorage, GarmentStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IWarehouseStorage, WarehouseStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<ITextileLogic, TextileLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderLogic, OrderLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IGarmentLogic, GarmentLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IWarehouseLogic, WarehouseLogic>(new
               HierarchicalLifetimeManager());
            return currentContainer;
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<FormMain>());
        }
    }
}
