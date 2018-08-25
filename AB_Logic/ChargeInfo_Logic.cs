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
        ChargeInfo_Repository chargeInfoRepository = null;
        public ChargeInfo_Logic(string _connstr)
        {
            chargeInfoRepository = new ChargeInfo_Repository(_connstr);
        }
        public ChargeInfo_Logic()
        {
              chargeInfoRepository = new ChargeInfo_Repository();
        }

        public List<ChargeInfo> GetChargeInfoPageList(int pageIndex, int pageSize, string where, string orderBy, out int rowCount)
        {
            return chargeInfoRepository.GetChargeInfoPageList(pageIndex, pageSize, where, orderBy, out rowCount);
        }
        public int AddChargeInfo(ChargeInfo charge)
        {
            return chargeInfoRepository.AddChargeInfo(charge);
        }
    }
}
