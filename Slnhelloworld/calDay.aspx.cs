using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Slnhelloworld
{
    public partial class calDay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            string date = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
            string[] dateArray = date.Split('-');
            int year = int.Parse(dateArray[0]);
            int month = int.Parse(dateArray[1]);
            int day = int.Parse(dateArray[2]);
            int[] bigMonth = { 1, 3, 5, 7, 8, 10, 12 };
            int daytime = 0;
            for (int i = 1; i < month; i++)
            {
                if (i == 2)
                {
                    if ((year % 100 != 0 && year % 4 == 0) || (year % 400 == 0))
                        daytime += 29;
                    else
                        daytime += 28;
                }
                else if (bigMonth.Contains(i))
                    daytime += 31;
                else
                    daytime += 30;
            }
            daytime += day;
            Label1.Text = String.Format("{0}年{1}月{2}日是该年的第{3}天。", year, month, day, daytime);
        }
    }
}