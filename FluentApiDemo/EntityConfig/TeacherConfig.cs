using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApiDemo.EntityConfig
{
    public class TeacherConfig : EntityTypeConfiguration<Teacher>
    {
        public TeacherConfig()
        {
            this.ToTable("T_Teacher");
            this.HasMany(t => t.Students).WithMany(s=>s.Teachers).
                Map(ts => ts.ToTable("T_TeacherStudentRelation")
                .MapLeftKey("TeacherId")
                .MapRightKey("StudentId"));
        }
    }
}
