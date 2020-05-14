using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataPractice
{
    public partial class HomeworkMonteCarloFootball : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Nigeria = 3;
            int Iceland = 1;
            int Argentina = 1;
            int num = 100000;
            //出线场次
            double SuccessNig = 0;
            double SuccessIce = 0;
            double SuccessArg = 0;
            //出线概率
            double PossibleNig, PossibleIce, PossibleArg;
            int FirstGame;
            int SecondGame;
            Random rand = new Random();
            for (int i=0;i<num;i++)
            {
                FirstGame = rand.Next(0, 3);
                SecondGame = rand.Next(0, 3);
                if (FirstGame==0)
                {
                    Nigeria += 3;
                }
                else if (FirstGame==1)
                {
                    Nigeria += 1;
                    Argentina += 1;
                }
                else
                {
                    Argentina += 3;
                }

                if (SecondGame == 0)
                {
                    Iceland += 3;
                }
                else if (SecondGame == 1)
                {
                    Iceland += 1;
                }
                //开始计算出线场次
                if (Nigeria==6)
                {
                    SuccessNig += 1;
                }
                else if (Nigeria==4)
                {
                    if (Iceland==4)
                    {
                        SuccessNig += 0.5;
                        SuccessIce += 0.5;
                    }
                    else
                    {
                        SuccessNig += 1;
                    }
                }
                else
                {
                    if (Iceland == 4)
                    {
                        SuccessArg += 0.5;
                        SuccessIce += 0.5;
                    }
                    else
                    {
                        SuccessArg += 1;
                    }
                }
                //重置
                Nigeria = 3;
                Iceland = 1;
                Argentina = 1;
            }
            PossibleNig = SuccessNig / num;
            PossibleIce = SuccessIce / num;
            PossibleArg = SuccessArg / num;
            Response.Write("尼日利亚出线概率为" + PossibleNig + "。</br>");
            Response.Write("冰岛出线概率为" + PossibleIce + "。</br>");
            Response.Write("阿根廷出线概率为" + PossibleArg + "。</br>");
        }
    }
}