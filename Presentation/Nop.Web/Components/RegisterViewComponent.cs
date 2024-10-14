using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Customers;
using Nop.Web.Factories;
using Nop.Web.Framework.Components;
using Nop.Web.Models.Customer;

namespace Nop.Web.Components;

public partial class RegisterViewComponent: NopViewComponent
{
    protected readonly ICommonModelFactory _commonModelFactory;
    private readonly ICustomerModelFactory _customerModelFactory;
    private readonly CustomerSettings _customerSettings;

    public RegisterViewComponent(ICommonModelFactory commonModelFactory,ICustomerModelFactory customerModelFactory,CustomerSettings customerSettings)
    {
        _commonModelFactory = commonModelFactory;
        _customerModelFactory = customerModelFactory;
       _customerSettings = customerSettings;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        if (_customerSettings.UserRegistrationType == UserRegistrationType.Disabled)
            return Content("");

        var model = new RegisterModel();
        model = await _customerModelFactory.PrepareRegisterModelAsync(model, false, setDefaultValues: true);

        return View(model);
    }
}