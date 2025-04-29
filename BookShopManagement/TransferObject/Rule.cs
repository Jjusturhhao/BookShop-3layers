using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Rule
    {
        public string RuleKey { get; set; }
        public string RuleValue { get; set; }

        public Rule() { }

        public Rule(string key, string value)
        {
            RuleKey = key;
            RuleValue = value;
        }
    }
}
