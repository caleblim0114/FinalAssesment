using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FinalAssesment.MobileApp.ViewModels;

public partial class BaseViewModel : ObservableObject, INotifyPropertyChanged
{

    [ObservableProperty]
    string _title;

    [ObservableProperty]
    bool _isBusy;
    [ObservableProperty]
    string _currentState = StateKey.None;

    [RelayCommand(AllowConcurrentExecutions = false)]
    async Task GoBack(string s)
    {
        await Shell.Current.GoToAsync("..");
    }

    protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
    {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return false;
        backingStore = value;
        onChanged?.Invoke();
        OnPropertyChanged(propertyName);
        return true;
    }
}

public class StateKey
{
    public const string Loading = "Loading";
    public const string Success = "Success";
    public const string Error = "Error";
    public const string None = "";
}