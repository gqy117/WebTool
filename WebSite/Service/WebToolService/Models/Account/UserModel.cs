﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebToolService
{
    [Serializable]
    public class UserModel : LoginModel
    {
        public int UserId { get; set; }


        public string UserName
        {
            get;
            set;
        }


    }
}
