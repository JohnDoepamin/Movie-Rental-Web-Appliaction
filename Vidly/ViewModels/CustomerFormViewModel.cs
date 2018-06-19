using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Migrations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MemberShipType> MemberShipTypes { get; set; }
        public Customer Customer { get; set; }

        public string Title
        {
            get { return (Customer.Id == 0) ? "New Customer" : "Edit Customer - " + Customer.Name; }
        }

        public bool IsNewCustomer
        {
            get { return (Customer.Id == 0) ? true : false; }
        }

    } 
    
}