﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Category
{
    public class UpdateCategoryRequest
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
