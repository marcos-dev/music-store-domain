using Flunt.Notifications;
using MusicStore.Domain.Commands;
using MusicStore.Domain.Entities;
using MusicStore.Domain.Enums;
using MusicStore.Domain.Repositories;
using MusicStore.Domain.Services;
using MusicStore.Domain.ValueObjects;
using MusicStore.Shared.Commands;
using MusicStore.Shared.Handlers;
using System;

namespace MusicStore.Domain.Handler
{
    public class SubscriptionHandler : Notifiable, IHandler<CreateBoletoSubscriptionCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;

        public SubscriptionHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            //Fast Validations 
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Subscription not confirmed");
            }

            if (_repository.DocumentExists(command.Document))
                AddNotification("Document", "Invalid CPF");

            if (_repository.EmailExists(command.Email))
                AddNotification("Email", "Invalid Email");

            //Create VOs 
            var name = new Name(command.FirstName, command.LastName);
            var doc = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.ZipCode, command.Street, command.Number, command.Complement, command.District, command.City, command.State, command.Country);

            //Create objects 
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var customer = new Customer(name, doc, email);
            var payment = new BoletoPayment(command.Barcode, command.BoletoNumber, "", command.PaidDate, command.ExpireDate, new Document(command.OwnerDocument, command.OwnerDocumentType), email, command.Owner, address, command.Total, command.TotalPaid);

            //Add Subscription
            subscription.AddPayment(payment);
            customer.AddSubscription(subscription);

            //Check  Validations
            AddNotifications(name, doc, email, customer, address, subscription, payment);

            if (Invalid)
                return new CommandResult(false, "Signature can not be updated");

            //Save Customer 
            _repository.CreateSubscription(customer);

            //Send email
            _emailService.Send(customer.Name.ToString(), customer.Email.Address, "Welcome to Music Store!", "Your signature has been created");

            return new CommandResult(true, "Subscription created successfully");
        }
    }
}
