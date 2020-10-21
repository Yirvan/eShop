using eShop.CoreBusiness.Models;
using System.Threading.Tasks;

namespace eShop.UseCases.SearchProductScreen.ShoppingCartScreen
{
    public interface IViewShoppingCartUseCase
    {
        Task<Order> Execute();
    }
}