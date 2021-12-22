using HandInManagerApp.Application.Infrastructure;
using HandInManagerApp.Application.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HandInManagerApp.Webapp.Pages.Teams
{
    public class IndexModel : PageModel
    {
        private readonly HandInContext _db;
        public List<Team> Teams { get; private set; } = new();
        public IndexModel(HandInContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Teams = _db.Teams.OrderBy(t => t.Name).ToList();
        }
    }
}
