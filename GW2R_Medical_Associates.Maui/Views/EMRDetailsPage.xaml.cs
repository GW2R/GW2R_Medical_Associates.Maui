using GW2R_Medical_Associates.Maui.ViewModels;

namespace GW2R_Medical_Associates.Maui.Views;

public partial class EMRDetailsPage : ContentPage
{
	public EMRDetailsPage(EMRDetailsViewModel emrDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = emrDetailsViewModel;
	}
	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		// Do Stuff
		base.OnNavigatedTo(args);
	}
}