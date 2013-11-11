using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSM
{
    class Enquete
    {
        #region Class variables

        private int iJa = 0;
        private int iNee = 0;
        private int iOnverschillig = 0;
        private int iCount = 0;
        private System.Drawing.Color iColor;
        
        #endregion

        #region Property's

        public int Ja
        {
            get { return iJa; }
            set { iJa = value; }
        }

        public int Nee { get { return iNee; } set { iNee = value; } }
        public int Onverschillig { get { return iOnverschillig; } set { iOnverschillig = value;} }
        public int Count { get { return iCount; } set { iCount = value; } }
        public System.Drawing.Color Color { get { return iColor; } }

        #endregion

        #region Methods

        public void Reset()
        {
            iJa = iNee = iOnverschillig = iCount = 0;
            iColor = System.Drawing.Color.Empty;
        }

        public string GeefWeer()
        {
            string test;

            if (iJa == iNee)
            {
                test = "onbepaald";
                iColor = System.Drawing.Color.Empty;
            }
            else if (iJa > iNee)
            {
                test = "toegestaan";
                iColor = System.Drawing.Color.Green;
            }
            else
            {
                test = "niet toegestaan";
                iColor = iColor = System.Drawing.Color.Red;
            }

           return "GSM-gebruik is "+ test + Environment.NewLine
                + "-#ja: " + iJa + Environment.NewLine
                + "-#nee: " + iNee + Environment.NewLine
                + "-#onverschillig: " + iOnverschillig;           
        }

        public bool IsBereikt()
        {
            int reken = iJa + iNee + iOnverschillig;
            if (reken == iCount)
            {
                return true;
            }
            return false;
        }

        public bool Verwerk(string invoer)
        {
            switch (invoer)
            {
                case "J": iJa += 1; return true;
                case "N": iNee += 1; return true;
                case "O": iOnverschillig += 1; return true;
                default: return false;
            }
        }

        #endregion
    }
}
