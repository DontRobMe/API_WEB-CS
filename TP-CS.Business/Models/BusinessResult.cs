namespace TP_CS.Business.Models
{
    public class BusinessResult
    {
        public bool IsSuccess { get; set; }
        public BusinessError? Error { get; set; }

        public BusinessResult()
        {
        }

        protected BusinessResult(bool isSuccess, BusinessError? error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static BusinessResult FromSuccess(BusinessResult<User> businessResult)
        {
            return new BusinessResult(true, null);
        }

        public static BusinessResult FromError(string errorMessage, BusinessErrorReason reason)
        {
            BusinessError error = new(errorMessage, reason);
            return new BusinessResult(false, error);
        }

        public static BusinessResult FromSuccess(BusinessResult<UserTask> businessResult)
        {
            return new BusinessResult(true, null);
        }

        public static BusinessResult FromSuccess(BusinessResult<Team> businessResult)
        {
            return new BusinessResult(true, null);
        }

        public static BusinessResult FromSuccess(BusinessResult<Tag> businessResult)
        {
            return new BusinessResult(true, null);
        }

        public static BusinessResult FromSuccess(Team businessResult)
        {
         return new BusinessResult(true, null);
        }

        public static BusinessResult FromSuccess(Tag businessResult)
        {
            return new BusinessResult(true, null);
        }

        public static BusinessResult FromSuccess(BusinessResult<Project> existingProject)
        {
            return new BusinessResult(true, null);
        }

        public static BusinessResult FromSuccess()
        {
            return new BusinessResult(true, null);
        }
    }

    public class BusinessResult<T> : BusinessResult // Hérite du résultat sans retour
    {
        public T? Result { get; set; }

        public BusinessResult(bool isSuccess, BusinessError? error, T? result = default) : base(isSuccess, error)
        {
            Result = result;
        }

        public static BusinessResult<T> FromSuccess(T? result)
        {
            return new BusinessResult<T>(true, null, result);
        }

        public static BusinessResult<T> FromError(string errorMessage, BusinessErrorReason reason, T? result = default)
        {
            BusinessError error = new(errorMessage, reason);
            return new BusinessResult<T>(false, error, result);
        }

        public static BusinessResult<User> FromSuccess(User updatedUser)
        {
            return new BusinessResult<User>(true, null, updatedUser);
        }

        public static BusinessResult<UserTask> FromSuccess(UserTask updatedTask)
        {
            return new BusinessResult<UserTask>(true, null, updatedTask);
        }

        public static BusinessResult<Project> FromSuccess(Project businessResult)
        {
            return new BusinessResult<Project>(true, null, businessResult);
        }

        public static BusinessResult<T> FromError(string leProjetNExistePas)
        {
            return BusinessResult<T>.FromError(leProjetNExistePas, BusinessErrorReason.NotFound);
        }
    }

    // Erreur métier (cas géré et attendu)
    public class BusinessError
    {
        // Message de l'erreur
        public string ErrorMessage { get; set; }

        // Cause de l'erreur, utile pour déterminer le statut http
        public BusinessErrorReason Reason { get; set; }

        public BusinessError(string errorMessage, BusinessErrorReason reason)
        {
            ErrorMessage = errorMessage;
            Reason = reason;
        }
    }

    // Causes possibles d'une erreur métier
    // La liste peut être augmentée au fil du développement
    public enum BusinessErrorReason
    {
        BusinessRule = 400,
        NotFound = 404,
    }
}