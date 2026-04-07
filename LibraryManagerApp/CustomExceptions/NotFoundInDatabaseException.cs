namespace LibraryManagerApp.Exceptions
{
    public class NotFoundInDatabaseException : Exception
    {

        public NotFoundInDatabaseException(string message) : base(message)
        {

        }
    }
}
