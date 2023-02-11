using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Appointments.Data
{
    public class AppointmentsContext : DbContext
    {
        public AppointmentsContext (DbContextOptions<AppointmentsContext> options)
            : base(options)
        {
        }

        public DbSet<Project.Models.Appointment> Appointment { get; set; } = default!;

        public DbSet<Project.Models.Client> Client { get; set; }

        public DbSet<Project.Models.Employee> Employee { get; set; }

        public DbSet<Project.Models.Schedule> Schedule { get; set; }

        public DbSet<Project.Models.Service> Service { get; set; }

        public DbSet<Project.Models.ServiceBooked> ServiceBooked { get; set; }

        public DbSet<Project.Models.ServiceProvided> ServiceProvided { get; set; }
    }
}
