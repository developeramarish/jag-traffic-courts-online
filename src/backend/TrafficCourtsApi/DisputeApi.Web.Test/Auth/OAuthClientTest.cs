﻿using AutoFixture;
using DisputeApi.Web.Auth;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DisputeApi.Web.Test.Auth
{
    [ExcludeFromCodeCoverage]
    public class OAuthClientTest
    {
        private OAuthClient _sut;
        private HttpClient _httpClient;
        private Mock<HttpMessageHandler> _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        private Mock<IOptionsMonitor<OAuthOptions>> _optionsMock = new Mock<IOptionsMonitor<OAuthOptions>>();
        private Mock<ILogger<OAuthClient>> _loggerMock = new Mock<ILogger<OAuthClient>>();
        private Token _token;

        [SetUp]
        public void SetUp()
        {
            Fixture fixture = new Fixture();
            // use real http client with mocked handler here
            _httpClient = new HttpClient(_httpMessageHandlerMock.Object)
            {
                BaseAddress = fixture.Create<Uri>(),
            };
            _optionsMock.Setup(x => x.CurrentValue).Returns(fixture.Create<OAuthOptions>());
            _token = fixture.Create<Token>();
            _sut = new OAuthClient(_httpClient, _optionsMock.Object, _loggerMock.Object);
        }
        [Test]
        public async Task GetRefreshToken_if_http_return_token_correctly_return_this_token()
        {
            _httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                // prepare the expected response of the mocked http call
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonSerializer.Serialize<Token>(_token))
                })
                .Verifiable();

            Token token = await _sut.GetRefreshToken(CancellationToken.None);
            Assert.AreEqual(_token.AccessToken, token.AccessToken);
            Assert.AreEqual(_token.TokenType, token.TokenType);
            Assert.AreEqual(_token.ExpiresIn, token.ExpiresIn);
            Assert.AreEqual(_token.Scope, token.Scope);
        }

        [Test]
        public void fixture_GetRefreshToken_if_http_return_token_correctly_return_this_token()
        {
            
            _httpMessageHandlerMock
                 .Protected()
                 .Setup<Task<HttpResponseMessage>>(
                     "SendAsync",
                     ItExpr.IsAny<HttpRequestMessage>(),
                     ItExpr.IsAny<CancellationToken>()
                 )
                 // prepare the expected response of the mocked http call
                 .ReturnsAsync(new HttpResponseMessage()
                 {
                     StatusCode = HttpStatusCode.BadRequest,
                     Content = new StringContent(JsonSerializer.Serialize<Token>(_token))
                 })
                 .Verifiable();


            Assert.ThrowsAsync<OAuthException>(async () =>
            {
                var token = await _sut.GetRefreshToken(CancellationToken.None);
            });
        }


 
    }
}