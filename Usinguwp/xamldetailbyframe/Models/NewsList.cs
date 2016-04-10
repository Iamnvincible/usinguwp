using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace xamldetailbyframe.Models
{
    public class NewsList
    {
        public List<News> List { get; set; } = new List<News>();

        public NewsList()
        {
            if (DesignMode.DesignModeEnabled)
                LoadDesignTimeData();
            else
                LoadDesignTimeData();
        }

        private void LoadDesignTimeData()
        {
            for (int i = 0; i < 100; i++)
            {
                List.Add(new News()
                {
                    Id = i,
                    Name = "News " + i,
                    Content = "FastMasterDatail Demo " + i
                });
            }
        }
    }
}
