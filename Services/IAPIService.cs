using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWPF.DTOs;

namespace TestWPF.Services
{
    public interface IAPIService
    {
        Task<LoginDTO> GetAPIService(string login, string password);
    }
}
