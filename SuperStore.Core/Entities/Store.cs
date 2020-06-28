using SuperStore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperStore.Core.Entities
{
   public class Store: BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Item> Item { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
