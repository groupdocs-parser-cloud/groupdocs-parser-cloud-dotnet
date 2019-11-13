using System;

namespace GroupDocs.Parser.Cloud.Sdk.Client
{
    /// <summary>
    /// Represents a set of configuration settings.
    /// </summary>
    public class Configuration
    {
        private string apiVersion = "/v1.0";
        private string apiBaseUrl = "https://api.groupdocs.cloud";

        /// <summary>
        /// Request timeout, default value is 100000 ms 
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration" /> class.
        /// </summary>
        /// <param name="appSid">Application identifier (App SID)</param>
        /// <param name="appKey">Application private key (App Key)</param>
        public Configuration(string appSid, string appKey)
        {
            if (string.IsNullOrEmpty(appSid))
            {
                throw new ArgumentNullException("appSid",
                    "Get your App SID and App Key at https://dashboard.groupdocs.cloud");
            }

            if (string.IsNullOrEmpty(appKey))
            {
                throw new ArgumentNullException("appKey",
                    "Get your App SID and App Key at https://dashboard.groupdocs.cloud");
            }

            this.AppSid = appSid;
            this.AppKey = appKey;
            this.Timeout = 100000;
        }

        /// <summary>
        /// API base URL, default value is https://api.groupdocs.cloud
        /// </summary>
        public string ApiBaseUrl
        {
            get
            {
                return this.apiBaseUrl;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.apiBaseUrl = value.TrimEnd('/');
                }

                this.apiBaseUrl = value;
            }
        }

        /// <summary>
        /// Application identifier (App SID)
        /// </summary>
        public string AppSid { get; set; }

        /// <summary>
        /// Application private key (App Key)
        /// </summary>
        public string AppKey { get; set; }

        /// <summary>
        /// Enables printing out additional information about each request
        /// </summary>
        public bool DebugMode { get; set; }

        /// <summary>
        /// Retrieves server URL e.g. https://api.groupdocs.cloud/v1.0
        /// </summary>
        /// <returns>Server URL</returns>
        internal string GetServerUrl()
        {
            return apiBaseUrl.TrimEnd('/') + apiVersion;
        }
    }
}
