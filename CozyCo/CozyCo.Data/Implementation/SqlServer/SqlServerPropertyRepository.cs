using CozyCo.Data.Context;
using CozyCo.Data.Interfaces;
using CozyCo.Domain.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CozyCo.Data.Implementation.SqlServer
{
    public class SqlServerPropertyRepository : IPropertyRepository
    {
        public Property GetById(int id)
        {
            using (var context = new CozyCoDbContext())
            {
                // SQL -> Database look for table Properties
                var property = context.Properties.Single(p => p.Id == id);
                return property;
            }
        }
        public ICollection<Property> GetAllProperties()
        {
            using (var context = new CozyCoDbContext())
            {
                // DbSet != ICollection
                return context.Properties
                    .ToList(); // Now it is ICollection
            }
        }

        public Property Create(Property newProperty)
        {
            using (var context = new CozyCoDbContext())
            {
                context.Properties.Add(newProperty);
                context.SaveChanges();

                return newProperty; // newProperty.Id will be populated with new DB value
            }
        }

        public Property Update(Property updatedProperty)
        {
            using (var context = new CozyCoDbContext())
            {
                // find the old entity
                var oldProperty = GetById(updatedProperty.Id);

                // update each entity properties / get;set;
                context.Entry(oldProperty)
                    .CurrentValues
                    .SetValues(updatedProperty);

                // save changes
                context.SaveChanges();

                return oldProperty; // To ensure that the save happened
            }
        }

        public bool Delete(int id)
        {
            using (var context = new CozyCoDbContext())
            {
                // Find what we are going to delete
                var propertyToBeDeleted = GetById(id);

                // delete
                context.Properties.Remove(propertyToBeDeleted);

                // save changes
                context.SaveChanges();

                // check if entity/model exist
                if(GetById(id) == null)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
