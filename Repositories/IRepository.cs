﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceDataProcessingTakeHome.Repositories
{
    public interface IRepository<T>
    {
        T GetData();
    }
}
