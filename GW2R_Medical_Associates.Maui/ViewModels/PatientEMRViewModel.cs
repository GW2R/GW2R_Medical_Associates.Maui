using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GW2R_Medical_Associates.Maui.EMR_Management;
using GW2R_Medical_Associates.Maui.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GW2R_Medical_Associates.Maui.ViewModels
{
    public partial class PatientEMRViewModel : BaseViewModel
    {
        public ObservableCollection<EMR> EMRs { get; private set; } = new();
        public int DOB { get; private set; }
        public double TelephoneNo { get; private set; }

        public PatientEMRViewModel()
        {
            Title = "EMR List";
            GetEMRList().Wait();
        }

        [ObservableProperty]
        bool isRefreshing;
        [ObservableProperty]
        string firstName;
        [ObservableProperty]
        string lastName;
        [ObservableProperty]
        int dob;
        [ObservableProperty]
        double telephoneNo;
        [ObservableProperty]
        string nextOfKin;
        [ObservableProperty]
        string address;
        [ObservableProperty]
        string medicalHistory;
        [ObservableProperty]
        string prescriptions;
        [ObservableProperty]
        string testResults;


        [RelayCommand]
        async Task GetEMRList()
        {
            if (IsLoading) return;
            try
            {
                IsLoading = true;
                if (EMRs.Any()) EMRs.Clear();

                var emrs = App.PatientsEMR.GetEMRs();

                foreach (var emr in emrs) EMRs.Add(emr);
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Unable to get emrs: {ex.Message}");
                await Shell.Current.DisplayAlert("Error", "Failed to retireve data.", "Ok");
            }
        }
        
        [RelayCommand]
        async Task GetEMRDetails(int id)
        {
            if (id == 0) return;

            await Shell.Current.GoToAsync($"{nameof(EMRDetailsPage)}?Id={id}", true);
        }
           
        [RelayCommand]
        async Task AddEMR()
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(DOB) || double.IsNullOrEmpty(TelephoneNo) ||
                string.IsNullOrEmpty(NextOfKin) || string.IsNullOrEmpty(Address) || string.IsNullOrEmpty(MedicalHistory) || string.IsNullOrEmpty(Prescriptions) ||
                string.IsNullOrEmpty(TestResults))
            {
                await Shell.Current.DisplayAlert("Invalid Data", "Please insert valid data", "Ok");
                return;
            }
            var emr = new EMR
            {
                FirstName = FirstName,
                LastName = LastName,
                DOB = DOB,
                TelephoneNo = TelephoneNo,
                NextOfKin = NextOfKin,
                Address = Address,
                MedicalHistory = MedicalHistory,
                Prescripitons = Prescriptions,
                TestResults = TestResults
            };

            App.PatientsEMR.AddEMR(emr);
            await Shell.Current.DisplayAlert("Info", App.PatientsEMR.StatusMessage, "Ok");
            await GetEMRList();
        }

        [RelayCommand]
        async Task DeleteEMR(int id)
        {
            if (id==0)
            {
                await Shell.Current.DisplayAlert("Invalid Record", "Please try again", "Ok");
                return;
            }
            var result = App.PatientsEMR.DeleteEMR(id);
            if (result == 0) await Shell.Current.DisplayAlert("Data Invalid", "Please insert valid data", "Ok");
            else
            {
                await Shell.Current.DisplayAlert("Data Deleted", "Data Removed Successfully", "Ok");
                await GetEMRList();
            }
        }

        [RelayCommand]
        async Task GoToEMRDetails(EMR emr)
        {
            if (emr == null) return;

            await Shell.Current.GoToAsync(nameof(EMRDetailsPage), true, new Dictionary<string, object>
            {
                { nameof(EMR), emr }
            });
        }
        [RelayCommand]
        async Task UpdateEMR(int id)
        {
            if (id == 0) return;
            await Shell.Current.DisplayAlert("Please wait", "Updating", "Ok");
            return;
        }

    }
}
