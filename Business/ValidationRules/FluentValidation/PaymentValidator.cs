using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class PaymentValidator:AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(payment => payment.CustomerId).NotEmpty();
            RuleFor(payment => payment.CardNumber).NotEmpty();
            RuleFor(payment => payment.CardHolder).NotEmpty();

            RuleFor(payment => payment.CardNumber).Length(16);
            
            RuleFor(payment => payment.SecurityNumber).NotEmpty();
            RuleFor(payment => payment.SecurityNumber).Length(3);
            RuleFor(payment => payment.CustomerId).NotEmpty();

            RuleFor(payment => payment.ExpiryDate).NotEmpty();

        }
    }
}
