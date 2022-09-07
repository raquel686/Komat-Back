using System.Text.Json.Serialization;
using Inventex.API.Management.Domain.Models;

namespace Inventex.API.Security.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    [JsonIgnore]
    public string PasswordHash { get; set; }

    public IList<Inventory> Inventories { get; set; }

}