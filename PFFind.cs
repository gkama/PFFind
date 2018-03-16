using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http;

using Newtonsoft.Json;

namespace PFFind
{
    public class PFFind
    {
        private List<data> Data { get; set; }

        public PFFind()
        {
            this.Data = new List<data>();
            this.GetData();
        }

        //Find posts on PF
        private async void GetData()
        {
            var appSettings = ConfigurationManager.AppSettings;
            try
            {

                //Unit test
                FIndexFunds findexfunds = new FIndexFunds(UnitTest.FIndexFund());
                FIndexFunds findexfunds_2 = new FIndexFunds(UnitTest.FIndexFund_2());
                Console.WriteLine(findexfunds.ToString());
                Console.WriteLine("Incorrect test======");
                Console.WriteLine(findexfunds_2.ToString());
                //==========================================

                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(appSettings["pf_url"]);

                //Serialize the json and loop through it
                dynamic jsonObj = JsonConvert.DeserializeObject(response);
                foreach (var obj in jsonObj.data.children)
                {
                    if (obj.data.author != "AutoModerator")
                    {
                        data _data = new data()
                        {
                            id = obj.data.id,
                            title = obj.data.title,
                            score = obj.data.score,
                            url = obj.data.url,
                            num_comments = obj.data.num_comments,
                            subreddit_id = obj.data.subreddit_id,
                            selftext = obj.data.selftext
                        };
                        this.Data.Add(_data);
                    }
                }
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }


        public List<data> Find(string searchFor)
        {
            List<data> toReturn = new List<data>();
            if (this.Data.Count == 0) return toReturn;
            foreach (data d in this.Data)
            {
                //If the title contains what we are looking for
                //Instantly store it
                if (d.title.Contains(searchFor, StringComparison.CurrentCultureIgnoreCase))
                    toReturn.Add(d);
                //Else if does not, check the text itself
                else if (d.selftext.Contains(searchFor, StringComparison.CurrentCultureIgnoreCase))
                    toReturn.Add(d);
            }
            return toReturn;
        }


        public class data
        {
            public string id { get; set; }
            public string title { get; set; }
            public int score { get; set; }
            public string url { get; set; }
            public int num_comments { get; set; }
            public string subreddit_id { get; set; }

            private string _selfText;
            private string _selfFullText;
            public string selftext
            {
                get { return _selfFullText.Length >= 1000 ? _selfFullText : _selfText; }
                set
                {
                    //Set only first 1000 characters
                    this._selfText = value.Length <= 1000 ? value : value.Substring(0, 1000);
                    this._selfFullText = value;
                }
            }
            
        }
    }
}
