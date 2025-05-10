namespace Almox.API.Middlewares.AuthorizeOwnUserOrAdmin;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
public class AuthorizeOwnUserOrAdminAttribute(string routeIdentifier = "id") : Attribute 
{
    public string RouteIdentifier = routeIdentifier;
}