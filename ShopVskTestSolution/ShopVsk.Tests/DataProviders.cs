using ShopVsk.Framework.Models;
using System;
using System.Collections;

namespace ShopVsk.Tests
{
    public class DataProviders
    {
        public static IEnumerable InsurancePolicyData
        {
            get
            {
                yield return new InsurancePolicy()
                {
                    Country = "Египет",
                    StartDate = DateTime.Now.AddDays(5).ToString("dd-MM-yyyy"),
                    EndDate = DateTime.Now.AddDays(15).ToString("dd-MM-yyyy")
                };
            }
        }
    }
}