using AB_Entity;
using AB_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB_Logic
{
    public class ChargeInfo_Logic
    {
        ChargeInfo_Repository chargeInfoRepository = new ChargeInfo_Repository();
        public List<ChargeInfo> GetChargeInfoPageList(int pageIndex, int pageSize, string where, string orderBy, out int rowCount)
        {
            return chargeInfoRepository.GetChargeInfoPageList(pageIndex,pageSize,where,orderBy,out rowCount);
        }
        public int AddChargeInfo(ChargeInfo charge)
        {
            return chargeInfoRepository.AddChargeInfo(charge);
        }
        }
}
