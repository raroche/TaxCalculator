using System;
using TaxCalculator.Models;
using RestSharp;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using RestSharp.Authenticators;
using Newtonsoft.Json;

namespace TaxCalculator.Services
{
    public class TaxJarCalculator : ITaxCalculator
    {
        private readonly string baseUrl = "https://api.taxjar.com/v2";
        private readonly string apiKey = "5da2f821eee4035db4771edab942a4cc";


        /// <summary>
        /// Calculate tax amount to be collected for an order
        /// </summary>
        /// <param name="order"></param>
        /// <returns> Return taxes amount to be collected</returns>
        public double CalculateOrderTaxes(TaxOrderDTO order)
        {

            try
            {
                string URL = baseUrl + "/taxes";

                RestClient client = new RestClient(URL);

                RestRequest restRequest = new RestRequest(Method.POST);

                restRequest.AddParameter("application/json", JsonConvert.SerializeObject(order) , ParameterType.RequestBody);

                client.Authenticator = new JwtAuthenticator(apiKey);

                IRestResponse restResponse = client.Execute(restRequest);

                var jResponse = JObject.Parse(restResponse.Content);

                if (jResponse["tax"].HasValues)
                {
                    return Convert.ToDouble(jResponse["tax"]["amount_to_collect"]);
                }

                else
                {
                    return -1;
                }

            }
            catch (Exception e)
            {
                // Log Exception
            }

            return -1;
        }


        /// <summary>
        /// Return tax rate base in a zipcode
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns> Returns combined_district_rate tax percentage </returns>
        public double GetTaxRateByLocation(string zipCode)
        {

            try
            {
        
                string URL = baseUrl + "/rates/" + zipCode;
               

                RestClient client = new RestClient(URL);

                RestRequest restRequest = new RestRequest(Method.GET);
                restRequest.AddHeader("Accept", "application/json");

                client.Authenticator = new JwtAuthenticator(apiKey);

                var locationTaxRateResponse = client.Execute<LocationTaxRate>(restRequest);

                var jResponse = JObject.Parse(locationTaxRateResponse.Content);

                if (jResponse["rate"].HasValues)
                {
                    return Convert.ToDouble(jResponse["rate"]["combined_rate"]);
                }

                else
                {
                    return -1;
                }


            }
            catch (Exception e)
            {
                //Log Exception
            }

            return -1;

        }
    }
}
