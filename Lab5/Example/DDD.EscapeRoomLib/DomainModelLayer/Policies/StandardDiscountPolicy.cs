using DDD.Base.DomainModelLayer.Models;
using DDD.EscapeRoomLib.DomainModelLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.EscapeRoomLib.DomainModelLayer.Policies
{
    public class StandardDiscountPolicy: IDiscountPolicy
    {
        public string Name { get; protected set; }

        public StandardDiscountPolicy()
        {
            this.Name = "Standard discount policy";
        }

        public Money CalculateDiscount(Money total, long numOfMinutes, Money unitPrice)
        {
            decimal percent = 0.01m;
            return total.MultiplyBy(percent);
        }
    }
}
