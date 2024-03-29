﻿using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using ECommerceApplication.App.Contracts;
using ECommerceApplication.App.Services.Responses;
using ECommerceApplication.App.ViewModels;

namespace ECommerceApplication.App.Services
{
    public class UserDataService : IUserDataService
    {
        private const string RequestUri = "api/v1/User";
        private readonly HttpClient httpClient;
        private readonly ITokenService tokenService;

        public UserDataService(HttpClient httpClient, ITokenService tokenService)
        {
            this.httpClient = httpClient;
            this.tokenService = tokenService;
        }

        public async Task<UserViewModel> GetUserByEmailAsync(string email)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());
                var result = await httpClient.GetAsync($"{RequestUri}/ByEmail/{email}", HttpCompletionOption.ResponseHeadersRead);
                result.EnsureSuccessStatusCode();
                var content = await result.Content.ReadAsStringAsync();

                using var doc = JsonDocument.Parse(content);
                var userElement = doc.RootElement.GetProperty("user");

                var user = JsonSerializer.Deserialize<UserViewModel>(userElement.GetRawText(), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during deserialization: {ex}");
                throw;
            }
        }

        public async Task<string> GetUserIdByEmailAsync(string email)
        {
            try
            {
                var user = await GetUserByEmailAsync(email);
                return user.UserId;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during deserialization: {ex}");
                throw;
            }
        }

        public async Task<ApiResponse<UpdateUserDto>> UpdateUserAsync(string id, UpdateUserDto updateUserDto)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());
            var result = await httpClient.PutAsJsonAsync($"{RequestUri}/{id}", updateUserDto);

            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadFromJsonAsync<ApiResponse<UpdateUserDto>>();
            response!.IsSuccess = result.IsSuccessStatusCode;
            return response!;
        }

    }
}
