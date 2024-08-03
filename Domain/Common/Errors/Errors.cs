using ErrorOr;

namespace Domain.Common.Errors
{
    public static partial class Errors
    {
        //Blog errors
        public static class BlogError
        {
            public static Error DuplicateBlogName => Error.Conflict(code: "Blog.DuplicateName", description: "Blog with this name already exists.");
        }

        public static class UserError
        {
            public static Error DuplicateEmail => Error.Conflict(code: "User.DuplicateEmail", description: "User with this Email already exists.");
            public static Error DuplicateUsername => Error.Conflict(code: "User.DuplicateUsername", description: "User with this Username already exists.");
            public static Error WrongUsername => Error.Conflict(code: "User.v", description: "The username entered doesn't exists.");

        }
    }
}
