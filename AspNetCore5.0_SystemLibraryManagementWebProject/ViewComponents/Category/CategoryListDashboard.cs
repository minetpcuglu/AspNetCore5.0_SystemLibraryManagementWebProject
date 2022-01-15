﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.ViewComponents.Category
{
    public class CategoryListDashboard : ViewComponent
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IViewComponentResult Invoke()
        {
            var Value = categoryManager.GetList();
            return View(Value);
        }
    }
}
