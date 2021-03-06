﻿using NoviInterviewMiniProject.Services;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace NoviInterviewMiniProject.Repositories
{
    public abstract class Repository<T>
    {

        public IGlobalSettings _globalSettings;

        /// <summary>
        /// Generic reset get request function
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public string GetRequest(string endpoint)
        {
            RestClient client = new RestClient(_globalSettings.ApiUrl + endpoint);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Basic " + _globalSettings.ApiKey);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Content;
            }

            return String.Empty;
        }

        public abstract T GetByID(string id);

        public abstract IEnumerable<T> GetAll();

        public abstract T Add(T entity);

        public abstract T Update(T entity);

        public abstract T Delete(T entity);
    }
}