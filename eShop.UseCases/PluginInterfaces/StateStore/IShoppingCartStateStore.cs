using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.PluginInterfaces.StateStore
{
    interface IShoppingCartStateStore: IStateStore
    {
        Task<int> GetItemsCount();
        void UpdateLineItemsCount();
    }
}
