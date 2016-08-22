using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderSysClient.Reports.crystal_models
{
    public class ProformaInvoiceReportModel
    {
        public int company_id { get; set; }
        public int company_code { get; set; } 
        public int customer_id { get; set; }
        public string customer_name { get; set; }
        public string customer_address { get; set; }
        public string company_name { get; set; }
              
        public int product_id { get; set; }
        public int label_reference_id { get; set; }
        //public string label_reference_name { get; set; }
        public string product_name { get; set; }               
        public decimal quantity { get; set; }        
        public string uom_name { get; set; }
        public decimal sales_price { get; set; }      
        public decimal line_total { get; set; }
        public string currency { get; set; }        
        public string bank_name { get; set; }
        public string swift_code { get; set; }
        public string proforma_invoice_no { get; set; }
        public string proforma_inoice_date { get; set; }
        public string proforma_inoice_code { get; set; }
        public decimal unit_price { get; set; }


    }
}