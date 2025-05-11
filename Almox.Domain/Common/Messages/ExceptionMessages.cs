namespace Almox.Domain.Common.Messages;

public static class ExceptionMessages
{
    public static class BadRequest
    {
        public const string Default = "Bad request.";
        public const string Format = "The request was not built correctly or contains invalid fields.";
    }

    public static class Unauthorized
    {
        public const string Default = "Unauthorized.";
        public const string Session = "Invalid user session, you must login first.";
        public const string Token = "Invalid bearer token provided in header.";
        public const string MissingToken = "Missing bearer token in authorization header.";
        public const string Credentials = "Credentials do not match or incorrect password.";
    }

    public static class Forbidden
    {
        public const string Default = "Forbidden.";
        public const string Admin = "You dot not own enough permission. You must be an admin to perform this.";
        public const string NotOwnUser = "You must reference a object owned by you or be an admin to perform this.";
    }

    public static class NotFound
    {
        public const string Default = "Not Found.";
        public const string User = "User not found.";
        public const string Category = "Category not found.";
        public const string Department = "Department not found.";
        public const string Item = "Item not found.";
        public const string Request = "Request not found.";
    }

    public static class InternalServerError
    {
        public const string Default = "Internal Server Error.";
    }

    public static class NotImplemented
    {
        public const string Default = "Not Implemented.";
    }
}