namespace MedicineManagerAPI.Models
{
    public class DietDto
    {
        public int Id { get; set; }
        public string FoodName { get; set; }
        public string FoodDescription { get; set; }
        public int FoodAmount { get; set; }
        public DateTime WhenToEat { get; set; }
    }
}
