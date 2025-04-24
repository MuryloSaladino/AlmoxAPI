namespace Almox.API.Middlewares.Authorize;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
public class AuthorizeAttribute : Attribute { }