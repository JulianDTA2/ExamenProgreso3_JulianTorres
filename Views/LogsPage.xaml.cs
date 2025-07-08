using Microsoft.Maui.Controls;
using ExamenProgreso3_JulianTorres.ViewModels;

namespace ExamenProgreso3_JulianTorres.Views;

public partial class LogsPage : ContentPage
{
    private LogsViewModel vm;
    public LogsPage()
	{
		InitializeComponent();
        vm = new LogsViewModel();
        BindingContext = vm;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        vm.CargarLogs();
    }
}