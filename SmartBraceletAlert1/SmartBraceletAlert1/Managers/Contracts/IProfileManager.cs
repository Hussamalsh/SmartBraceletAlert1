using SmartBraceletAlert1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBraceletAlert1.Managers.Contracts
{
    public interface IProfileManager
    {
        void SaveProfile(Profile profile);

        Profile LoadProfile();
    }
}
