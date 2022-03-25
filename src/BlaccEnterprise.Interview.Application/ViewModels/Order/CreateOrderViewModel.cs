using System;
using System.ComponentModel.DataAnnotations;

using BlaccEnterprise.Interview.Domain.Order.Enums;

using Microsoft.AspNetCore.Mvc;

namespace BlaccEnterprise.Interview.Application.ViewModels
{
    public class CreateOrderViewModel
    {
        [ModelBinder(Name = "orderNumber")]
        [Required(ErrorMessage = "The OrderNumber is Required")]
        public string OrderNumber { get; set; }

        [ModelBinder(Name = "orderDate")]
        [Required(ErrorMessage = "The OrderDate is Required")]
        public DateTime OrderDate { get; set; }

        [ModelBinder(Name = "amount")]
        [Required(ErrorMessage = "The Amount is Required")]
        public double Amount { get; set; }

        [ModelBinder(Name = "status")]
        [Required(ErrorMessage = "The Status is Required")]
        public EOrderStatus Status { get; set; }

        [ModelBinder(Name = "orderSource")]
        [Required(ErrorMessage = "The OrderSource is Required")]
        public string OrderSource { get; set; }
    }
}