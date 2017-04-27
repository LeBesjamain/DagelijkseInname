using DagelijkseInname.Model;
using DagelijkseInname.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DagelijkseInname.DataAccess.Repositories
{
    public class DagboekEntryRepository : IDagboekEntryRepository
    {
        public List<DagboekEntry> HaalDagboekEntriesOpVoorSpecifiekeDatum(DateTime datum)
        {
            throw new NotImplementedException();
        }

        public void Nieuw(DagboekEntry dagboekEntry)
        {
            using (var context = new DagelijkseInnameContext())
            {
                context.DagboekEntries.Add(dagboekEntry);
                context.SaveChanges();
            }
        }

        public bool BestaatDagboekentryVoorSpecifiekeDatum(int productId, DateTime datum)
        {
            using (var context = new DagelijkseInnameContext())
            {
                return context.DagboekEntries.Any(d => d.ProductId == productId && d.Datum == datum);
            }
        }

        public DagboekEntry HaalDagboekentryOp(int productId)
        {
            using (var context = new DagelijkseInnameContext())
            {
                return context.DagboekEntries
                              .Where(d => d.Datum == DateTime.Today && d.ProductId == productId)
                              .FirstOrDefault();
            }
        }

        public List<DagboekEntry> OverzichtVanTotalenPerDag(int aantalDagenTerug)
        {
            using (var context = new DagelijkseInnameContext())
            {
                var f = context.DagboekEntries
                               .Select(x => new
                               {
                                   datum = x.Datum,
                                   a = x.Product.HoeveelheidVetPerGram * x.GeconsumeerdInGram,
                                   b = x.Product.HoeveelheidKoolhydratenPerGram * x.GeconsumeerdInGram,
                                   c = x.Product.HoeveelheidEiwitPerGram * x.GeconsumeerdInGram,
                                   d = x.Product.HoeveelheidKiloCalorieenPerGram * x.GeconsumeerdInGram
                               })
                               .GroupBy(x => x.datum)
                               .OrderByDescending(x => x.Key)
                               .Take(aantalDagenTerug);

                List<DagboekEntry> dagboekentries = new List<DagboekEntry>();

                foreach (var item in f)
                {
                    dagboekentries.Add(new DagboekEntry
                    {
                        Datum = item.Key,
                        TotaalAanVetGeconsumeerdInGram = item.Sum(x => x.a),
                        TotaalAanKoolhydratenGeconsumeerdInGram = item.Sum(x => x.b),
                        TotaalAanEiwittenGeconsumeerdInGram = item.Sum(x => x.c),
                        TotaalAanKiloCalorieen = item.Sum(x => x.d)
                    });
                }

                return dagboekentries;
            }
        }

        public void Update(DagboekEntry dagboekEntry)
        {
            using (var context = new DagelijkseInnameContext())
            {
                context.DagboekEntries.Attach(dagboekEntry);
                context.Entry(dagboekEntry).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
