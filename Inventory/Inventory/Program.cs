using System;
using System.Windows.Forms;

namespace Inventory
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new LoginForm());
            // Application.Run(new AddUserForm());
            // Application.Run(new Console());
            // Application.Run(new UsersForm());
            // Application.Run(new InventoryForm());
        }
    }
}
