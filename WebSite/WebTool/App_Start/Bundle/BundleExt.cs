namespace WebTool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Optimization;

    public static class BundleExt
    {
        public static System.Web.Optimization.Bundle IncludeWithCssRewriteUrlTransform(this StyleBundle bundle, params string[] virtualPaths)
        {
            foreach (var path in virtualPaths)
            {
                bundle.Include(path, new CssRewriteUrlTransform());
            }

            return bundle;
        }
    }
}