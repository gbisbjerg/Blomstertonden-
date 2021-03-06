﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Blomstertonden
{
    public class StatusCatalog : ReadOnlyCatalogBase<Status, int>
    {
        private static StatusCatalog _instance;
        private StatusCatalog() : base(AppConfig.ServerURL, "Status")
        {
        }

        public static StatusCatalog Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StatusCatalog();
                }
                return _instance;
            }
        }

        public List<Status> StatusList
        {
            get
            {
                return All.Values.ToList();
            }
        }
    }
}
