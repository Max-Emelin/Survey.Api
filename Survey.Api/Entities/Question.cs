namespace Survey.Api.Entities
{
    /// <summary>
    /// Вопрос анкеты.
    /// </summary>
    public class Question
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
        /// Текст вопроса.
        /// </summary>
        public required string Text { get; set; }
    }
}