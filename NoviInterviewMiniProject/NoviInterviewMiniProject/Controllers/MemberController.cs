using NoviInterviewMiniProject.Models.ViewModels;
using NoviInterviewMiniProject.Repositories;
using System.Linq;
using System.Web.Mvc;

namespace NoviInterviewMiniProject.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberRepository _memberRepository;

        public MemberController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        [HttpGet]
        public ActionResult Index(string search = "", string sortOn = "NAME", bool isAsc = false)
        {
            // get all items and map to item models. These filter out in active items in repo
            var items = _memberRepository.GetAll().Select(x => new MemberItemViewModel(x));

            // if no search then ignore this filter
            if (!string.IsNullOrEmpty(search))
            {
                items = items.Where(x => x.Name.Contains(search));
            }

            // perform sorting switch 
            switch (sortOn.ToUpper())
            {
                case "NAME":
                    items = isAsc ? items.OrderBy(x => x.Name) : items.OrderByDescending(x => x.Name);
                    break;
                case "MEMBERTYPE":
                    items = isAsc ? items.OrderBy(x => x.MemberType) : items.OrderByDescending(x => x.MemberType);
                    break;
                case "EMAIL":
                    items = isAsc ? items.OrderBy(x => x.Email) : items.OrderByDescending(x => x.Email);
                    break;
                case "PHONE":
                    items = isAsc ? items.OrderBy(x => x.Phone) : items.OrderByDescending(x => x.Phone);
                    break;
                case "MOBILE":
                    items = isAsc ? items.OrderBy(x => x.Mobile) : items.OrderByDescending(x => x.Mobile);
                    break;
                default:
                    items = isAsc ? items.OrderBy(x => x.Name) : items.OrderByDescending(x => x.Name);
                    break;
            }

            // map model
            var model = new MembersIndexViewModel
            {
                TableModel = new Models.TableModel
                {
                    IsAsc = isAsc,
                    SortOn = sortOn,
                    Search = search
                },
                MemberRows = items
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            // get member by id and map it to view model.
            var member = _memberRepository.GetByID(id);
            return PartialView(new MemberDetailsViewModel(member));
        }
    }
}