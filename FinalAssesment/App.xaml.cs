using FinalAssesment.ViewModels;
using FinalAssesment.Views;

namespace FinalAssesment
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}