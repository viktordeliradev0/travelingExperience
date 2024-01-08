using Microsoft.AspNetCore.Mvc.Rendering;

namespace travelingExperience.Data
{
    public class Helper
    {
        public static string Admin = "Admin";
        public static string User = "User";
        public static List<SelectListItem> GetRolesForDropDown()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = Admin, Text = Admin },
                new SelectListItem { Value = User, Text = User }

            };
        }

    }
}
