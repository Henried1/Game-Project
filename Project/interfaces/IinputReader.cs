﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Project.Interfaces
{
    public interface IinputReader
    {
        Vector2 ReadInput();
        bool attackPressed();
    }
}
