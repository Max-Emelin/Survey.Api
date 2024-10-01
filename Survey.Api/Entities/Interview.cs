namespace Survey.Api.Entities
{
    /// <summary>
    /// Интервью (сессия прохождения анкеты конкретным человеком).
    /// </summary>
    public class Interview
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор анкеты.
        /// </summary>
        public int SurveyId { get; set; }

        /// <summary>
        /// Имя человека, проходящего анкету.
        /// </summary>
        public string RespondentName { get; set; }
    }
}