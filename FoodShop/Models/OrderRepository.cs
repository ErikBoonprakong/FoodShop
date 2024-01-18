namespace FoodShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FoodShopDbContext _foodShopDbContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(FoodShopDbContext foodShopDbContext, IShoppingCart shoppingCart)
        {
            _foodShopDbContext = foodShopDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _foodShopDbContext.Orders.Add(order);

            _foodShopDbContext.SaveChanges();
        }
    }
}
