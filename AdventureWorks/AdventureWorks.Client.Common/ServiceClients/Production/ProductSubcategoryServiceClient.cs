//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "REST Service Clients" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xomega.Framework.Services;

namespace AdventureWorks.Services
{
    ///<summary>
    /// Product subcategories. See ProductCategory table.
    ///</summary>
    public class ProductSubcategoryServiceClient : HttpServiceClient, IProductSubcategoryService
    {
        protected readonly JsonSerializerOptions SerializerOptions;

        public ProductSubcategoryServiceClient(HttpClient httpClient, IOptionsMonitor<JsonSerializerOptions> options)
            : base(httpClient)
        {
            SerializerOptions = options.CurrentValue;
        }

        /// <inheritdoc/>
        public virtual async Task<Output<ICollection<ProductSubcategory_ReadListOutput>>> ReadListAsync()
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, $"product-subcategory");
            using (var resp = await Http.SendAsync(msg, HttpCompletionOption.ResponseHeadersRead))
            {
                var content = await resp.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Output<ICollection<ProductSubcategory_ReadListOutput>>>(content, SerializerOptions);
            }
        }
    }
}