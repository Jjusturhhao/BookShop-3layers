using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class RuleBL
    {
        private RuleDL ruleDL;
        public RuleBL()
        {
            ruleDL = new RuleDL();
        }

        public List<TransferObject.Rule> GetRule()
        {
            return ruleDL.GetRule();
        }

        // Cập nhật rule
        public bool UpdateRule (TransferObject.Rule rule)
        {
            return ruleDL.UpdateRule(rule);
        }

        public string GetRuleValue(string ruleKey)
        {
            return ruleDL.GetRuleValue(ruleKey);
        }

        public List<Rule> SearchRules(string keyword)
        {
            try
            {
                return ruleDL.SearchRules(keyword);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
