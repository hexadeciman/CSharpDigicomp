using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace TP11SysManagement
{
    class ServiceManager
    {
        ServiceController serviceController;

        public ServiceManager() {
        }

        public void start(string serviceName)
        {
            serviceController = new ServiceController(serviceName);
            TimeSpan timeout = TimeSpan.FromMilliseconds(1000);
            serviceController.Start();
            serviceController.WaitForStatus(ServiceControllerStatus.Running, timeout);
        }

        public void stop(string serviceName)
        {
            serviceController = new ServiceController(serviceName);
            TimeSpan timeout = TimeSpan.FromMilliseconds(1000);
            serviceController.Stop();
            serviceController.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
        }

        public void restart(string serviceName)
        {
            serviceController = new ServiceController(serviceName);
            int tickCount1 = Environment.TickCount;
            int tickCount2 = Environment.TickCount;
            TimeSpan timeout = TimeSpan.FromMilliseconds(1000);
            serviceController.Stop();
            serviceController.WaitForStatus(ServiceControllerStatus.Stopped, timeout);

            timeout = TimeSpan.FromMilliseconds(1000 - (tickCount1 - tickCount2));
            serviceController.Start();
            serviceController.WaitForStatus(ServiceControllerStatus.Running, timeout);
        }
    }
}
