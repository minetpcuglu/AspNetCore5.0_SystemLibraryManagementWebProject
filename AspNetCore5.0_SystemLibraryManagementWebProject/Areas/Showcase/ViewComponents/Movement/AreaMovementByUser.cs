using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.Areas.Showcase.ViewComponents.Movement
{
    public class AreaMovementByUser : ViewComponent
    {
         MovementManager movementManager = new MovementManager(new EfMovementRepository());
        public IViewComponentResult Invoke(int id)
        {

            var Value = movementManager.GetListWithBookByUserId(id);
            return View(Value);
        }
    }
}
