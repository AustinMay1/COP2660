using COP2660FinalExamAM.View;

namespace COP2660FinalExamAM
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("dataentrypage", typeof(DataEntryPage));
            Routing.RegisterRoute("inventoryitempage", typeof(InventoryPage));
        }
    }
}
