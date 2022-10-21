using System.Collections.Generic;

namespace WEB_053503_NGUYEN2.Entities
{
    public class CarGroup
    {
        public int CarGroupId { get; set; }
        public string CarGroupName { get; set; }
        public List<Car> Cars { get; set; }
    }

}
