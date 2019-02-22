using Domain.Dangerouses.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dangerouses.Services
{
    public interface IDangerousesService
    {
          Task<string> GetAllNotificationsJSON();
    }
}
