using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Slnhelloworld
{
    public partial class findNum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int input = int.Parse(TextBox1.Text);
            int[] numList =new int[30];
            for (int i = 0; i < 30; i++)
            {
                byte[] randomBytes = new byte[4];
                RNGCryptoServiceProvider rngServiceProvider = new RNGCryptoServiceProvider();
                rngServiceProvider.GetBytes(randomBytes);
                Int32 iSeed = BitConverter.ToInt32(randomBytes, 0);
                Random random = new Random(iSeed);
                int anum = random.Next (1,100);
                if (!numList.Contains(anum))
                {
                    numList[i] = anum;
                }
                else
                {
                    i--;
                }
            }
            Response.Write("<br/>");
            for (int k = 0; k < numList.Length -1; k++)
            {
                for (int j = 0; j < 29 - k; j++)
                {
                    if (numList[j] > numList[j + 1])
                    {
                        int temp = numList[j];
                        numList[j] = numList[j + 1];
                        numList[j + 1] = temp;
                    }  
                }
            }
            for (int m = 0; m < numList.Length; m++)
                Response.Write(numList[m] + "&nbsp;");
            int beg = 0;
            int end = numList.Length;
            int mid;
            while (beg<=end)
            {
                mid = (beg + end) / 2;
                if (input==numList[mid])
                {
                    Response.Write("数字索引为" + mid);
                    return;
                }
                else if (input>numList[mid])
                {
                    beg = mid + 1;
                }
                else if (input<numList[mid])
                {
                    end = mid - 1;
                }
            }
            Response.Write("数字没找到！");

                
        }
    }
}