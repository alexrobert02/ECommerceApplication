﻿using ECommerceApplication.App.Contracts;
using ECommerceApplication.App.Pages;
using ECommerceApplication.App.Services.Responses;
using ECommerceApplication.App.ViewModels;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace ECommerceApplication.App.Services
{
    public class ApiResponseProduct
    {
        public List<ProductViewModel> Products { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<String> ValidationsErrors { get; set; }
    }
    public class ProductDataService : IProductDataService
    {
        private const string RequestUri = "api/v1/products";
        private readonly HttpClient httpClient;
        private readonly ITokenService tokenService;

        public ProductDataService(HttpClient httpClient, ITokenService tokenService)
        {
            this.httpClient = httpClient;
            this.tokenService = tokenService;
        }

        public async Task<ApiResponse<ProductDto>> CreateProductAsync(ProductViewModel productViewModel)
        {
            httpClient.DefaultRequestHeaders.Authorization= new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());
            var result = await httpClient.PostAsJsonAsync(RequestUri, productViewModel);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadFromJsonAsync<ApiResponse<ProductDto>>();
            response!.IsSuccess = result.IsSuccessStatusCode;
            return response!;
        }

        public async Task<List<ProductViewModel>> GetProductAsync()
        {
            var result = await httpClient.GetAsync(RequestUri, HttpCompletionOption.ResponseHeadersRead);
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            if (!result.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            //Console.WriteLine(content);
            var apiResponse = JsonSerializer.Deserialize<ApiResponseProduct>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if(apiResponse == null)
            {
                throw new ApplicationException("Api response is null");
            }
            Console.WriteLine(apiResponse);
            List<ProductViewModel> products = apiResponse.Products;
            return products!;
        }

        public async Task<ApiResponse<ProductDto>> UpdateProductAsync(ProductViewModel updatedProduct)
        {
            // Asigură-te că ai o rută corectă definită în backend pentru a actualiza categoria
            string updateUri = $"api/v1/Products/{updatedProduct.ProductId}"; 

            // Setează token-ul de autorizare pentru a putea accesa ruta protejată din backend
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());

            // Trimite o solicitare PUT către backend pentru a actualiza categoria
            var result = await httpClient.PutAsJsonAsync(updateUri, updatedProduct);

            // Asigură-te că solicitarea a fost realizată cu succes
            result.EnsureSuccessStatusCode();

            // Citește răspunsul JSON primit de la backend și parsează-l într-un obiect ApiResponse<CategoryDto>
            var response = await result.Content.ReadFromJsonAsync<ApiResponse<ProductDto>>();

            // Setează proprietatea IsSuccess pe baza rezultatului solicitării HTTP
            response!.IsSuccess = result.IsSuccessStatusCode;

            return response!;
        }
    }
}