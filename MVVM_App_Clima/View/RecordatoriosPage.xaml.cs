using MVVM_App_Clima.ViewModel;

namespace MVVM_App_Clima.View;

public partial class RecordatoriosPage : ContentPage
{
    private RecordatoriosViewModel viewModel;

    public RecordatoriosPage()
    {
        InitializeComponent();
        viewModel = new RecordatoriosViewModel();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.Cargar();
    }
}
