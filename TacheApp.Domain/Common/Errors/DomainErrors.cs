namespace TacheApp.Domain.Common.Errors
{
    public static class DomainErrors
    {
        public static class Tache
        {
            public static readonly Error NotFound = new(
                "Tache.NotFound",
                "La tâche spécifiée n'existe pas.",
                ErrorType.NotFound);

            public static readonly Error AlreadyCompleted = new(
                "Tache.AlreadyCompleted",
                "La tâche est déjà terminée.",
                ErrorType.Validation);
            public static readonly Error TitleRequired = new(
                "Tache.TitleRequired",
                "Le titre est requis.",
                ErrorType.Validation);
        }
    }
}
