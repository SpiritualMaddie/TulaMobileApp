namespace Tula
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(SupportNeedsChat), typeof(SupportNeedsChat));
        }
    }
}
