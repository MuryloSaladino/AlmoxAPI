namespace Almox.API.Middlewares.AuthorizeOwnUserOrAdmin;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
public class AuthorizeOwnUserOrAdminAttribute(Guid id) : Attribute 
{
    public Guid UserId = id;
}