using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFKPKSoftwareSolutionsTask1
{
    public class MenuApp
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string ImageFullPath { get; set; }

        public MenuApp(string name, string path)
        {
            Name = name;
            ImagePath = path;
            ImageFullPath = "C:\\Users\\nikit\\source\\repos\\WPFKPKSoftwareSolutionsTask1\\WPFKPKSoftwareSolutionsTask1\\" + path;
        }
    }
}
