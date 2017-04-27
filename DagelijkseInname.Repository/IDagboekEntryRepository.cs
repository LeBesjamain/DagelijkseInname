using DagelijkseInname.Model;
using System;
using System.Collections.Generic;

namespace DagelijkseInname.Repository
{
    public interface IDagboekEntryRepository
    {
        List<DagboekEntry> HaalDagboekEntriesOpVoorSpecifiekeDatum(DateTime datum);
        void Nieuw(DagboekEntry dagboekEntry);
        bool BestaatDagboekentryVoorSpecifiekeDatum(int productId, DateTime datum);
        DagboekEntry HaalDagboekentryOp(int productId);
        List<DagboekEntry> OverzichtVanTotalenPerDag(int aantalDagenTerug);
        void Wijzig(DagboekEntry dagboekEntry);
    }
}
