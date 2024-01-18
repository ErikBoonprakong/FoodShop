namespace FoodShop.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
