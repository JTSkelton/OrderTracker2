using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using OrderTracker.Models;

namespace OrderTracker.Controllers
{
  public class VendorController : Controller
  {

    [HttpGet("/vendor")]
    public ActionResult Index()
    {
      List<Vendor> allVendors = Vendor.GetAll();
      return View(allVendors);
    }

    [HttpGet("/vendor/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/vendor")]
    public ActionResult Create(string VendorName)
    {
      Vendor newVendor = new Vendor(VendorName);
      return RedirectToAction("Index");
    }

    [HttpGet("/vendor/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor selectedVendor = Vendor.Find(id);
      List<Order> vendorOrders = selectedVendor.Orders;
      model.Add("Vendor", selectedVendor);
      model.Add("Orders", vendorOrders);
      return View(model);
    }

    [HttpPost("/vendor/{vendorId}/order")]
    public ActionResult Create(int vendorId, string orderDescription)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor foundVendor = Vendor.Find(vendorId);
      Order newOrder = new Order(orderDescription);
      foundVendor.AddOrder(newOrder);
      List<Order> vendorOrders = foundVendor.Orders;
      model.Add("Orders", vendorOrders);
      model.Add("Vendor", foundVendor);
      return View("Show", model);
    }
  }
}