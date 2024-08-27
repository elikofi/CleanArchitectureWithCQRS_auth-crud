
namespace Application.Common.Constants
{
    public static class ConstantResponses
    {
        //Registration constants
        public const string RegisteredSuccessfully = "User Registered Successfully.";
        public const string FailedRegistration = "Failed to register user:";

        //Role management constants
        public const string UsernameNotFound = "The username provided doesn't exist.";
        public const string NewAdmin = " is now an Admin.";
        public const string NewSuperAdmin = " is now a SuperAdmin.";
        public const string NewSuperUser = " is now a SuperUser.";
        public const string UserNotFound = " User not found.";

        //Users
        public const string NoUsersInDB = "There are currently no users in the database.";

        //Blog responses.

        public const string UnableToCreateBlog = "Error occured, unable to create blog.";
        public const string UnableToDeleteBlog = "Error occured, unable to delete blog.";
        public const string UnableToUpdateBlog = "Error occured, unable to update blog.";
        public const string UnableToGetBlog = "Error occured, unable to get blog.";
        public const string EmptyBlogList = "There are currently no blogs in the database.";
        public const string BlogNotFound = "Blog not found.";
    }
}
