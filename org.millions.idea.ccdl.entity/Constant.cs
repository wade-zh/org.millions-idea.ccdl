using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace org.millions.idea.ccdl.entity
{
    public class Constant
    {
        public static String BaseDir { get {
                var baseDir = Directory.GetCurrentDirectory();
                var appName = "org.millions.idea.ccdl.train";
                return baseDir.Substring(0, baseDir.IndexOf(appName));
            } }

        public static String Dependencies { get; } = BaseDir + "org.millions.idea.ccdl.dependencies\\";
        public static String CCFramework { get; } = Dependencies + "CC3.1-alpha.7\\";
    }
}
