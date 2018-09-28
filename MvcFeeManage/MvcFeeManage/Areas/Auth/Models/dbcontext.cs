using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcFeeManage.Areas.Auth.Models
{
    public class dbcontext : DbContext
    {
        public dbcontext() : base("dbcontext")
        {
            //Database.SetInitializer<dbcontext>(new CreateDatabaseIfNotExists<dbcontext>());

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<dbcontext, MvcFeeManage.Migrations.Configuration>("dbcontext"));
        }

        public System.Data.Entity.DbSet<MvcFeeManage.Areas.Auth.Models.tblroom> tblrooms { get; set; }

        public System.Data.Entity.DbSet<MvcFeeManage.Areas.Auth.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<MvcFeeManage.Areas.Auth.Models.tblstudentdata> tblstudentdata { get; set; }

        public System.Data.Entity.DbSet<MvcFeeManage.Areas.Auth.Models.tblreceptionist> tblreceptionists { get; set; }
   
        public System.Data.Entity.DbSet<MvcFeeManage.Areas.Auth.Models.Fees_Master> Fees_Master { get; set; }

        public System.Data.Entity.DbSet<MvcFeeManage.Areas.Auth.Models.tblReceipt> tblReceipt { get; set; }
        public System.Data.Entity.DbSet<MvcFeeManage.Areas.Auth.Models.StudentCourse> StudentCourse { get; set; }

        public System.Data.Entity.DbSet<MvcFeeManage.Areas.Auth.Models.Recipt_Details> Recipt_Details { get; set; }

        public System.Data.Entity.DbSet<MvcFeeManage.Areas.Auth.Models.tblinquiry> tblinquiries { get; set; }
    }
}