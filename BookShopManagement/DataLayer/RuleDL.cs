using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class RuleDL:DataProvider
    {
        public List<TransferObject.Rule> GetRule()
        {
            List<TransferObject.Rule> rules = new List<TransferObject.Rule>();
            string query = "SELECT RuleKey, RuleValue FROM Rules";

            DataTable dt = ExecuteQuery(query); 

            foreach (DataRow row in dt.Rows)
            {
                rules.Add(new TransferObject.Rule
                {
                    RuleKey = row["RuleKey"].ToString(),
                    RuleValue = row["RuleValue"].ToString()
                });
            }

            return rules;
        }

        public bool UpdateRule(TransferObject.Rule rule)
        {
            string query = "UPDATE Rules SET RuleValue = @RuleValue WHERE RuleKey = @RuleKey";
            SqlCommand cmd = new SqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@RuleValue", rule.RuleValue);
            cmd.Parameters.AddWithValue("@RuleKey", rule.RuleKey);

            return MyExecuteNonQuery(cmd) > 0;
        }

        public string GetRuleValue(string ruleKey)
        {
            string query = "SELECT RuleValue FROM Rules WHERE RuleKey = @RuleKey";
            SqlCommand cmd = new SqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@RuleKey", ruleKey);

            object result = MyExecuteScalar(cmd);
            return result?.ToString();
        }

        public List<TransferObject.Rule> SearchRules(string keyword)
        {
            string sql = "SELECT * FROM Rules WHERE RuleKey LIKE @kw";
            List<TransferObject.Rule> rules = new List<TransferObject.Rule>();
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rules.Add(new TransferObject.Rule(
                        reader["RuleKey"].ToString(),
                        reader["RuleValue"].ToString()
                    ));
                }
                reader.Close();
                return rules;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }
    }
}

