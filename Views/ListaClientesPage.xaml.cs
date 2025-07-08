using Microsoft.Maui.Controls;
using ExamenProgreso3_JulianTorres.ViewModels;

namespace ExamenProgreso3_JulianTorres.Views;

public partial class ListaClientesPage : ContentPage
{
    private ListaClientesViewModel vm;
    public ListaClientesPage()
	{
		InitializeComponent();
        vm = new ListaClientesViewModel();
        BindingContext = vm;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await vm.CargarClientesAsync();
    }
}