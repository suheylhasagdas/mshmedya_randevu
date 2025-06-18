﻿using Model.Base.Entities;

namespace Model.Entities
{
    public class AppUsers : EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
    }
}
