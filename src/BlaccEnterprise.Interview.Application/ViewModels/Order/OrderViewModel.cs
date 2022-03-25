namespace BlaccEnterprise.Interview.Application.ViewModels
{
    public class OrderViewModel
    {
        public long OrderNumber { get; set; }
        public string OrderDate { get; set; }
        public double Amount { get; set; }
        public string AmountInTurkish { get; set; }
        public string Status { get; set; }
        public string OrderSource { get; set; }
        public string TrackingNumber { get; set; }
        public string CargoName { get; set; }
    }
}