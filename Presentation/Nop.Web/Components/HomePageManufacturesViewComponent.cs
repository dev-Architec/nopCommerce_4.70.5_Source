using Microsoft.AspNetCore.Mvc;
using Nop.Web.Factories;
using Nop.Web.Framework.Components;

namespace Nop.Web.Components;

public partial class HomePageManufacturesViewComponent : NopViewComponent
{
    protected readonly ICatalogModelFactory _catalogModelFactory;

    public HomePageManufacturesViewComponent(ICatalogModelFactory catalogModelFactory)
    {
        _catalogModelFactory = catalogModelFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _catalogModelFactory.PrepareManufacturerAllModelsAsync();
        if (!model.Any())
            return Content("");

        return View(model);
    }
}