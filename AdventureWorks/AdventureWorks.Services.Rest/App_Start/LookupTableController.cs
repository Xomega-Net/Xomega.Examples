using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Resources;
using Xomega.Framework.Lookup;

namespace AdventureWorks.Services.Rest
{
    public class LookupTableController : ControllerBase
    {
        private LookupCache globalCache;
        private ResourceManager resMgr;

        public LookupTableController(IServiceProvider serviceProvider, ResourceManager resourceManager)
        {
            if (serviceProvider == null) throw new ArgumentNullException(nameof(serviceProvider));
            globalCache = LookupCache.Get(serviceProvider, LookupCache.Global);
            resMgr = resourceManager ?? Messages.ResourceManager;
        }

        [Route("lookup-table/{id}")]
        [HttpGet]
        [AllowAnonymous]
        [ResponseCache(Duration = 30)]
        public ActionResult<LookupTable> Get(string id)
        {
            LookupTable tbl = globalCache.GetLookupTable(id);
            ObjectResult response = tbl != null ? (ObjectResult)Ok(tbl) :
                NotFound(string.Format(resMgr.GetString(Messages.LookupTableNotFound), id));
            return response;
        }

        [Route("lookup-table/{id}")]
        [HttpDelete]
        public void Delete(string id)
        {
            globalCache.RemoveLookupTable(id);
        }
    }
}