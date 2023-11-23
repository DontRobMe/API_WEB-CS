#nullable enable
namespace TP_CS.Business.Models
{
    // Résultat d'une action de service
    public class BusinessResult
    {
        // Inqiue le succès de l'action
        public bool IsSuccess { get; set; }

        // Si il y a eu une erreur métier, contient le détail de l'erreur
        public BusinessError? Error { get; set; }

        public BusinessResult()
        { }

        protected BusinessResult(bool isSuccess, BusinessError? error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        // Méthode utilitaire type "factory" pour rapidement générer une retour de type succès
        public static BusinessResult FromSuccess()
        {
            return new BusinessResult(true, null);
        }

        // Méthode utilitaire type "factory" pour rapidement générer une retour de type erreur
        public static BusinessResult FromError(string errorMessage, BusinessErrorReason reason)
        {
            BusinessError error = new(errorMessage, reason);
            return new BusinessResult(false, error);
        }
    }

    // Résultat d'une action de service avec retour
    public class BusinessResult<T> : BusinessResult // Hérite du résultat sans retour
    {
        // Retour générique pouvant être null
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
