using System;
using System.Resources;

namespace AdventureWorks.Client.Web
{
    /// <summary>
    /// Message codes, as well as a resource manager to get a (localized) message text for those.
    /// </summary>
    public static class Messages
    {
        private static readonly Lazy<ResourceManager> resourceManager =
            new Lazy<ResourceManager>(() => new ResourceManager("AdventureWorks.Client.Web.Resources", typeof(Messages).Assembly));

        /// <summary>
        /// Resource manager for the current messages.
        /// </summary>
        public static ResourceManager ResourceManager
        {
            get { return resourceManager.Value; }
        }

        /// <summary>
        /// You are not authorized to view this page.
        /// </summary>
        public const string PageNotAuthorized = "PageNotAuthorized";
    }
}
