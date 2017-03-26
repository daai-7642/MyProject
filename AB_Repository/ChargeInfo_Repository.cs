﻿using AB_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Commom;
using Common;

namespace AB_Repository
{

    public class ChargeInfo_Repository
    {
        public List<ChargeInfo> GetChargeInfoPageList(int pageIndex, int pageSize, string where, string orderBy, out int rowCount)
        {
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@RowCount",SqlDbType.Int) { Direction=ParameterDirection.ReturnValue},
                new SqlParameter("@PageIndex",pageIndex),
                new SqlParameter("@PageSize",pageSize),
                new SqlParameter("@Where",where),
                new SqlParameter("@OrderBy",orderBy),

            };
            DataTable dt = SqlHelper.ExecuteDataset(SqlHelper.GetConnSting(), CommandType.StoredProcedure, "Pr_GetChargeInfoPageList", parms).Tables[0];
            rowCount = Convert.ToInt16(parms[0].Value);
            List<ChargeInfo> list = new List<ChargeInfo>();
            if (dt.Rows.Count != 0)
            {
                int num = 1;
                foreach (DataRow item in dt.Rows)
                {
                    ChargeInfo entity = new ChargeInfo();

                    entity.AccountBookId = Guid.Parse(item["AccountBookId"].ToString());
                    entity.ChargeTime1 = item["ChargeTime"].ToString();
                    entity.Money = decimal.Parse(item["Money"].ToString());
                    entity.Address = item["Address"].ToString();
                    entity.RelatedPeople = item["RelatedPeople"].ToString();
                    entity.RemarkInfo = item["RemarkInfo"].ToString();
                    entity.TypeName = item["Sys_Dic_Name"].ToString();
                    entity.Order = pageIndex * num;
                    num++;
                    list.Add(entity);
                }
            }

            return list;
        }
        public int AddChargeInfo(ChargeInfo charge)
        {
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Money",charge.Money),
                new SqlParameter("@ChargeTime",charge.ChargeTime),
                new SqlParameter("@Address",charge.Address),
                new SqlParameter("@RelatedPeople",charge.RelatedPeople),
                new SqlParameter("@TypeId",charge.TypeId),
                new SqlParameter("@RemarkInfo",charge.RemarkInfo),
                new SqlParameter("@CreateAuthor",charge.CreateAuthor)
            };
            int reval = SqlHelper.ExecuteNonQuery(SqlHelper.GetConnSting(), CommandType.StoredProcedure, "Pr_InsertChargeInfo", parms);
            return reval;
        }
    }
}