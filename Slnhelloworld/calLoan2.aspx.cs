using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Slnhelloworld
{
    public partial class calLoan2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //等额本金
            double loan = 1000000;
            int deadLine = 36;
            double rate = 0.049/12;
            double interest = 0;
            for (int month = 0; month <= deadLine - 1; month++)
                interest += (loan - month * loan / deadLine) * rate;
            Response.Write(String.Format("共计支付本息{0}元，其中利息{1}元。", loan + interest, interest));

            //等额本息
            double loan1 = loan * Math.Pow(1 + rate, deadLine);
            double krate = 0;
            for (int i = 0; i < deadLine; i++)
                krate += Math.Pow(1 + rate, i);
            double pay = loan1 / krate;
            Response.Write(String.Format("每月支付金额{0}元，共计支付本息{1}元，其中利息{2}元。", pay, pay*deadLine,pay*deadLine - loan));

        }
    }
}