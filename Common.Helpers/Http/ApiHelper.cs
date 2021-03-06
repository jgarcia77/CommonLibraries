﻿namespace Common.Helpers.Http
{
    using Common.Helpers.Serialization;
    using Common.Objects.Routing;
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    
    /// <summary>
    /// Exposes RESTful calls
    /// </summary>
    public class ApiHelper
    {
        protected string ApiBaseUrl { get; set; }
        protected string ApiResource { get; set; }

        private HttpClient client;

        public ApiHelper(string apiBaseUrl)
        {
            this.ApiBaseUrl = apiBaseUrl;
            client = new HttpClient { BaseAddress = new Uri(ApiBaseUrl) };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public void AddHeader(string name, string value)
        {
            if (client.DefaultRequestHeaders.Contains(name))
            {
                client.DefaultRequestHeaders.Remove(name);
            }

            client.DefaultRequestHeaders.Add(name, value);
        }

        public T Post<T, R>(string resource, R request)
        {
            var response = client.PostAsJsonAsync<R>(resource, request).Result;

            var json = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                var data = JsonHelper.Deserialize<T>(json);
                return data;
            }
            else
            {
                var data = JsonHelper.Deserialize<ResponseData>(json);

                if (data != null &&
                    !data.IsSuccessful)
                {
                    var ex = new ApplicationException(data.StatusMessage);
                    throw ex;
                }
            }

            throw new ApplicationException(string.Format("Post request did not complete: {0}", resource));
        }

        public T Get<T>(string resource)
        {
            var response = client.GetAsync(resource).Result;

            var json = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                var data = JsonHelper.Deserialize<T>(json);
                return data;
            }
            else
            {
                var data = JsonHelper.Deserialize<ResponseData>(json);

                if (data != null &&
                    !data.IsSuccessful)
                {
                    var ex = new ApplicationException(data.StatusMessage);
                    throw ex;
                }
            }

            throw new ApplicationException(string.Format("Get request did not complete: {0}", resource));
        }

        public T Put<T, R>(string resource, R request)
        {
            var response = client.PutAsJsonAsync<R>(resource, request).Result;

            var json = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                var data = JsonHelper.Deserialize<T>(json);
                return data;
            }
            else
            {
                var data = JsonHelper.Deserialize<ResponseData>(json);

                if (data != null &&
                    !data.IsSuccessful)
                {
                    var ex = new ApplicationException(data.StatusMessage);
                    throw ex;
                }
            }

            throw new ApplicationException(string.Format("Put request did not complete: {0}", resource));
        }
    }
}