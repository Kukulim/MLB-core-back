﻿namespace ReactWebBackend.Models.UsersModels
{
    public class ShippingAddress
    {
        public string SurName { get; set; } //Surname (or company name)
        public string LastName { get; set; } //Lastname (or NIP)
        public string State { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int ApartmentNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
    }
}