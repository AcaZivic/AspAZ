namespace AspAZ.DataTransfer
{
    public class CreatePriceListDTO : BaseDTO
    {
        public double Price { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

    }
}
