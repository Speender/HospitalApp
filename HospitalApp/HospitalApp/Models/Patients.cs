using System;
using System.Collections.Generic;

namespace HospitalApp.Models;

public class Patient
{   
    public int PatientID { get; set; }
    public string Name { get; set; }
    public DateTime Bday { get; set; }
    public int Age
            {
                get
                {
                    var today = DateTime.Today;
                    int age = today.Year - Bday.Year;
                    if (Bday.Date > today.AddYears(-age)) age--;
                    return age;
                }
            }    
    public string Sex { get; set; }
    public string Address { get; set; }
    public string BloodType { get; set; }
    public string Email { get; set; }
    public string ContactNumber { get; set; }

    public string BdayFormatted
    {
        get => Bday.ToString("yyyy-MM-dd");
    }
}

