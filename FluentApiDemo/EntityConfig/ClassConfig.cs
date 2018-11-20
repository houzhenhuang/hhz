using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApiDemo.EntityConfig
{
    public class ClassConfig : EntityTypeConfiguration<Class>
    {
        public ClassConfig()
        {
            this.ToTable("T_Class");
        }
    }
}
