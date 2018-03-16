using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFFind
{
    public static class UnitTest
    {
        //Index fund test case
        public static PFFind.data FIndexFund()
        {
            PFFind.data data = new PFFind.data()
            {
                title = "This is a test",
                score = 4000,
                url = "https://test.com/",
                num_comments = 100,
                subreddit_id = "subreddit_id",
                selftext = "this is where the real test is FUSVX, then there is this FSEVX"
            };
            return data;
        }
        public static PFFind.data FIndexFund_2()
        {
            PFFind.data data = new PFFind.data()
            {
                title = "This is a test to not find index funds",
                score = 4000,
                url = "https://test.com/",
                num_comments = 100,
                subreddit_id = "subreddit_id",
                selftext = "this is where the real test is FUSV (this is incorrect), then there is this fsevx (this is correct length"
                            + " but not capitalized)"
            };
            return data;
        }
    }
}
