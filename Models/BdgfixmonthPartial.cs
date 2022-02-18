using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetStatus.Models
{
    public partial class Bdgfixmonth
    {
        //classe parziale, estendono la classe principale
        //si usa per non doverla toccare, altrimenti con nuove migrations EF eliminerà tutte le modifiche apportate
        public int NumericMonth 
        {
            get
            {
                    if (Blongmonth == "January")
                    {
                        return  1;
                    }
                    else if (Blongmonth == "February")
                    {
                        return 2;
                    }
                    else if (Blongmonth == "March")
                    {
                        return 3;
                    }
                    else if (Blongmonth == "April")
                    {
                        return 4;
                    }
                    else if (Blongmonth == "May")
                    {
                        return 5;
                    }
                    else if (Blongmonth == "June")
                    {
                        return 6;
                    }
                    else if (Blongmonth == "July")
                    {
                        return 7;
                    }
                    else if (Blongmonth == "August")
                    {
                        return 8;
                    }
                    else if (Blongmonth == "September")
                    {
                        return 9;
                    }
                    else if (Blongmonth == "October")
                    {
                        return 10;
                    }
                    else if (Blongmonth == "November")
                    {
                        return 11;
                    }
                    else if (Blongmonth == "December")
                    {
                        return 12;
                    }
                    else
                    {
                        return 0;
                    }
            
            } 
        }





        //NON UTILIZZATO, WORKAROUND NELLA VIEW
        public string WordOpenClosed 
        {
            get
            {
                if (Closed == 0)
                {
                    return "Open";
                }
                else if (Closed == 1)
                {
                    return "Closed";
                }
                else
                {
                    return "No state available";
                }
            } 
        }

    }
}
