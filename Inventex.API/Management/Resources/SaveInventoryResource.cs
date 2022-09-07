using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace Inventex.API.Management.Resources;

[SwaggerSchema(Required = new []{"Name"})]
public class SaveInventoryResource
{
    [Required]
    [MaxLength(50)]
    [SwaggerSchema("Inventory Name")]
    public string Name { get; set; }
    
    [SwaggerSchema("Inventory Image")]
    public string Image { get; set; }
    
    [SwaggerSchema("Inventory Price")]
    public float Price { get; set; }
    
    [MaxLength(50)]
    [SwaggerSchema("Inventory Category")]
    public string Category { get; set; }

    [Required]
    [SwaggerSchema("Inventory User Name")]
    public int UserId { get; set; }
}