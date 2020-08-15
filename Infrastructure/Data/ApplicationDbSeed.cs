using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class ApplicationDbSeed
    {
        public static async Task SeedAsync(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            const string seedDataFilePath = "../Infrastructure/Data/SeedData";

            try
            {
                SeedEntities(context, loggerFactory, seedDataFilePath);
                SeedRelatedEntities(context, loggerFactory, seedDataFilePath);

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<ApplicationDbSeed>();
                logger.LogError(ex.Message);
            }
        }

        private static void SeedEntities(ApplicationDbContext context, ILoggerFactory loggerFactory, string seedDataFilePath)
        {
            if (!context.Entities.Any())
            {
                var entitiesData = File.ReadAllText($"{seedDataFilePath}/entities.json");
                var entities = JsonSerializer.Deserialize<List<Entity>>(entitiesData);

                foreach (var entity in entities)
                {
                    context.Entities.Add(entity);
                }
            }
        }

        private static void SeedRelatedEntities(ApplicationDbContext context, ILoggerFactory loggerFactory, string seedDataFilePath)
        {
            if (!context.Entities.Any())
            {
                var relatedEntitiesData = File.ReadAllText($"{seedDataFilePath}/relatedEntities.json");
                var relatedEntities = JsonSerializer.Deserialize<List<RelatedEntity>>(relatedEntitiesData);

                foreach (var relatedEntity in relatedEntities)
                {
                    context.RelatedEntities.Add(relatedEntity);
                }
            }
        }
    }
}