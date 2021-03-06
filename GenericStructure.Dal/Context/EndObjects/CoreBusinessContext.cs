﻿using GenericStructure.Dal.Context.Base;

namespace GenericStructure.Dal.Context.EndObjects
{
    // https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/powershell
    // Get-Help EntityFramework

    // Enable-Migrations
    // Add-Migration <name>
    // Update-Database

    // -------------------------------------------------

    // Enable-Migrations -MigrationsDirectory "Migrations\Production" -ContextTypeName GenericStructure.Dal.Context.EndObjects.CoreBusinessContext

    // Add-Migration -ConfigurationTypeName ProdConfiguration -Name <something>

    // Update-Database -ConfigurationTypeName ProdConfiguration

    public class CoreBusinessContext : CoreBusinessBaseContext
    {
        public CoreBusinessContext() : base("name=CoreBusinessContext") { }
    }
}
