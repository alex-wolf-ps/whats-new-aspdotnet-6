using System.Net.Http.Json;
using WiredBrainCoffee.Models;

namespace WiredBrainCoffee.UI.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient http;

        public OrderService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<OrderHistory> GetOrders()
        {
            var orders = await http.GetFromJsonAsync<OrderHistory>("orders/history");
            return orders;
        }
    }
}
