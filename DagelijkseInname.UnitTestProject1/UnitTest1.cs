using Microsoft.VisualStudio.TestTools.UnitTesting;
using DagelijkseInname.Model;
using DagelijkseInname.Models;

namespace DagelijkseInname.UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void updaten_van_dagboekentry_gaat_goed()
        {
            DagboekEntry dagboekEntry = new DagboekEntry
            {
                GeconsumeerdInGram = 90
            };

            DagboekEntryModel dagboekEntryModel = new DagboekEntryModel
            {

            };
        }
    }
}
