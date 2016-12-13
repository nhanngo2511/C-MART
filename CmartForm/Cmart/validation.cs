using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Cmart
{
    class validation
    {

        public bool Required(TextBox t)
        {
            string a = t.Text.ToString();
            if (string.IsNullOrEmpty(a) || string.IsNullOrWhiteSpace(a))
            {
                return false;
            }
            else
                return true;
        }
        public bool MaxLength(int max, string data)
        {
            if (data.Length > max)
            {
                return false;
            }
            return true;
        }
        public bool MinLength(int min, string data)
        {
            if (data.Length < min)
            {
                return false;
            }
            return true;
        }
        public bool Range(int max, int min, int data)
        {
            if (min == max)
            {
                if (data < min)
                {
                    return false;
                }
            }
            else if (data < min || data > max)
            {
                return false;
            }
            return true;
        }
        public bool RangeMoney(float min, float data)
        {

            if (data < min)
            {
                return false;
            }
            return true;
        }

        public bool Compare(string a, string b)
        {
            if (a.Equals(b))
            {
                return true;
            }
            return false;
        }
        public bool checkNumber(string tx )
        {
            float distance;
            if (float.TryParse(tx, out distance))
            {
                return true;
            } else return false;
        }
        public bool checkSpecialCharater(string s)
        {
            var withoutSpecial = new string(s.Where(c => Char.IsLetterOrDigit(c)
                                            || Char.IsWhiteSpace(c)).ToArray());
            if (s!=withoutSpecial)
            {
                return true;
            }
            return false;
        }
        public bool compareDate(DateTime start,DateTime end)
        {
            if (start < end)
            {
                return true;
            }
            return false;
        }
    }
}
