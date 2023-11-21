using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger2023.DTO
{
    public class RequestDTO
    {
        [Required]
        public string FoodName { get; set; }

        [Required]
        public int FoodQuantity { get; set; }

        [Required]
        public System.DateTime PreserveTime { get; set; }

        [Required]
        public int RestaurantID { get; set; }

        [Required]
        public string Status { get; set; }

    }
}