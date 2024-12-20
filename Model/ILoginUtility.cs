﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface ILoginUtility
    {
        bool LoginCheck(string username, string password);
        bool LoginCheckRegistry(string username, string password);
        string GetHashSHA256(string source);
    }
}
