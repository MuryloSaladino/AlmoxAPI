namespace Almox.API.Middlewares.AuthorizeAdmin;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
public class AuthorizeAdminAttribute : Attribute { }