﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Res
{
    public class GetAllAdminsResult
    {
        public required IEnumerable<GetByIdResult> Admins { get; set; }
    }
}
