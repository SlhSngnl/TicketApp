using TicketAppObilet.Models;

namespace TicketAppObilet
{
    public class SessionService
    {
        private readonly OBiletApiClient _apiClient;
        private static string _sessionId;
        private static string _deviceId;
        private readonly IHttpContextAccessor _contextAccessor;
        public SessionService(OBiletApiClient apiClient, IHttpContextAccessor contextAccessor)
        {
            _apiClient = apiClient;
            _contextAccessor = contextAccessor;
        }

        public void CreateSession()
        {
            
            if (_sessionId == null || _deviceId == null)
            {
                var sessionRequest = new SessionRequestModel
                {
                    Type = 1,
                    Connection = new ConnectionModel
                    {
                        IpAddress = GetMyIpAddress(),
                        Port = "443",
                        EquipmentId = "distribusion"
                    },
                    Browser = new BrowserModel
                    {
                        Name = GetMyBrowserName(),
                        Version = GetMyBrowserVersion()
                    }
                };

                var response =  _apiClient.GetSession(sessionRequest);

                if (response != null && response.Data != null)
                {
                    _sessionId = response.Data.SessionID;
                    _deviceId = response.Data.DeviceID;
                }
                else
                {
                    throw new Exception("Oturum oluşturulamadı: " + response.Message);
                }
            }
        }

        public string GetSessionId()
        {
            return _sessionId;
        }

        public string GetDeviceId()
        {
            return _deviceId;
        }

        private string GetMyBrowserName()
        {
            var userAgent = _contextAccessor.HttpContext.Request.Headers["User-Agent"].ToString();
            if (userAgent.Contains("Chrome"))
                return "Chrome";
            else if (userAgent.Contains("Firefox"))
                return "Firefox";
            else if (userAgent.Contains("Safari"))
                return "Safari";
            else
                return "Unknown";
        }

        private string GetMyBrowserVersion()
        {
            var userAgent = _contextAccessor.HttpContext.Request.Headers["User-Agent"].ToString();
            var browserName = GetMyBrowserName();
            var browserVersion = "Unknown";

            switch (browserName)
            {
                case "Chrome":
                    var chromeVersionIndex = userAgent.IndexOf("Chrome/") + 7;
                    browserVersion = userAgent.Substring(chromeVersionIndex).Split(' ')[0];
                    break;
                case "Firefox":
                    var firefoxVersionIndex = userAgent.IndexOf("Firefox/") + 8;
                    browserVersion = userAgent.Substring(firefoxVersionIndex).Split(' ')[0];
                    break;
                case "Safari":
                    var safariVersionIndex = userAgent.IndexOf("Safari/") + 7;
                    browserVersion = userAgent.Substring(safariVersionIndex).Split(' ')[0];
                    break;
            }

            return browserVersion;
        }

        public string GetMyIpAddress()
        {
            var ipAddress = _contextAccessor.HttpContext.Connection.RemoteIpAddress;

            if (ipAddress != null && ipAddress.IsIPv4MappedToIPv6)
            {
                ipAddress = ipAddress.MapToIPv4();
            }

            if (ipAddress == null || ipAddress.ToString() == "::1")
            {
                if (_contextAccessor.HttpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
                {
                    ipAddress = System.Net.IPAddress.Parse(_contextAccessor.HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault());
                }
            }

            return ipAddress?.ToString();
        }

    }
}
