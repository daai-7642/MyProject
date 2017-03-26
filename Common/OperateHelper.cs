using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class OperateHelper
    {
        public static string GetConnString
        {
            get { return System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString; }
        }
        public static int GetPageSize
        {
            get { return int.Parse(ConfigurationSettings.AppSettings["PageSize"]); }
        }
        public static string GetXmlSqlString(string xmlNodeName)
        {
            return ReadXmlHelper.GetXmlValue(System.Web.HttpContext.Current.Server.MapPath("~/Config/SQLXml.xml"), xmlNodeName);
        }
        public static string GetXmlSqlString(string xmlNodeName, bool IsReplace)
        {
            return ReadXmlHelper.GetXmlValue(System.Web.HttpContext.Current.Server.MapPath("~/Config/SQLXml.xml"), xmlNodeName, IsReplace);
        }
        public static string GetThisFullMethodName()
        {
            System.Reflection.MethodBase method = new System.Diagnostics.StackFrame(1).GetMethod();
            return method.ReflectedType.Name + "." + method.Name;
        }
        public static string GetThisClassName()
        {
            System.Reflection.MethodBase method = new System.Diagnostics.StackFrame(1).GetMethod();
            return method.ReflectedType.Name + ".";
        }
       
    }
}
