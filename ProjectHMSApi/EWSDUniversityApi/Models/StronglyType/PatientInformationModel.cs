using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.StronglyType
{
    public class PatientInformationModel{
        public patient Patient { get; set; }
        public patient_emergency_contact Emergency { get; set; } 
        public patient_health_info HealthInfos { get; set; } 
    }
}