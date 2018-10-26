using OCVM.Data.Interfaces;
using OCVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCVM.Data.Repository
{
    public class TrainingRepository : Repository<Training>, ITrainingRepository
    {
        public TrainingRepository(OcvmContext context) : base(context)
        {
        }

        public override void Delete(Training entity)
        {
            context.Educations.Where(b => b.TrainingDetails == entity)
                .ToList()
                .ForEach(a =>
                {
                    a.TrainingDetails = null;
                    a.TraningID = 0;
                });
            base.Delete(entity);
        }
    }
}
