using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.BAL
{
    public static class LoginHelper
    {
        public static bool IsValidUser(LoginDTOIn userCredetials)
        {
            try
            {
                using (POCDB_testContext pOCDB_testContext = new POCDB_testContext())
                {
                    return pOCDB_testContext.UserInfo.Any(x => (string.Equals(x.UserId, userCredetials.Email) && (string.Equals(x.password, userCredetials.Password))));
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }            
           
        }

    }
}
