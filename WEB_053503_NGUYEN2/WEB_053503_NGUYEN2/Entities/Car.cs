namespace WEB_053503_NGUYEN2.Entities
{
    public class Car
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public int CarGroupId { get; set; }
        public CarGroup CarGroup { get; set; }
    }
}
