using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication7
{
    public class signup
    {

        public signup( String u, String p)
        {
            username = u;
            password = p;
        }

        public signup(String n, String u, String p, String g, String c, String dof) {
              name=n;
              username=u;
              password=p;
              gender=g;
              contactNo=c;
              DOB=dof;

        }

      public  String name;
        public String username;
        public String password;
        public String gender;
        public String contactNo;
        public String DOB;
    }
}
