namespace MVVM_App_Clima
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell(); // Esto activa el Shell y muestra la barra
        }
    }
}