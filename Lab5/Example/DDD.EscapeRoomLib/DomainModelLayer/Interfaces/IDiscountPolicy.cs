using DDD.Base.DomainModelLayer.Models;

namespace DDD.EscapeRoomLib.DomainModelLayer.Interfaces
{
    public interface IDiscountPolicy
    {
        string Name { get; }
        Money CalculateDiscount(Money total, long numOfMinutes, Money unitPrice);
    }
}