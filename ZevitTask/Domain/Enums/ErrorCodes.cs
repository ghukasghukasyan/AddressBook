namespace ZevitTask.Domain.Enums
{

    public enum ErrorCode
    {
        Unknown = 0,
        Validation = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        Conflict = 409,
        Internal = 500
    }
}
