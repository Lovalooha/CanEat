﻿using CanEatFrontEnd.Models;
using CanEatFrontEnd.Models.OtherDBModel;
using CanEatFrontEnd.Models.PageModel.AdminCustomerEdit;
using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Admin
{
	public class AdminCustomerEditController : Controller
	{
		public async Task<IActionResult> Index(String id)
		{
			AdminCustomerEditModel model = new AdminCustomerEditModel();
			
			Models.Customer cu1 = new Models.Customer();
			//         Company co1 = new Company();
			//         Company co2 = new Company();
			//         Company co3 = new Company();
			//         model.companyList.Add(co1);
			//model.companyList.Add(co2);
			//model.companyList.Add(co3);

			model.companyList = await Models.Company.getAllCompany();
			model.currCustomer = await Models.Customer.getCustomer(id);

   //         co1.Id = "abc-452";
   //         co1.Name = "Bina Nusantara University";
   //         co1.Address = "Jl. Alam Sutera 12 Tangerang";
   //         co1.Phone = "345678919201";

   //         co2.Id = "dsf-123";
   //         co2.Name = "Media Nusantara University";
   //         co2.Address = "Jl. Gading Raya 22 Tangerang";
   //         co2.Phone = "123451234523";

   //         co3.Id = "iue-251";
   //         co3.Name = "PT Jaya Nusantara";
   //         co3.Address = "Jl. Lalala 120 Jakarta Pusat";
   //         co3.Phone = "890890890123";

   //         cu1.Id = "cbc-123";
			//cu1.Name = "Russ";
			//cu1.Email = "RussRuss@mailme.com";
			//cu1.Phone = "124312347098";
			//cu1.Password = "RRR123";
			//cu1.Company = co1;

			return View("Views/Admin/CustomerEdit/Index.cshtml", model);
		}

		public async Task<IActionResult> editCustomer(String id)
		{
			Models.Customer c = await Models.Customer.getCustomer(id);
			CustomerEditModel model = new CustomerEditModel();
			model.id = id;
			model.name = Request.Form["name"];
			model.email = Request.Form["email"];
			model.phone = Request.Form["number"];
			model.password = c.Password;
			model.company_name = Request.Form["company"];
			await Models.Customer.editCustomer(model);
			return RedirectToAction("Index", "AdminHome");
		}
	}
}
