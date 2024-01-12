using System.Text.RegularExpressions;

namespace FinalAssesment.Views;

public partial class QuestionTwo : ContentPage
{
    string pattern = @"^01[02-46-9][0-9]{7}$|^01[1][0-9]{8}$";

    public QuestionTwo()
	{
		InitializeComponent();
	}

    private void PhoneEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (Regex.IsMatch(PhoneEntry.Text, pattern))
        {
            InvalidPhone.IsVisible = false;
        }
        else
        {
            InvalidPhone.IsVisible = true;
        }
    }

    private void PasswordEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if(PasswordEntry.Text.Length > 5)
        {
            InvalidPassword.IsVisible = false;
        }
        else
        {
            InvalidPassword.IsVisible = true;
        }
    }

    private void TermsAndConditionsCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if(TermsAndConditionsCheckBox.IsChecked == true && Regex.IsMatch(PhoneEntry.Text, pattern) && PasswordEntry.Text.Length > 5)
        {
            RegisterButton.IsEnabled = true;
        }
        else
        {
            RegisterButton.IsEnabled = false;
        }
    }
}

