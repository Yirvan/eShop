using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.PluginInterfaces.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.UseCases.ViewProductScreen
{
    public class AddProductToCartUseCase
    { 
        private readonly IProductRepository productRepository;
        private readonly IShopingCart shopingCart;

        public AddProductToCartUseCase(IProductRepository product, IShopingCart cart)
        {
            this.productRepository = product;
            this.shopingCart = cart;
        }

        public async void Execute(int productId)
        {
            var product = productRepository.GetProduct(productId);

            await shopingCart.AddProductAsync(product);
        }
    }
}
