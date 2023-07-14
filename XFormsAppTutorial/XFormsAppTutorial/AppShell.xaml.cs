using Xamarin.Forms;
using XFormsAppTutorial.Views;

namespace XFormsAppTutorial
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddCoffeePage), typeof(AddCoffeePage));
        }
    }
}
