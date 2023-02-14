//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

using System.Text.Json.Serialization;

#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."
#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."
#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'
#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...
#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."
#pragma warning disable 8073 // Disable "CS8073 The result of the expression is always 'false' since a value of type 'T' is never equal to 'null' of type 'T?'"
#pragma warning disable 3016 // Disable "CS3016 Arrays as attribute arguments is not CLS-compliant"
#pragma warning disable 8603 // Disable "CS8603 Possible null reference return"

namespace TrafficCourts.Common.OpenAPIs.VirusScan.V1
{
    using System = global::System;

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial interface IVirusScanClient
    {
        /// <summary>
        /// Pings the ClamAV server
        /// </summary>
        /// <remarks>
        /// Sends a PING command to the ClamAV server
        /// </remarks>
        /// <returns>Ping was successful.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task PingAsync();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>
        /// Pings the ClamAV server
        /// </summary>
        /// <remarks>
        /// Sends a PING command to the ClamAV server
        /// </remarks>
        /// <returns>Ping was successful.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task PingAsync(System.Threading.CancellationToken cancellationToken);

        /// <summary>
        /// Scans a file for viruses
        /// </summary>
        /// <remarks>
        /// Sends an INSTREAM command to the ClamAV server and streams the upload file for scanning.
        /// </remarks>
        /// <returns>The virus scan operation completed successfully.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<VirusScanResult> VirusScanAsync(FileParameter file);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>
        /// Scans a file for viruses
        /// </summary>
        /// <remarks>
        /// Sends an INSTREAM command to the ClamAV server and streams the upload file for scanning.
        /// </remarks>
        /// <returns>The virus scan operation completed successfully.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<VirusScanResult> VirusScanAsync(FileParameter file, System.Threading.CancellationToken cancellationToken);

        /// <summary>
        /// Gets the ClamAV server and databas version
        /// </summary>
        /// <remarks>
        /// Sends a VERSION command to the ClamAV server and returns the ClamAV and virus defintion versions.
        /// </remarks>
        /// <returns>The version of ClamAV was retrieved successfully.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<GetVersionResult> VersionAsync();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>
        /// Gets the ClamAV server and databas version
        /// </summary>
        /// <remarks>
        /// Sends a VERSION command to the ClamAV server and returns the ClamAV and virus defintion versions.
        /// </remarks>
        /// <returns>The version of ClamAV was retrieved successfully.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<GetVersionResult> VersionAsync(System.Threading.CancellationToken cancellationToken);

    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class VirusScanClient : IVirusScanClient
    {
        private System.Net.Http.HttpClient _httpClient;
        private System.Lazy<System.Text.Json.JsonSerializerOptions> _settings;

        public VirusScanClient(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient;
            _settings = new System.Lazy<System.Text.Json.JsonSerializerOptions>(CreateSerializerSettings);
        }

        private System.Text.Json.JsonSerializerOptions CreateSerializerSettings()
        {
            var settings = new System.Text.Json.JsonSerializerOptions();
            UpdateJsonSerializerSettings(settings);
            return settings;
        }

        protected System.Text.Json.JsonSerializerOptions JsonSerializerSettings { get { return _settings.Value; } }

        partial void UpdateJsonSerializerSettings(System.Text.Json.JsonSerializerOptions settings);

        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
        partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);

        /// <summary>
        /// Pings the ClamAV server
        /// </summary>
        /// <remarks>
        /// Sends a PING command to the ClamAV server
        /// </remarks>
        /// <returns>Ping was successful.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task PingAsync()
        {
            return PingAsync(System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>
        /// Pings the ClamAV server
        /// </summary>
        /// <remarks>
        /// Sends a PING command to the ClamAV server
        /// </remarks>
        /// <returns>Ping was successful.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task PingAsync(System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append("v1/clamav/ping");

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            return;
                        }
                        else
                        if (status_ == 500)
                        {
                            string responseText_ = ( response_.Content == null ) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("There was an error pinging ClamAV.", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>
        /// Scans a file for viruses
        /// </summary>
        /// <remarks>
        /// Sends an INSTREAM command to the ClamAV server and streams the upload file for scanning.
        /// </remarks>
        /// <returns>The virus scan operation completed successfully.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<VirusScanResult> VirusScanAsync(FileParameter file)
        {
            return VirusScanAsync(file, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>
        /// Scans a file for viruses
        /// </summary>
        /// <remarks>
        /// Sends an INSTREAM command to the ClamAV server and streams the upload file for scanning.
        /// </remarks>
        /// <returns>The virus scan operation completed successfully.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<VirusScanResult> VirusScanAsync(FileParameter file, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append("v1/clamav/scan");

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var boundary_ = System.Guid.NewGuid().ToString();
                    var content_ = new System.Net.Http.MultipartFormDataContent(boundary_);
                    content_.Headers.Remove("Content-Type");
                    content_.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data; boundary=" + boundary_);

                    if (file == null)
                        throw new System.ArgumentNullException("file");
                    else
                    {
                        var content_file_ = new System.Net.Http.StreamContent(file.Data);
                        if (!string.IsNullOrEmpty(file.ContentType))
                            content_file_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse(file.ContentType);
                        content_.Add(content_file_, "file", file.FileName ?? "file");
                    }
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<VirusScanResult>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if (status_ == 400)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<ProblemDetails>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<ProblemDetails>("No file supplied.", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                        else
                        if (status_ == 500)
                        {
                            string responseText_ = ( response_.Content == null ) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("There was an error scanning the file for virus.", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>
        /// Gets the ClamAV server and databas version
        /// </summary>
        /// <remarks>
        /// Sends a VERSION command to the ClamAV server and returns the ClamAV and virus defintion versions.
        /// </remarks>
        /// <returns>The version of ClamAV was retrieved successfully.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<GetVersionResult> VersionAsync()
        {
            return VersionAsync(System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>
        /// Gets the ClamAV server and databas version
        /// </summary>
        /// <remarks>
        /// Sends a VERSION command to the ClamAV server and returns the ClamAV and virus defintion versions.
        /// </remarks>
        /// <returns>The version of ClamAV was retrieved successfully.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<GetVersionResult> VersionAsync(System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append("v1/clamav/version");

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<GetVersionResult>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if (status_ == 500)
                        {
                            string responseText_ = ( response_.Content == null ) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("There was an error getting the version from ClamAV.", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        protected struct ObjectResponseResult<T>
        {
            public ObjectResponseResult(T responseObject, string responseText)
            {
                this.Object = responseObject;
                this.Text = responseText;
            }

            public T Object { get; }

            public string Text { get; }
        }

        public bool ReadResponseAsString { get; set; }

        protected virtual async System.Threading.Tasks.Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(System.Net.Http.HttpResponseMessage response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Threading.CancellationToken cancellationToken)
        {
            if (response == null || response.Content == null)
            {
                return new ObjectResponseResult<T>(default(T), string.Empty);
            }

            if (ReadResponseAsString)
            {
                var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    var typedBody = System.Text.Json.JsonSerializer.Deserialize<T>(responseText, JsonSerializerSettings);
                    return new ObjectResponseResult<T>(typedBody, responseText);
                }
                catch (System.Text.Json.JsonException exception)
                {
                    var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, responseText, headers, exception);
                }
            }
            else
            {
                try
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    {
                        var typedBody = await System.Text.Json.JsonSerializer.DeserializeAsync<T>(responseStream, JsonSerializerSettings, cancellationToken).ConfigureAwait(false);
                        return new ObjectResponseResult<T>(typedBody, string.Empty);
                    }
                }
                catch (System.Text.Json.JsonException exception)
                {
                    var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
                }
            }
        }

        private string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return "";
            }

            if (value is System.Enum)
            {
                var name = System.Enum.GetName(value.GetType(), value);
                if (name != null)
                {
                    var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                    if (field != null)
                    {
                        var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute)) 
                            as System.Runtime.Serialization.EnumMemberAttribute;
                        if (attribute != null)
                        {
                            return attribute.Value != null ? attribute.Value : name;
                        }
                    }

                    var converted = System.Convert.ToString(System.Convert.ChangeType(value, System.Enum.GetUnderlyingType(value.GetType()), cultureInfo));
                    return converted == null ? string.Empty : converted;
                }
            }
            else if (value is bool) 
            {
                return System.Convert.ToString((bool)value, cultureInfo).ToLowerInvariant();
            }
            else if (value is byte[])
            {
                return System.Convert.ToBase64String((byte[]) value);
            }
            else if (value.GetType().IsArray)
            {
                var array = System.Linq.Enumerable.OfType<object>((System.Array) value);
                return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
            }

            var result = System.Convert.ToString(value, cultureInfo);
            return result == null ? "" : result;
        }
    }

    /// <summary>
    /// The virus scanner version details.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class GetVersionResult
    {
        /// <summary>
        /// The version of the Clam AV server software.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("version")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string Version { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("definition")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public VirusDefinitionVersion Definition { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class ProblemDetails
    {

        [System.Text.Json.Serialization.JsonPropertyName("type")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string Type { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("title")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string Title { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("status")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public int? Status { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("detail")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string Detail { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("instance")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string Instance { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

        [System.Text.Json.Serialization.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class VirusDefinitionVersion
    {
        /// <summary>
        /// The version of the virus definition signatures.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("version")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string Version { get; set; }

        /// <summary>
        /// The date of the virus definition signatures.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("date")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public System.DateTimeOffset Date { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class VirusScanResult
    {

        [System.Text.Json.Serialization.JsonPropertyName("status")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        public VirusScanStatus Status { get; set; }

        /// <summary>
        /// If the status is Error, the error message , otherwise null.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("error")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string Error { get; set; }

        /// <summary>
        /// If the status is Infected, the virus name, otherwise null.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("virusName")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string VirusName { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum VirusScanStatus
    {

        [System.Runtime.Serialization.EnumMember(Value = @"Error")]
        Error = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"Infected")]
        Infected = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"NotInfected")]
        NotInfected = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class FileParameter
    {
        public FileParameter(System.IO.Stream data)
            : this (data, null, null)
        {
        }

        public FileParameter(System.IO.Stream data, string fileName)
            : this (data, fileName, null)
        {
        }

        public FileParameter(System.IO.Stream data, string fileName, string contentType)
        {
            Data = data;
            FileName = fileName;
            ContentType = contentType;
        }

        public System.IO.Stream Data { get; private set; }

        public string FileName { get; private set; }

        public string ContentType { get; private set; }
    }



    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class ApiException : System.Exception
    {
        public int StatusCode { get; private set; }

        public string Response { get; private set; }

        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

        public ApiException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException)
            : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + ((response == null) ? "(null)" : response.Substring(0, response.Length >= 512 ? 512 : response.Length)), innerException)
        {
            StatusCode = statusCode;
            Response = response;
            Headers = headers;
        }

        public override string ToString()
        {
            return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class ApiException<TResult> : ApiException
    {
        public TResult Result { get; private set; }

        public ApiException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, TResult result, System.Exception innerException)
            : base(message, statusCode, response, headers, innerException)
        {
            Result = result;
        }
    }

}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore  472
#pragma warning restore  114
#pragma warning restore  108
#pragma warning restore 3016
#pragma warning restore 8603