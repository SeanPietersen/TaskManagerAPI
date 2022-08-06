﻿using Microsoft.EntityFrameworkCore;
using TaskManager.Domain;
using TaskManager.Infrustructure.DbContexts;

namespace TaskManager.Infrustructure.Repository
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly TaskManagerContext _context;

        public ActivityRepository(TaskManagerContext context)
        {
            _context = context;
        }
        public async Task<List<Activity>> AddActivitiesAsync(List<Activity> activities)
        {
            var entities = new List<Activity>();
            foreach(var activity in activities)
            {
                var entity = await _context.Activities.AddAsync(activity);
                
                if (entity.State == EntityState.Added)
                {
                    _context.SaveChanges();
                    entities.Add(entity.Entity);
                }
            }
            return entities;
        }
    }
}
