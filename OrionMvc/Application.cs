using System;
using System.Collections.Generic;
using OrionMvc.Web;

namespace OrionMvc
{
    public class Application
    {
        public Application()
        {
        }
        public IControllerFactory ControllerFactory
        {
            get;
            set;
        }

        public static Application Instance
        {
            get;
            set;
        }

        public IRouter Router
        {
            get;
            set;
        }

        public IView View
        {
            get;
            set;
        }


        public static Application GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Application();
                Instance.Initialize();
            }
            return Instance;
        }

      
        public virtual void Initialize()
        {
            ControllerFactory = new ControllerFactory();
            Router = new Router();
            View = new View();
        }
    }
}
