﻿using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace TrafficCourts.Common.Authentication;

public class OAuthClient : IOAuthClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<OAuthClient> _logger;

    public OAuthClient(HttpClient httpClient, ILogger<OAuthClient> logger)
    {
        this._httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Token?> GetTokenAsync(OAuthOptions options, CancellationToken cancellationToken)
    {
        if (options is null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

        var data = new Dictionary<string, string>
                {
                    {"client_id", options.ClientId!},
                    {"client_secret", options.ClientSecret!},
                    {"scope", "openid"},
                    {"grant_type", "client_credentials"}
                };

        using var content = new FormUrlEncodedContent(data);

        var response = await _httpClient
            .PostAsync(options.TokenUri, content, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            // {"error":"invalid_client","error_description":"MSIS9607: The \u0027client_id\u0027 parameter in the request is invalid. No registered client is found with this identifier."}
            var responseData = string.Empty;

            if (response.Content != null)
            {
                responseData = await response.Content.ReadAsStringAsync(cancellationToken);
            }

            //throw new OAuthApiException(
            //    "The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").",
            //    (int)response.StatusCode,
            //    responseData,
            //    response.Headers.ToDictionary(x => x.Key, x => x.Value), null);

            _logger.LogError("Error getting OAuth token using {ClientId} : {HttpStatus} - {ErrorMessage}", options.ClientId, response.StatusCode, responseData);
            throw new OAuthApiException("Error getting OAuth token", (int)response.StatusCode, responseData, new Dictionary<string, string>(), string.Empty);
        }

        await using var stream = await response.Content
            .ReadAsStreamAsync(cancellationToken);

        var token = await JsonSerializer.DeserializeAsync<Token>(stream, cancellationToken: cancellationToken);
        if (token is null)
        {
            _logger.LogError("Error deserializing OAuth token");
        }

        return token;
    }
}
