using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.EnvioCorreo
{
    class Program
    {
        static void Main(string[] args)
        {
            CorreoMarketing envio = new CorreoMarketing();
            envio.EnvioMarketing();
            envio.EnvioRecordatorios();
            Environment.Exit(0);
        }
    }
}
