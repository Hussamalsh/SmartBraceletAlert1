using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBraceletAlert1.Models
{
    public class Profile
    {
        public string Username
        {
            get;
            set;
        }

        public string FBusername
        {
            get;
            set;
        }

        public string FBimage
        {
            get;
            set;
        }

        public string Firstname
        {
            get;
            set;
        }

        public bool NotifyNews
        {
            get;
            set;
        }

        public bool NotifyFriends
        {
            get;
            set;
        }
    }
}
