﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Models;

namespace App.IBLL
{
    public interface IHomeBLL
    {
        List<SysModule> GetMenuByPersonId(string moduleId);
    }
}