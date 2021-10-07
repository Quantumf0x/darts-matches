using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Darts_matches.Models;

namespace Darts_matches.Controllers
{
    public class MatchController
    {
        private static MatchController _instance;

        public static MatchController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MatchController();
                }
                return _instance;
            }
        }

        public void SetMatchInputPageValues(string name, DateTime date)
        {
            Debug.WriteLine(name + " en " + date);
            //MatchInputPage matchInputPage = new MatchInputPage();
            //string name = matchInputPage.MatchName;
            //DateTime date = matchInputPage.Date;

            //Match match = new Match(name, );
        }
    }
}
