using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PFFind
{
    public class FIndexFunds
    {
        public List<string> Funds { get; set; }
        public FIndexFunds()
        {
            this.Funds = new List<string>();
        }

        public bool Find(PFFind.data data)
        {
            return FoundFIndexFunds(data);
        }

        //Is it a Fidelity Index Fund
        //They all start with capital F and have 5 characters
        private bool FoundFIndexFunds(PFFind.data data)
        {
            string FIndexPattern = @"\bF\w*[A-Z]{4}\b";
            Regex rgx = new Regex(FIndexPattern, RegexOptions.IgnoreCase);
            MatchCollection matches_title = rgx.Matches(data.title);
            MatchCollection matches_text = rgx.Matches(data.selftext);

            //First match, check title
            if (matches_title.Count > 0)
            {
                foreach (Match m in matches_title)
                    if (!Funds.Contains(m.Value.ToUpper())) this.Funds.Add(m.Value.ToUpper());
            }
            //Second match, check text
            if (matches_text.Count > 0)
            {
                foreach (Match m in matches_text)
                    if (!Funds.Contains(m.Value.ToUpper())) this.Funds.Add(m.Value.ToUpper());
            }
            return this.Funds.Count > 0 ? true : false;
        }
    }
}
