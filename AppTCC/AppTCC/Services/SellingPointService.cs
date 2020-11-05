using AppTCC.Models;
using AppTCC.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppTCC.Services
{
    public class SellingPointService
    {
        public SellingPointRepository _sellingPointRepository = new SellingPointRepository();

        public Task<List<SellingPoints>> GetSellingPoints()
        {
            return _sellingPointRepository.GetSellingPoints();
        }
    }
}
