using DagelijkseInname.Model;
using DagelijkseInname.Models;
using DagelijkseInname.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DagelijkseInname.Controllers
{
    [RoutePrefix("dagboekentries")]
    public class DagboekEntryController : Controller
    {
        private readonly IDagboekEntryRepository _dagboekEntryRepository;

        public DagboekEntryController(IDagboekEntryRepository dagboekEntryRepository)
        {
            _dagboekEntryRepository = dagboekEntryRepository;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Index(int aantalDagenTerug = 4)
        {
            List<DagboekEntry> dagboekentries = _dagboekEntryRepository.OverzichtVanTotalenPerDag(aantalDagenTerug);
            List<DagboekEntryModel> result = new List<DagboekEntryModel>();

            foreach (var dagboekentry in dagboekentries)
            {
                result.Add(new DagboekEntryModel
                {
                    DatumDagboekentry = dagboekentry.Datum,
                    TotaalAanVetGeconsumeerdInGram = dagboekentry.TotaalAanVetGeconsumeerdInGram,
                    TotaalAanKoolhydratenGeconsumeerdInGram = dagboekentry.TotaalAanKoolhydratenGeconsumeerdInGram,
                    TotaalAanEiwittenGeconsumeerdInGram = dagboekentry.TotaalAanEiwittenGeconsumeerdInGram,
                    TotaalAanCalorieenGeconsumeerd = (dagboekentry.TotaalAanKiloCalorieen)
                });
            }

            return View(result);
        }

        [HttpGet]
        [Route("{productId:int}")]
        public ActionResult Nieuw()
        {
            return View();
        }

        [HttpPost]
        [Route("{productId:int}")]
        public ActionResult Nieuw(DagboekEntryModel dagboekentryModel)
        {
            try
            {
                DagboekEntry dagboekentry = _dagboekEntryRepository.HaalDagboekentryOp(dagboekentryModel.ProductId);

                if (dagboekentry != null)
                {
                    dagboekentry.GeconsumeerdInGram += dagboekentryModel.GeconsumeerdInGram;
                    _dagboekEntryRepository.Nieuw(dagboekentry);
                }
                else
                {
                    DagboekEntry dagboekEntry = new DagboekEntry
                    {
                        Datum = DateTime.Today,
                        GeconsumeerdInGram = dagboekentryModel.GeconsumeerdInGram,
                        ProductId = dagboekentryModel.ProductId
                    };

                    _dagboekEntryRepository.Nieuw(dagboekEntry);
                }
            }
            catch (Exception e)
            {
                throw;
            }

            TempData["Success"] = "Dagboekentry is opgeslagen.";

            return RedirectToAction("Index", "Product");
        }
    }
}