using FinalAssesment.ViewModels;

namespace FinalAssesment.Views;

public partial class QuestionThree : ContentPage
{
	public QuestionThree(QuestionThreeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}