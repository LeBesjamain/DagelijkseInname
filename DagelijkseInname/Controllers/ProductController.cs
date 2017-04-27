using DagelijkseInname.Model;
using DagelijkseInname.Models;
using DagelijkseInname.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DagelijkseInname.Controllers
{
    [RoutePrefix("producten")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            List<Product> producten = _productRepository.HaalAlleProductenOp();

            var result = producten.Select(p => new ProductModel
            {
                Id = p.Id,
                Naam = p.Naam,
                HoeveelheidVetPerGram = p.HoeveelheidVetPerGram,
                HoeveelheidKoolhydratenPerGram = p.HoeveelheidKoolhydratenPerGram,
                HoeveelheidEiwitPerGram = p.HoeveelheidEiwitPerGram,
                Foto = p.Foto
            });

            return View(result);
        }

        [HttpGet]
        [Route("nieuw")]
        public ActionResult Nieuw()
        {
            return View();
        }

        [HttpPost]
        [Route("nieuw")]
        public ActionResult Nieuw([Bind(Exclude = "Foto")]ProductModel productModel, HttpPostedFileBase foto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Product product = new Product
                    {
                        Naam = productModel.Naam,
                        HoeveelheidVetPerGram = productModel.HoeveelheidVetPerGram,
                        HoeveelheidKoolhydratenPerGram = productModel.HoeveelheidKoolhydratenPerGram,
                        HoeveelheidEiwitPerGram = productModel.HoeveelheidEiwitPerGram,
                        HoeveelheidKiloCalorieenPerGram = productModel.HoeveelheidKiloCalorieenPerGram
                    };

                    if (foto != null && foto.ContentLength > 0)
                    {
                        using (var reader = new BinaryReader(foto.InputStream))
                        {
                            product.Foto = reader.ReadBytes(foto.ContentLength);
                        }
                    }

                    _productRepository.Nieuw(product);
                }
                catch (Exception e)
                {
                    throw;
                }

                TempData["Success"] = "Product is opgeslagen.";

                return RedirectToAction("Nieuw");
            }

            return View();
        }

        [HttpGet]
        [Route("wijzig/{productId:int}")]
        public ActionResult Wijzig(int productId)
        {
            var product = _productRepository.HaalProductOp(productId);

            ProductModel result = new ProductModel
            {
                Id = product.Id,
                Naam = product.Naam,
                Foto = product.Foto,
                HoeveelheidVetPerGram = product.HoeveelheidVetPerGram,
                HoeveelheidKoolhydratenPerGram = product.HoeveelheidKoolhydratenPerGram,
                HoeveelheidEiwitPerGram = product.HoeveelheidEiwitPerGram,
                HoeveelheidKiloCalorieenPerGram = product.HoeveelheidKiloCalorieenPerGram
            };

            return View(result);
        }

        [HttpPost]
        [Route("wijzig/{productId:int}")]
        public ActionResult Wijzig([Bind(Exclude = "Foto")]ProductModel productModel, HttpPostedFileBase foto)
        {
            if (ModelState.IsValid)
            {
                var product = _productRepository.HaalProductOp(productModel.Id);

                if (product != null)
                {
                    if (product.Naam != productModel.Naam)
                    {
                        product.Naam = productModel.Naam;
                    }

                    if ((foto != null) && (foto.ContentLength > 0))
                    {
                        using (var reader = new BinaryReader(foto.InputStream))
                        {
                            product.Foto = reader.ReadBytes(foto.ContentLength);
                        }
                    }

                    if (product.HoeveelheidVetPerGram != productModel.HoeveelheidVetPerGram)
                    {
                        product.HoeveelheidVetPerGram = productModel.HoeveelheidVetPerGram;
                    }

                    if (product.HoeveelheidKoolhydratenPerGram != productModel.HoeveelheidKoolhydratenPerGram)
                    {
                        product.HoeveelheidKoolhydratenPerGram = productModel.HoeveelheidKoolhydratenPerGram;
                    }

                    if (product.HoeveelheidEiwitPerGram != productModel.HoeveelheidEiwitPerGram)
                    {
                        product.HoeveelheidEiwitPerGram = productModel.HoeveelheidEiwitPerGram;
                    }

                    if (product.HoeveelheidKiloCalorieenPerGram != productModel.HoeveelheidKiloCalorieenPerGram)
                    {
                        product.HoeveelheidKiloCalorieenPerGram = productModel.HoeveelheidKiloCalorieenPerGram;
                    }
                }

                try
                {
                    _productRepository.Wijzig(product);
                }
                catch (Exception)
                {
                    throw;
                }

                TempData["Success"] = "Product is gewijzigd.";

                return RedirectToAction("Wijzig");
            }

            return View();
        }
    }
}