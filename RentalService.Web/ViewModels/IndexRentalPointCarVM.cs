using RentalService.Web.ViewModels.Filters;
using System.Collections.Generic;

namespace RentalService.Web.ViewModels
{
    public class IndexRentalPointCarVM
    {
        public RentalPointCarFilterVM Filter { get; set; }
        public IEnumerable<RentalPointCarVM> Cars { get; set; }
    }
}
