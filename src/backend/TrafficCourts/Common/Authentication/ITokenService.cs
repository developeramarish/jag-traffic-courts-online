﻿namespace TrafficCourts.Common.Authentication;

/// <summary>
/// Provides a service to get OAuth tokens.
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// Gets an OAuth tokens.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    Task<Token?> GetTokenAsync(OAuthOptions configuration, CancellationToken cancellationToken = default(CancellationToken));
}
