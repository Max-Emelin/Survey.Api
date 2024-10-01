namespace Survey.Api.Entities
{
    /// <summary>
    /// Ответ на вопрос.
    /// </summary>
    public class Answer
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор вопроса.
        /// </summary>
        public int QuestionId { get; set; }

        /// <summary>
        /// Текст ответа.
        /// </summary>
        public required string Text { get; set; }
    }
}