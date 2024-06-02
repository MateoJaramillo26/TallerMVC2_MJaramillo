using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TallerMVC2_MJ.Models;

    public class mjburgerpersonalizado : DbContext
    {
        public mjburgerpersonalizado (DbContextOptions<mjburgerpersonalizado> options)
            : base(options)
        {
        }

        public DbSet<TallerMVC2_MJ.Models.MJBurger> MJBurger { get; set; } = default!;

public DbSet<TallerMVC2_MJ.Models.MJPromo> MJPromo { get; set; } = default!;
    }
