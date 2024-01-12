namespace FinalAssesment.Views;

public partial class QuestionOne : ContentPage
{
	public QuestionOne()
	{
		InitializeComponent();
	}

    void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
    {
        int value = (int)args.NewValue;
        label2.Text = value.ToString();
        if (value <= 39)
        {
            label2.Text = "Failed";
            label2.TextColor = Color.FromArgb("#FF0000");
        }
        else if (value >= 40 && value <= 79)
        {
            label2.Text = "Passed";
            label2.TextColor = Color.FromArgb("#000000");
        }
        else if (value >= 80)
        {
            label2.Text = "Excellent";
            label2.TextColor = Color.FromArgb("#00FF00");
        }
        label1.Text = String.Format("{0}", value);
    }
}