﻿namespace MedicineManagerAPI.Entities
{
    public class Diet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public DateTime WhenToEat { get; set; }
    }
}
