using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTechAdviser
{
    public class BuildSearchQuery
    {
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(BuildSearchQuery)); 

        public string BuildQuery(string projectName, string particularSearch, NTechAdviser.Forms.SearchModeEnum searchModeEnum)
        {
            string templateString = string.Empty;
            if (searchModeEnum == NTechAdviser.Forms.SearchModeEnum.DebitData)
            {
                templateString = "select * from accounts_info where ";
            }
            else
            {
                templateString = "select * from stock_info where ";
            }
            string retVal = string.Empty;

            List<string> attribs = new List<string>();

            if (!string.IsNullOrEmpty(projectName))
                attribs.Add(string.Format("Project like '%{0}%'", projectName));

            if (!string.IsNullOrEmpty(particularSearch))
                attribs.Add(string.Format("Particulars like '%{0}%'", particularSearch));

            if (attribs != null && attribs.Count > 0)
            {
                string aggregatedStr = string.Empty;
                int i = 0;
                foreach (string attrib in attribs)
                {
                    if (i != 0)
                        aggregatedStr = aggregatedStr + " AND " + attrib;
                    else
                        aggregatedStr = aggregatedStr + attrib;

                    i++;
                }
                retVal = templateString + aggregatedStr + " order by DateCreated";
            }

            return retVal;
        }
    }
}
