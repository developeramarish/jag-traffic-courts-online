﻿namespace TrafficCourts.Common.Authentication;

public class OAuthTokenService : ITokenService
{
    private readonly IOAuthClient _client;
    private readonly ITokenCache<OAuthOptions, Token> _tokenCache;

    /// <summary>Initializes a new instance of the <see cref="OAuthTokenService" /> class.</summary>
    /// <param name="client">The client.</param>
    /// <param name="tokenCache">The token cache.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="client"/> or <paramref name="tokenCache"/> is null.
    /// </exception>
    public OAuthTokenService(IOAuthClient client, ITokenCache<OAuthOptions, Token> tokenCache)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
        _tokenCache = tokenCache ?? throw new ArgumentNullException(nameof(tokenCache));
    }

    /// <summary>Gets an OAuth tokens.</summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    public async Task<Token?> GetTokenAsync(OAuthOptions configuration, CancellationToken cancellationToken)
    {
        Token? token = _tokenCache.GetToken(configuration);
        if (token is not null && !token.IsAccessTokenExpired)
        {
            return token;
        }

        // TODO: use refresh token if available 
        token = await _client.GetTokenAsync(configuration, cancellationToken);

        if (token is not null)
        {
            _tokenCache.SaveToken(configuration, token, token.AccessTokenExpiresAtUtc);
        }

        return token;
    }
}