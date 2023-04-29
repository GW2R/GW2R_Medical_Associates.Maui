using GW2R_Medical_Associates.Maui.ViewModels;

namespace GW2R_Medical_Associates.Maui;

public partial class MainPage : ContentPage
{
    private readonly PatientEMRViewModel patientEMRViewModel;
    int count = 0;

	public MainPage(PatientEMRViewModel patientEMRViewModel)
	{
		InitializeComponent();
        BindingContext = patientEMRViewModel;
    }

}

