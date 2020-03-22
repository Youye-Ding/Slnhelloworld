using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Slnhelloworld
{
    public partial class calLoan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //先还本金后计利息
            double loan = double.Parse(TextBox1.Text);
            double rate = 0.04 / 12;
            int month = 0;
            double pay = 0;
            double leftloan = loan;
            double interest = 0;
            while (leftloan >= 7500)
            {
                leftloan = (leftloan - 7500) * (1 + rate);
                month += 1;
            }
            pay = month * 7500 + leftloan;
            interest = pay - loan;
            Label1.Text = string.Format("您需要向银行还贷{0}个月，总共还款{1}元，其中除了本金之外，向银行还利息共计{2}元，最后一个月需要还款{3}元。", month + 1, pay, interest, leftloan);
        }
    }
}