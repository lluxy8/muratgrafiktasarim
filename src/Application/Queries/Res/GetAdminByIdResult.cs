﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Res
{
    public class GetByIdResult
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
