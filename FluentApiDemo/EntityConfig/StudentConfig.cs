using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApiDemo.EntityConfig
{
    public class StudentConfig : EntityTypeConfiguration<Student>
    {
        public StudentConfig()
        {
            this.ToTable("T_Student");
            this.HasRequired(p => p.Class).WithMany().HasForeignKey(f => f.ClassId);
        }
    }
}
