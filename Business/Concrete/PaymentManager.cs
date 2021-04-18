using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Add(Payment payment)
        {
            if (CheckPaymentNumber(payment.CardNumber))
                return new SuccessResult(Messages.PaymentAlreadyExists);
            _paymentDal.Add(payment);
            return new SuccessResult(Messages.PaymentAdded);
        }

        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult(Messages.PaymentDeleted);
        }

        public IDataResult<List<Payment>> GetAll()
        {
            var result = _paymentDal.GetAll();
            return new SuccessDataResult<List<Payment>>(result,Messages.PaymentListed);
        }

        public IDataResult<Payment> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(p => p.CustomerId == customerId));
        }

        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult(Messages.PaymentUpdated);
        }
        public bool CheckPaymentNumber(string paymentNumber)
        {
            var getByPaymentuNumber = _paymentDal.Get(p => p.CardNumber == paymentNumber);
            if (getByPaymentuNumber != null)
                return true;
            return false;
        }
    }
}
