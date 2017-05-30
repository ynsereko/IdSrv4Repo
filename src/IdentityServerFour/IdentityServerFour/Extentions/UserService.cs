using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
//using WcfProxies.SecurityProxy;
using System.Runtime.Serialization;
using IdentityServerFour.Models;
using System.Dynamic;
using Newtonsoft.Json.Serialization;

namespace IdentityServerFour.Extentions
{
    public class UserService : IUserService
    {
        public async Task<HttpResponseMessage> CheckPasswordAsync(string userName, string password)
        {
            var result = new HttpResponseMessage();

            try
            {
                /*implement logic to validate*/
                var loginRequest = CreateRequest();
                loginRequest.password = password;
                loginRequest.username = userName;
                //var response = PostDataNonAsyc(loginRequest);
                var response = await PostDataAsyc(loginRequest);
                response.EnsureSuccessStatusCode();
                return response;
            }
            catch (Exception ex)
            {
                
                //result.StatusCode = System.Net.HttpStatusCode.BadRequest;
                
            }


            return result;
        }

        public Task<List<Claim>> GetClaimsAsync(string userName)
        {
            //Database call to get calims if needed
            var calims = new List<Claim>
            {
                new Claim("accountnumber", "12345")
            };
            return Task.FromResult(calims);
        }

        private LoginRequestInfo CreateRequest()
        {
           
            var clientInfo = new UserClientSystemInfo
            {
                

                UserAgent = @"Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.96 Safari/537.36",
                Platform = "Windows 7",
                IPAddress = "::1",
                BrowserFamily = "Chrome",
                BrowserType = "Browser",
                BrowserVersion = "58.0.3029.96",
                ServerName = "DEV-VDI-P-079",
                TimeZone = decimal.Parse("-5"),
                UniqueId = "6396F375-0F73-4A5A-AF10-E78A0AD884A9"
            };
            return new LoginRequestInfo()
            {
                username = "",
                password = "",
                source = "OLBWEB",
                clientSessionId = "6396F375-0F73-4A5A-AF10-E78A0AD884A9",
                userSystemInfo = clientInfo



            };
        }

        private ExpandoObject CreateRequest2()
        {

            dynamic LoginRequestInfo = new ExpandoObject();
            
           
            dynamic clientInfo = new ExpandoObject();
            clientInfo.UserAgent = @"Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.96 Safari/537.36";
            clientInfo.Platform = "Windows 7";
            clientInfo.IPAddress = "::1";
            clientInfo.BrowserFamily = "Chrome";
            clientInfo.BrowserType = "Browser";
            clientInfo.BrowserVersion = "58.0.3029.96";
            clientInfo.ServerName = "DEV-VDI-P-079";
            clientInfo.TimeZone = decimal.Parse("-5");
            clientInfo.UniqueId = "6396F375-0F73-4A5A-AF10-E78A0AD884A9";

            LoginRequestInfo.username = string.Empty;
            LoginRequestInfo.password = string.Empty;
            LoginRequestInfo.source = "OLBWEB";
            LoginRequestInfo.clientSessionId = "6396F375-0F73-4A5A-AF10-E78A0AD884A9";
            LoginRequestInfo.clientinfo = clientInfo;


            return LoginRequestInfo;




            }


            /// <summary>
            /// 
            /// </summary>
            /// <param name="request"></param>
            /// <returns></returns>
            private static async Task<HttpResponseMessage> PostDataAsyc( LoginRequestInfo request)
        {
            var result = new HttpResponseMessage();
            const string mimeType = "application/json";
            const string baseAddress = @"http://gdedev13.gdeacu.com/F3/MemberHostService/api";
            //const string url = @"http://gdedev13.gdeacu.com/F3/MemberHostService/api/security/ValidateLogin";
            //const string url = @"http://localhost/int/Alliant.BSL.MemberHostService/api/security/ValidateLogin";
            //const string url = @"http://localhost/digitalbanking.api/user/login";
            const string url = @"http://localhost/INT/Alliant.BSL.MemberHostService/api/security/ValidateLogin";

            try
            {
               
                HttpClientHandler httpClientHandler = new HttpClientHandler {   AllowAutoRedirect = true };
                using (var client = new HttpClient(httpClientHandler, true))
                {

                    //client.BaseAddress = new Uri(baseAddress);
                    var uri = new Uri(url, UriKind.Absolute);
                    client.DefaultRequestHeaders.Clear();
                    //client.DefaultRequestHeaders.ExpectContinue = false;
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mimeType));//ACCEPT header
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", mimeType);

                    var jsonSettings = new JsonSerializerSettings();
                    jsonSettings.NullValueHandling = NullValueHandling.Ignore;
                    jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    var jsonRequest = JsonConvert.SerializeObject(request,jsonSettings);

                    var content = new StringContent(jsonRequest, Encoding.UTF8, mimeType);

                    //byte[] jsonRequestBytes = System.Text.Encoding.UTF8.GetBytes(jsonRequest);
                    //var content = new ByteArrayContent(jsonRequestBytes);
                    //content.Headers.ContentType = new MediaTypeHeaderValue(mimeType);

                    //await client.PostAsJsonAsync(url, request).ContinueWith(
                    //     postTask =>
                    //     {
                    //         if (postTask.IsCanceled)
                    //         {
                    //             var can = postTask.Exception;
                    //.
                    //         }
                    //         else if (postTask.IsFaulted)
                    //         {
                    //             var fal = postTask.Exception;
                    //         }
                    //         else
                    //         {
                    //             result = postTask.Result;
                    //         }
                    //     });

                    await client.PostAsync(uri, content).ContinueWith(
                        postTask =>
                        {
                            if (postTask.IsCanceled)
                            {
                                var can = postTask.Exception;

                            }
                            else if (postTask.IsFaulted)
                            {
                                var fal = postTask.Exception;
                            }
                            else
                            {
                                result = postTask.Result;
                            }
                        });

                }

            }
            catch(Exception ex)
            {
                result = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }

           
            return result;
          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        private static HttpResponseMessage PostDataNonAsyc(LoginRequestInfo userRequest)
        {
            const string url = @"http://gdedev13.gdeacu.com/F3/MemberHostService/api/security/ValidateLogin";
            //const string url = @"http://localhost/int/Alliant.BSL.MemberHostService/api/security/ValidateLogin";
            //const string url = @"http://localhost/digitalbanking.api/user/login";

            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonRequest = JsonConvert.SerializeObject(userRequest);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");

                var response = client.PostAsync(new Uri(url), content).Result;
                if (!response.IsSuccessStatusCode) return new HttpResponseMessage();
                //response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return response;
            }
        }

        //public async Task<HttpResponseMessage> PutAsyncGeneric<T>(T data)
        //{
        //    using (var httpClient = new HttpClient())
        //    {
        //        var mediaType = new MediaTypeHeaderValue("application/json");
        //        var jsonSerializerSettings = new JsonSerializerSettings();
        //        var jsonFormatter = new  JsonNetFormatter(jsonSerializerSettings);

        //        var requestMessage = new HttpRequestMessage<T>(data, mediaType, new MediaTypeFormatter[] { jsonFormatter });

        //        var result = await httpClient.PostAsync(_endpoint, requestMessage.Content).Result;

        //        await return result.Content.ReadAsStringAsync().Result;
        //    }
        //}


        public Task<bool> CheckPasswordAsync2(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
