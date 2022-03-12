using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ToysStore.Models
{
    public class UserTabel
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }


        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password required")]
        public string Userpassword { set; get; }


        [Display(Name = "Confirm new password")]
        [Required(ErrorMessage = "Enter Confirm Password")]
        [Compare("Userpassword", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        public string c_pwd { get; set; }
    }
    public class savedata
    {
        public void insertuser(UserTabel ut)
        {
            DataAccess.DataClasses_ToysStoreDataContext db = new DataAccess.DataClasses_ToysStoreDataContext();
            DataAccess.User_Table sa = new DataAccess.User_Table();

            sa.ID = ut.id;
            sa.UserName = ut.UserName;
            sa.Email = ut.Email;
            sa.UserPassword = ut.Userpassword;

            db.User_Tables.InsertOnSubmit(sa);
            db.SubmitChanges();

        }
    }
        public class Searchuser
        {

            public string searchk(UserTabel li)
            {

                DataAccess.DataClasses_ToysStoreDataContext db = new DataAccess.DataClasses_ToysStoreDataContext();
                DataAccess.User_Table rs = new DataAccess.User_Table();
                string passout = "";
                // var pass = from m in db.registers where m.emailid == li.Emailid select m.userpassword;  
                var pass = from m in db.User_Tables where m.Email == li.Email select m.UserPassword;
                foreach (string query in pass)
                {
                    passout = query;

                }
                return passout;

            }
        }
    }



        

    
