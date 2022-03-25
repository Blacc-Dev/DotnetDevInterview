using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;

namespace BlaccEnterprise.Interview.Application.ViewModels.LineInterview
{
    public class UpdateLineInterviewViewModel
    {
        [Required(ErrorMessage = "The Id is Required")]
        [ModelBinder(Name = "id")]
        public int Id { get; set; }

        [ModelBinder(Name = "orderId")]
        [Required(ErrorMessage = "The OrderId is Required")]
        public int OrderId { get; set; }

        [ModelBinder(Name = "productName")]
        [Required(ErrorMessage = "The ProductName is Required")]
        public string ProductName { get; set; }

        [ModelBinder(Name = "quantity")]
        [Required(ErrorMessage = "The Quantity is Required")]
        public int Quantity { get; set; }

        [ModelBinder(Name = "amount")]
        [Required(ErrorMessage = "The Amount is Required")]
        public double Amount { get; set; }
    }
}