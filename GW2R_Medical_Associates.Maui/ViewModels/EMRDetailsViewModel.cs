using CommunityToolkit.Mvvm.ComponentModel;
using GW2R_Medical_Associates.Maui.EMR_Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GW2R_Medical_Associates.Maui.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public partial class EMRDetailsViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        EMR emr;

        [ObservableProperty]
        int id;

        public void ApplyQueryAttributes(IDictionary<string, object> query) 
        {
            Id = Convert.ToInt32(HttpUtility.UrlDecode(query["Id"].ToString()));
            EMR = App.PatientsEMR.GetEMR(Id);
        }
    }
}
