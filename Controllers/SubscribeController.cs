using Crito.Models;
using Crito.Repositories;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace Crito.Controllers
{
    public class SubscribeController : SurfaceController
    {
        private readonly SubscriberRepo _subscriberRepo;
        public SubscribeController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, SubscriberRepo subscriberRepo) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            this._subscriberRepo = subscriberRepo;
        }

        public async Task<IActionResult> Index(SubscribeForm subscribeForm)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            var subscribeFormSubmitted = await _subscriberRepo.GetDataAsync(x => x.Email == subscribeForm.Email);
            if (subscribeFormSubmitted == null)
            {
                await _subscriberRepo.AddDataAsync(subscribeForm);
                ModelState.AddModelError("", "Thank you for subscribing!");
                return CurrentUmbracoPage();

            }
            ModelState.AddModelError("", "You are already a subscriber");
            return CurrentUmbracoPage();
            //return LocalRedirect(contactForm.RedirectUrl ?? "/");
        }
    }
}
