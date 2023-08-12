using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public class InfoExchanger
    {
        private static int index;
        private static string selected_text = "";
        private static string text = "";

        public InfoExchanger()
        { }

        public int getIndex()
        {
            return index;
        }

        public string getSelectedText()
        {
            return selected_text;
        }

        public string getText()
        {
            return text;
        }

        public void setIndex(int ind)
        {
            index = ind;
        }

        public void setSelectedText(string st)
        {
            selected_text = st;
        }

        public void setText(string t)
        {
            text = t;
        }
    }
}
