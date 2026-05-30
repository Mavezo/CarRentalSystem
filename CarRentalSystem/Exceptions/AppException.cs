using System;

namespace CarRentalSystem.Exceptions
{
    /// <summary>
    /// Represents an application-specific exception that can carry an HTTP status code
    /// and an optional error code for finer-grained handling by middleware or filters.
    /// </summary>
    public class AppException : Exception
    {
        /// <summary>
        /// HTTP status code to be returned to the client (defaults to 400 Bad Request).
        /// </summary>
        public int StatusCode { get; }

        /// <summary>
        /// Optional machine-friendly error code.
        /// </summary>
        public string? ErrorCode { get; }

        /// <summary>
        /// Optional longer human-friendly description of the error suitable for logs or UI.
        /// </summary>
        public string? Description { get; }

        public AppException(string message, int statusCode = 400, string? errorCode = null)
            : base(message)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode;
            Description = null;
        }

        public AppException(string message, Exception innerException, int statusCode = 400, string? errorCode = null)
            : base(message, innerException)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode;
            Description = null;
        }

        // New overloads that accept optional description
        public AppException(string message, string? description, int statusCode = 400, string? errorCode = null)
            : base(message)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode;
            Description = description;
        }

        public AppException(string message, Exception innerException, string? description, int statusCode = 400, string? errorCode = null)
            : base(message, innerException)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode;
            Description = description;
        }
    }
}
