using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.PluginInterfaces.UI;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eShop.ShoppingCart.LocalStorage
{
    public class ShoppingCart : IShopingCart
    {
        private readonly IJSRuntime jSRuntime;
        private const string cstrShoppingCart = "eShop.ShoppingCart";
        private readonly IProductRepository productRepository;

        public ShoppingCart(IJSRuntime jsRuntime, IProductRepository productRepository)
        {
            this.jSRuntime = jsRuntime;
            this.productRepository = productRepository;
        }

        Task<Order> IShopingCart.AddProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        Task<Order> IShopingCart.DeleteProductAsync(int productId)
        {
            throw new NotImplementedException();
        }

        Task IShopingCart.EmptyAsync()
        {
            throw new NotImplementedException();
        }

        Task<Order> IShopingCart.GetOrderAsync()
        {
            throw new NotImplementedException();
        }

        Task<Order> IShopingCart.PlaceOrderAsync()
        {
            throw new NotImplementedException();
        }

        Task<Order> IShopingCart.UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        Task<Order> IShopingCart.UpdateQuantityAsync(int productId, int quantity)
        {
            throw new NotImplementedException();
        }

        private async Task<Order> GetOrder()
        {
            Order order = null;

            var strOrder = await jSRuntime.InvokeAsync<string>("localStorage.getItem", cstrShoppingCart);
            if (!string.IsNullOrWhiteSpace(strOrder) && strOrder.ToLower() != "null")
                order = JsonConvert.DeserializeObject<Order>(strOrder);
            else
            {
                order = new Order();
                await SetOrder(order);
            }

            foreach (var item in order.LineItems)
            {
                item.Product = productRepository.GetProduct(item.ProductId);
            }

            return order;
        }


        private async Task SetOrder(Order order)
        {
            await jSRuntime.InvokeVoidAsync("localStorage.setItem", cstrShoppingCart, JsonConvert.SerializeObject(order));
        }
    }
}
