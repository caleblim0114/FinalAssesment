using FinalAssesment.ViewModels;
using FinalAssesment.Views;

namespace FinalAssesment
{
    public partial class AppShell : Shell
    {
        public QuestionThreeViewModel QuestionThree { get; set; } = new();
        public AppShell()
        {
            InitializeComponent();
            var flyoutItem = new FlyoutItem()
            {
                Title = "Your App",
                Items =
                {
                    new Tab()
                    {
                        Items =
                        {
                            new ShellContent()
                            {
                                Content = new QuestionThree(QuestionThree), 
                                //Content = new QuestionTwo(), 
                            }
                        }
                    }
                }
            };

            CurrentItem = flyoutItem;
        }
    }
}