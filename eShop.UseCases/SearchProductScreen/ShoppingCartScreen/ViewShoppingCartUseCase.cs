using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.SearchProductScreen.ShoppingCartScreen
{
    public class ViewShoppingCartUseCase : IViewShoppingCartUseCase
    {
        private readonly IShopingCart shopingCart;

        public ViewShoppingCartUseCase(IShopingCart shopingCart)
        {
            this.shopingCart = shopingCart;
        }

        public Task<Order> Execute()
        {
            return shopingCart.GetOrderAsync();
        }
    }
}
