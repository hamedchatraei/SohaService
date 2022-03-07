using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using SohaService.Core.Services.Interfaces;
using SohaService.DataLayer.Entities.ApiKey;

namespace SohaService.Core.Senders
{
    //public static class SendSMS
    //{
    //    public static void SendForOrder(string mobile,string customer,string unitName,string estimatedDate,string userName)
    //    {
    //        var client = new RestClient("http://188.0.240.110/api/select");
    //        var request = new RestRequest(Method.POST);
    //        request.AddHeader("cache-control", "no-cache");
    //        request.AddHeader("Content-Type", "application/json");
    //        request.AddParameter("undefined", "{\"op\" : \"pattern\"" +
    //                                          ",\"user\" : \"09211497166\"" +
    //                                          ",\"pass\":  \"@novinADS10\"" +
    //                                          ",\"fromNum\" : \"+9810006600600600\"" +
    //                                          $",\"toNum\": \"{mobile}\"" +
    //                                          ",\"patternCode\": \"3sgwy2n0cm\"" +
    //                                          $",\"inputData\" : [{{\"product\": \"{unitName}\"  , \"user\": \"{userName}\"}}]}}"
    //            , ParameterType.RequestBody);
    //        IRestResponse response = client.Execute(request);
    //    }

    //    public static void SendForRepair(string mobile, string customer, string unitName, string userName)
    //    {
    //        var client = new RestClient("http://188.0.240.110/api/select");
    //        var request = new RestRequest(Method.POST);
    //        request.AddHeader("cache-control", "no-cache");
    //        request.AddHeader("Content-Type", "application/json");
    //        request.AddParameter("undefined", "{\"op\" : \"pattern\"" +
    //                                          ",\"user\" : \"09211497166\"" +
    //                                          ",\"pass\":  \"@novinADS10\"" +
    //                                          ",\"fromNum\" : \"+9810006600600600\"" +
    //                                          $",\"toNum\": \"{mobile}\"" +
    //                                          ",\"patternCode\": \"ypjexdlewr\"" +
    //                                          $",\"inputData\" : [{{\"name\": \"{customer}\" , \"product\": \"{unitName}\"   , \"user\": \"{userName}\"}}]}}"
    //            , ParameterType.RequestBody);
    //        IRestResponse response = client.Execute(request);
    //    }
    //}
    public class TokenResultObject
    {
        public string TokenKey { get; set; }

        public bool IsSuccessful { get; set; }

        public string Message { get; set; }
    }

    public class TokenRequestObject
    {
        public string UserApiKey { get; set; }

        public string SecretKey { get; set; }
    }

    internal enum EnumHttpMethod
    {
        Post,
        Get,
        Put,
    }

    internal class HttpObject
    {
        public string Url { get; set; }

        public EnumHttpMethod Method { get; set; }

        public string Json { get; set; }
    }

    internal interface IHttpRequest
    {
        string SendRequest(HttpObject httpObject, IDictionary<string, string> parameters);
    }

    internal static class Serializer
    {
        public static string Serialize<T>(this T obj)
        {
            DataContractJsonSerializer contractJsonSerializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream memoryStream1 = new MemoryStream();
            MemoryStream memoryStream2 = memoryStream1;
            //// ISSUE: variable of a boxed type
            //__Boxed<T> local = (object)obj;
            contractJsonSerializer.WriteObject((Stream)memoryStream2, (object)obj);
            return Encoding.UTF8.GetString(memoryStream1.ToArray());
        }

        public static T Deserialize<T>(this string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return default(T);
            T instance = Activator.CreateInstance<T>();
            MemoryStream memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(json));
            T obj = (T)new DataContractJsonSerializer(instance.GetType()).ReadObject((Stream)memoryStream);
            memoryStream.Close();
            return obj;
        }
    }

    internal sealed class UrlProvider
    {
        private static string _baseUrl;

        public static string BaseUrl
        {
            get
            {
                if (string.IsNullOrWhiteSpace(UrlProvider._baseUrl))
                    UrlProvider._baseUrl = UrlProvider.GetBaseUrl();
                return UrlProvider._baseUrl;
            }
        }

        private static string GetBaseUrl()
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://ip.sms.ir/api/config/1");
            httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
            using (HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader streamReader = new StreamReader(responseStream))
                        return streamReader.ReadToEnd().Replace('"', ' ').Trim();
                }
            }
        }
    }

    internal class HttpPostRequest : IHttpRequest
    {
        public string SendRequest(HttpObject httpObject, IDictionary<string, string> parameters)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(httpObject.Url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = EnumHttpMethod.Post.ToString();
            if (parameters != null)
            {
                foreach (KeyValuePair<string, string> parameter in (IEnumerable<KeyValuePair<string, string>>)parameters)
                    httpWebRequest.Headers.Add(parameter.Key, parameter.Value);
            }
            using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(httpObject.Json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                using (StreamReader streamReader = new StreamReader(httpWebRequest.GetResponse().GetResponseStream()))
                    return streamReader.ReadToEnd();
            }
            catch (WebException ex)
            {
                using (StreamReader streamReader = new StreamReader(ex.Response.GetResponseStream()))
                    return streamReader.ReadToEnd();
            }
        }
    }

    internal static class HttpRequestExtensions
    {
        public static string Execute(
            this IHttpRequest client,
            HttpObject httpObject,
            IDictionary<string, string> parameters)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            return client.SendRequest(httpObject, parameters);
        }
    }

    public class Token
    {
        private static readonly Lazy<IHttpRequest> CachedClient = new Lazy<IHttpRequest>((Func<IHttpRequest>)(() => (IHttpRequest)new HttpPostRequest()));
        private static readonly Func<IHttpRequest> DefaultFactory = (Func<IHttpRequest>)(() => Token.CachedClient.Value);
        private static Func<IHttpRequest> _httpClientFactory;
        private static readonly object HttpRequestFactoryLock = new object();

        internal static Func<IHttpRequest> HttpRequestFactory
        {
            get
            {
                lock (Token.HttpRequestFactoryLock)
                    return Token._httpClientFactory ?? Token.DefaultFactory;
            }
            set
            {
                lock (Token.HttpRequestFactoryLock)
                    Token._httpClientFactory = value;
            }
        }

        public string GetToken(string userApiKey, string secretKey)
        {
            try
            {
                string str1 = new TokenRequestObject()
                {
                    UserApiKey = userApiKey,
                    SecretKey = secretKey
                }.Serialize<TokenRequestObject>();
                string str2 = UrlProvider.BaseUrl + "/api/Token";
                TokenResultObject tokenResultObject = Token.HttpRequestFactory().Execute(new HttpObject()
                {
                    Url = str2,
                    Json = str1
                }, (IDictionary<string, string>)null).Deserialize<TokenResultObject>();
                if (tokenResultObject != null)
                {
                    if (tokenResultObject.IsSuccessful)
                        return tokenResultObject.TokenKey;
                }
            }
            catch (Exception ex)
            {
                return (string)null;
            }
            return (string)null;
        }
    }

    public class SentSMSLog2
    {
        public long ID { get; set; }

        public string MobileNo { get; set; }
    }

    public class BaseResponseApiModel
    {
        public bool IsSuccessful { get; set; }

        public string Message { get; set; }
    }

    public class MessageSendResponseObject : BaseResponseApiModel
    {
        public SentSMSLog2[] Ids { get; set; }

        public string BatchKey { get; set; }
    }

    public class MessageSendObject
    {
        public string[] Messages { get; set; }

        public string[] MobileNumbers { get; set; }

        public string LineNumber { get; set; }

        public DateTime? SendDateTime { get; set; }

        public bool? CanContinueInCaseOfError { get; set; }
    }

    public class MessageSend
    {
        private static Lazy<IHttpRequest> CachedClient = new Lazy<IHttpRequest>((Func<IHttpRequest>)(() => (IHttpRequest)new HttpPostRequest()));
        private static Func<IHttpRequest> DefaultFactory = (Func<IHttpRequest>)(() => MessageSend.CachedClient.Value);
        private static Func<IHttpRequest> _httpClientFactory;
        private static object HttpRequestFactoryLock = new object();

        internal static Func<IHttpRequest> HttpRequestFactory
        {
            get
            {
                lock (MessageSend.HttpRequestFactoryLock)
                    return MessageSend._httpClientFactory ?? MessageSend.DefaultFactory;
            }
            set
            {
                lock (MessageSend.HttpRequestFactoryLock)
                    MessageSend._httpClientFactory = value;
            }
        }

        public MessageSendResponseObject Send(
          string tokenKey,
          MessageSendObject model)
        {
            try
            {
                string str1 = model.Serialize<MessageSendObject>();
                string str2 = UrlProvider.BaseUrl + "/api/MessageSend";
                Dictionary<string, string> dictionary1 = new Dictionary<string, string>();
                dictionary1.Add("x-sms-ir-secure-token", tokenKey);
                MessageSend.HttpRequestFactory = (Func<IHttpRequest>)(() => (IHttpRequest)new HttpPostRequest());
                IHttpRequest client = MessageSend.HttpRequestFactory();
                HttpObject httpObject = new HttpObject();
                httpObject.Url = str2;
                httpObject.Json = str1;
                Dictionary<string, string> dictionary2 = dictionary1;
                return client.Execute(httpObject, (IDictionary<string, string>)dictionary2).Deserialize<MessageSendResponseObject>() ?? (MessageSendResponseObject)null;
            }
            catch (Exception ex)
            {
                return (MessageSendResponseObject)null;
            }
        }
    }



    public class SendSMS
    {
        public void SendForOrder(string customerMobile,string unit,string userName, string userApiKey,string secretKey)
        {
            Token tokenInstance = new Token();
            var token = tokenInstance.GetToken(userApiKey, secretKey);

            string message = $"همراه گرامی\nدرخواست خدمات شما برای {unit} با موفقیت ثبت گردید\nکارشناسان ما ظرف 48 ساعت آینده با شما تماس خواهند گرفت ، لطفا با در نظر گرفتن خدمات یا خرابی مورد نظر ، همکاران ما را تا رسیدن به راه حل نهایی راهنمایی فرمایید .\nکارشناس خدمات : {userName}\nشرکت صنایع الکترونیک سها\nsohaeshop.com";

            MessageSend messageInstance = new MessageSend();
            var res = messageInstance.Send(token, new MessageSendObject()
            {
                Messages = new List<string>() {message}.ToArray(),
                MobileNumbers = new List<string>() { $"{customerMobile}" }.ToArray(),
                LineNumber = "30004905",
                SendDateTime = null,
                CanContinueInCaseOfError = false
            });
        }

        public void SendForRepair(string customerMobile,string customerName,string unit, string userName,string userApiKey,string secretKey)
        {
            Token tokenInstance = new Token();
            var token = tokenInstance.GetToken(userApiKey, secretKey);

            string message = $"جناب آقای/سرکار خانم {customerName} گرامی\nدرخواست تعمیرات شما برای {unit} با موفقیت ثبت گردید.\nکارشناس ثبت تعمیرات : {userName}\nمجموعه شرکت های صنایع الکترونیک سها\nsohaeshop.com";

            MessageSend messageInstance = new MessageSend();
            var res = messageInstance.Send(token, new MessageSendObject()
            {
                Messages = new List<string>() { message }.ToArray(),
                MobileNumbers = new List<string>() { $"{customerMobile}" }.ToArray(),
                LineNumber = "30004905",
                SendDateTime = null,
                CanContinueInCaseOfError = false
            });
        }

        public void SendForAcceptRepair(string customerMobile, string customerName, string unit, string userName, string userApiKey, string secretKey)
        {
            Token tokenInstance = new Token();
            var token = tokenInstance.GetToken(userApiKey, secretKey);

            string message = $"جناب آقای/سرکار خانم {customerName} گرامی\nاحتراماً به اطلاع می رساند کالای شما هم اکنون تعمیر شده و آماده تحویل می باشد .\nکنترل کیفی : {userName}\nمجموعه شرکت های صنایع الکترونیک سها\nsohaeshop.com";

            MessageSend messageInstance = new MessageSend();
            var res = messageInstance.Send(token, new MessageSendObject()
            {
                Messages = new List<string>() { message }.ToArray(),
                MobileNumbers = new List<string>() { $"{customerMobile}" }.ToArray(),
                LineNumber = "30004905",
                SendDateTime = null,
                CanContinueInCaseOfError = false
            });
        }

        public void SendForSurvey(string customerMobile, string userApiKey, string secretKey)
        {
            Token tokenInstance = new Token();
            var token = tokenInstance.GetToken(userApiKey, secretKey);

            string message = $"همراه گرامی\nاز اینکه سُها را برای خدمات خود انتخاب نموده اید سپاس گزاریم.\nبه جهت بهبود تجربه کاربری استفاده از محصولات و کیفیت خدمات، لطفا میزان رضایتمندی خود را با ارسال اعداد بین 1 تا 5 اعلام نمایید.\n\nعدد 5 : بیشترین میزان رضایت\nعدد 1 : کمترین میزان رضایت \n\nبا احترام - واحد رضایت سنجی مجموعه شرکت های صنایع الکترونیک سها\nsohaeshop.com";

            MessageSend messageInstance = new MessageSend();
            var res = messageInstance.Send(token, new MessageSendObject()
            {
                Messages = new List<string>() { message }.ToArray(),
                MobileNumbers = new List<string>() { $"{customerMobile}" }.ToArray(),
                LineNumber = "30004905",
                SendDateTime = null,
                CanContinueInCaseOfError = false
            });
        }
    }
}
