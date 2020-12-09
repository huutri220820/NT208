using System;
using DataLayer.Enums;
using FluentValidation;

namespace ModelAndRequest.Order
{
    public class OrderRequest
    {
        //public int Id { get; set; }
        public Guid UserId { get; set; }
        public String Address { get; set; }
        public DateTime DateCreate { get; set; } = DateTime.Now;
        public DateTime? DateReceive { get; set; }
        public DateTime? DateReturn { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.DA_DAT_HANG;
    }

    public class OrderRequestValidator : AbstractValidator<OrderRequest>
    {
        public OrderRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId khong the de trong");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address khong the de trong");
        }
    }
}