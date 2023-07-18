﻿using Portal.Domain.Entities.Common;

namespace Portal.Domain.Entities
{
    public class Category: BaseEntity
    {
        public int Content { get; set; }
        public  ICollection<CategoryUser>? Users { get; set; }
    }
}
