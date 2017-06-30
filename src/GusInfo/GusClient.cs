using GusInfo.Service;
using Newtonsoft.Json;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;

namespace GusInfo
{
    public class GusClient
    {
        private const string ProdUrl = @"https://wyszukiwarkaregon.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc";
        private const string TestUrl = @"https://wyszukiwarkaregontest.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc";
        private const string TestUserKey = "abcde12345abcde12345";

        private readonly string _userKey = TestUserKey;

        public GusClient()
        {
            Address = TestUrl;
        }
        public GusClient(string userKey)
        {
            _userKey = userKey;
            Address = ProdUrl;
        }

        public string Address { get; }

        public GusCompanyInfo GetCompanyByNip(string nip)
        {
            nip = NormalizeNip(nip);

            using (var client = new UslugaBIRzewnPublClient(
                new WSHttpBinding(SecurityMode.Transport) { MessageEncoding = WSMessageEncoding.Mtom },
                new EndpointAddress(Address)))
            using (var scope = new OperationContextScope(client.InnerChannel))
            {
                var sid = client.Zaloguj(_userKey);

                var props = new HttpRequestMessageProperty();
                props.Headers.Add("sid", sid);
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = props;

                var result = client.DaneSzukaj(new ParametryWyszukiwania() { Nip = nip });
                client.Wyloguj(sid);

                try
                {
                    var doc = new XmlDocument();
                    doc.LoadXml(result);
                    var json = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.None, true);
                    var response = JsonConvert.DeserializeObject<SearchDataResponse>(json);
                    if (response?.Data != null)
                    {
                        response.Data.Nip = nip;
                    }
                    return response?.Data;
                }
                catch { }
            }
            return null;
        }

        private static string NormalizeNip(string nip)
        {
            return nip;
        }
    }
}
