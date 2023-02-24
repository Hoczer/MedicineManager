namespace MedicineManagerAPI.Entities
{
    public class Diet
    {
        public int Id { get; set; }
        public string FoodName { get; set; }
        public string FoodDescription { get; set; }
        public int FoodAmount { get; set; }
        public DateTime WhenToEat { get; set; }
    }
}
