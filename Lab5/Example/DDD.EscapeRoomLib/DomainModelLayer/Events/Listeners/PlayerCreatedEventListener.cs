using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Interfaces;
using DDD.EscapeRoomLib.DomainModelLayer.Events;
using DDD.EscapeRoomLib.DomainModelLayer.Interfaces;
using DDD.EscapeRoomLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace DDD.EscapeRoomLib.DomainModelLayer.Listeners
{
    public class PlayerCreatedEventListener : IEventListener<PlayerCreatedEvent>
    {
        private IEmailDispatcher _emailDispatcher;
        public PlayerCreatedEventListener(IEmailDispatcher emailDispatcher)
        {
            this._emailDispatcher = emailDispatcher;
        }

        public void Handle(PlayerCreatedEvent eventData)
        {
            string from = "EscapeRoom@gmail.com";
            string to = eventData.Email;
            string subject = "New player created...";
            string body = "Activate player...";
            MailMessage mailMessage = new MailMessage(from, to, subject, body);

            this._emailDispatcher.Send(mailMessage);
        }
    }
}
