using System;
using TaxCalculator.Models;
using RestSharp;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using RestSharp.Authenticators;

namespace TaxCalculator.Services
{
    public class TaxJarCalculator : ITaxCalculator
    {


        public decimal CalculateOrderTaxes(TaxOrderDTO order)
        {
            return 1;
        }

        public decimal GetTaxRateByLocation(string zipCode)
        {
        
            try
            {
                string baseUrl = "https://api.taxjar.com/v2/";
                string URL = baseUrl + "rates/" + zipCode;
                string apiKey = "5da2f821eee4035db4771edab942a4cc";

                RestClient client = new RestClient(URL);

                RestRequest restRequest = new RestRequest(Method.GET);
                restRequest.AddHeader("Accept", "application/json");

                client.Authenticator = new JwtAuthenticator(apiKey);

                var locationTaxRateResponse = client.Execute<LocationTaxRate>(restRequest);
                var jObject = JObject.Parse(locationTaxRateResponse.Content);

                if (jObject["rate"].HasValues)
                {
                    return Convert.ToDecimal(jObject["rate"]["combined_rate"]);
                }

                else
                {
                    return 0;
                }


            }
            catch (Exception e)
            {
                //Log Exception
            }

            return 0;
         
        }
    }
}
