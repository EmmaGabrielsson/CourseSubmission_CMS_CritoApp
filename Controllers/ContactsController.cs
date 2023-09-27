using Crito.Models;
using Crito.Repositories;
using Crito.Services;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace Crito.Controllers;

public class ContactsController : SurfaceController
{
    private readonly ContactFormRepo _contactRepo;

    public ContactsController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, ContactFormRepo contactRepo) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
    {
        _contactRepo = contactRepo;
    }

    [HttpPost]
    public async Task<IActionResult> Index(ContactForm contactForm)
    {
        if(!ModelState.IsValid)
            return CurrentUmbracoPage();


        using var _mail = new MailService("no-reply@crito.com", "smtp.crito.com", 587, "contactform@crito.com", "BytMig123!");
        //to sender
        _mail.SendAsync(contactForm.Email, "Your contact request was recieved.", "Hi, your request was recieved and we will be in contact with you as soon as possible.").ConfigureAwait(false);

        //to us
        _mail.SendAsync("umbraco@crito.com", $"{contactForm.Name} sent a contact request.", contactForm.Message).ConfigureAwait(false);

        var contactFormSubmitted = await _contactRepo.GetDataAsync(x => x.Name == contactForm.Name && x.Email == contactForm.Email && x.Message == contactForm.Message);
        if (contactFormSubmitted == null)
        {
            await _contactRepo.AddDataAsync(contactForm);
            ModelState.AddModelError("", "Thank you for contacting us, we get back to you as soon as possible!");
            return CurrentUmbracoPage();

        }
        ModelState.AddModelError("", "You have already sent this contact-form to us");
        return CurrentUmbracoPage();
        //return LocalRedirect(contactForm.RedirectUrl ?? "/");
    }
}
