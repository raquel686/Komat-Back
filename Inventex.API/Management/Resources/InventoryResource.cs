using Inventex.API.Security.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace Inventex.API.Management.Resources;

public class InventoryResource
{
    [SwaggerSchema("Inventory identifier")]
    public int Id { get; set; }
    [SwaggerSchema("Inventory Name")]
    public string Name { get; set; }
    [SwaggerSchema("Inventory Image")]
    public string Image { get; set; }
    [SwaggerSchema("Inventory Price")]
    public float Price { get; set; }
    [SwaggerSchema("Inventory Category")]
    public string Category { get; set; }

    [SwaggerSchema("Inventory User identifier")]
    public UserResource User { get; set; }
}