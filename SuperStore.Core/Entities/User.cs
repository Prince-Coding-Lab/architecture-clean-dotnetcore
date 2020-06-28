using SuperStore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperStore.Core.Entities
{
   public class User: BaseEntity, IAggregateRoot
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<Store> Stores { get; set; }
    }
}
