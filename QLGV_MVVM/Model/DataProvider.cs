﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGV_MVVM.Model
{
   public  class DataProvider
    {

        private static DataProvider instance;
        public static DataProvider Instance { get { if (instance == null) instance = new DataProvider(); return instance; } set { instance = value; } }
        public QUANLYGIANGVIENEntities1 DB { get; set; }
        private DataProvider()
        {
            DB = new QUANLYGIANGVIENEntities1();
        }
    }
}
