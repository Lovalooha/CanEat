﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CanEatFrontEnd.Models.DBModel
{
    [JsonObject]
    public class MsCompanyModel
    {
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }

    }
}
