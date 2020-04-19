using DDD.Base.DomainModelLayer.Models;
using DDD.EscapeRoomLib.DomainModelLayer.Interfaces;

namespace DDD.EscapeRoomLib.DomainModelLayer.Policies
{
    public class VipDiscountPolicy : IDiscountPolicy
    {
        public string Name { get; protected set; }

        public VipDiscountPolicy()
        {
            this.Name = "Vip discount policy";
        }

        public Money CalculateDiscount(Money total, long numOfMinutes, Money unitPrice)
        {
            decimal percent = 0.01m;
            if (numOfMinutes > 30)
                percent = 0.05m;

            return total.MultiplyBy(percent);
        }
    }
}
