using MDS.Models;
using RestSharp;
using RestSharp.Deserializers;
using System;

namespace MDS
{
    public class RestSharpClient
    {
        const string BaseUrl = "http://mds.kopnet.pl";

        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient(BaseUrl);
            client.AddHandler("*", new JsonDeserializer());

            var response = client.Execute<T>(request);
            
            if(response.ErrorException != null)
            {
               // to do error handling
            }

            return response.Data;
        }

        public EventsResponse GetEventsByCount(string userToken)
        {
            //var date1 = "2018-4-16";
            //var date2 = "2018-4-22";


            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new ApiToken(userToken));
            //request.AddParameter("fromDate", date1);
            //request.AddParameter("toDate", date2);
            request.AddHeader("Content-type", "application/json");

            request.Resource = "/getEvents";

            return Execute<EventsResponse>(request);
        }

        public EventsResponse GetEventsByDate(string userToken, Date date)
        {
            var request = new RestRequest(Method.POST);

            //to do

            return Execute<EventsResponse>(request);
        }

        public LoginResponse Login(User user)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/login";

            request.AddParameter("inputEmailPhone", user.Username);
            request.AddParameter("inputPassword", user.Password);

            return Execute <LoginResponse>(request);
        }
    }
}
