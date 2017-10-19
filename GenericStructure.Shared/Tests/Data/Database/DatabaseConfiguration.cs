﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStructure.Shared.Tests.Data.Database
{
    public static class DatabaseConfiguration
    {
        public static string CoreBusinessConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["CoreBusinessTestDB"].ConnectionString; }
        }
        public static string ErrorsReportingConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["ErrorsReportingContext"].ConnectionString; }
        }
    }
}