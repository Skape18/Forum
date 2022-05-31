using DAL.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.EntityFramework.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220528145830_AddFullTextSearch")]
    partial class AddFullTextSearch {
        
    }
}