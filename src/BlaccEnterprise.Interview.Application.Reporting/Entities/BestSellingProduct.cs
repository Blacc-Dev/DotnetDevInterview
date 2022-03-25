namespace BlaccEnterprise.Interview.Application.Reporting.Entities
{
    public class BestSellingProduct
    {
        public string ProductName { get; set; }
        public double Frequency { get; set; }

        protected BestSellingProduct() { }

        public BestSellingProduct(string productName, double frequency)
        {
            ProductName = productName;
            Frequency = frequency;
        }
    }
}