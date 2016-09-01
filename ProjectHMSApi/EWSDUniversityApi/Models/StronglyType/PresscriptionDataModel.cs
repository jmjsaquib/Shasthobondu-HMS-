using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.StronglyType
{
    public class PresscriptionDataModel:presscription
    {
        public List<presscription_medicine_mapping> med { get; set; }
        public List<presscription_drug_allergies_mapping> drug { get; set; }
        public List<presscription_test_type_mapping> test { get; set; }
        public List<presscription_health_condition_mapping> health { get; set; }
        public List<presscription_suggestion_mapping> Suggestion { get; set; }
        public List<presscription_complaints_mapping> complaints { get; set; }
        public string blood_pressure { get; set; }
        public Nullable<double> weight { get; set; }
    }
}