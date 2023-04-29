using System;
using GW2R_Medical_Associates.Maui.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Android.App;
using System.Runtime.Serialization;

namespace GW2R_Medical_Associates.Maui.EMR_Management
{
    public class PatientsEMR
    {
        SQLiteConnection conn;
        string _dbPath;
        public string StatusMessage;
        int result = 0;

        public PatientsEMR(string dbPath)
        {
            _dbPath = dbPath;
        }

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<EMR>();
        }
        public List<EMR> GetEMRs()
        {
            try
            {
                Init();
                return conn.Table<EMR>().ToList();
            }
            catch (Exception)
            {
                StatusMessage = "Failed to retrieve data";
            }
            return new List<EMR>();
        }
        public EMR GetEMR(int id)
        {
            try
            {
                Init();
                return conn.Table<EMR>().FirstOrDefault(q => q.Id == id);
            }
            catch (Exception)
            {
                StatusMessage = "Failed to retrieve data.";
            }
            return null;
        }
        public int DeleteEMR(int id)
        {
            try
            {
                Init();
                return conn.Table<EMR>().Delete(q => q.Id == id);
            }
            catch (Exception)
            {
                StatusMessage = "Failed to delete data.";
            }
            return 0;
        }
        public void AddEMR(EMR emr)
        {
            try
            {
                Init();

                if (emr == null)
                    throw new Exception("Invalid");

                result = conn.Insert(emr);
                StatusMessage = result == 0 ? "Failed Input" : "Successully Added";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to Insert data.";
            }
        }
        
    }
}
