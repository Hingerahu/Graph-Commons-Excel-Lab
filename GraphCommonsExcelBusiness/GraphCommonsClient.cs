using GraphCommonsExcelBusiness.Models.GraphCommons;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace GraphCommonsExcelBusiness
{
    public class GraphCommonsClient
    {
        private readonly string _apiKey = "sk_IRRd0vYYcBSG2MI-qGoBqw";
        private readonly string _baseUrl = "https://graphcommons.com/api/v1/";
        private readonly string _postGraphEndpoint = "graphs";

        public Graph PostGraph(GraphRequest graph)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest{Resource = _postGraphEndpoint};
            request.AddJsonBody(graph);
            request.AddHeader("Authentication", _apiKey);
            request.Method = Method.POST;
            var response = client.Execute(request);
            var graphResponse = JsonConvert.DeserializeObject<GraphResponse>(response.Content); 
            return graphResponse.graph;
        }
    }
}
