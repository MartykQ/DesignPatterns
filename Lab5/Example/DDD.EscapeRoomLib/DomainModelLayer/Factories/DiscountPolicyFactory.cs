using DDD.EscapeRoomLib.DomainModelLayer.Interfaces;
using DDD.EscapeRoomLib.DomainModelLayer.Models;
using DDD.EscapeRoomLib.DomainModelLayer.Policies;

namespace DDD.EscapeRoomLib.DomainModelLayer.Factories
{
    public class DiscountPolicyFactory
    {
        public IDiscountPolicy Create(Player player)
        {
            IDiscountPolicy policy = new StandardDiscountPolicy();
            if (player.Name.Contains("a"))
                policy = new VipDiscountPolicy();

            return policy;
        }
    }
}
