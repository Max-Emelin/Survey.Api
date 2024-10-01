namespace Survey.Api.Entities
{
    /// <summary>
    /// Результаты ответов пользователей на вопросы анкеты.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор интервью.
        /// </summary>
        public int InterviewId { get; set; }

        /// <summary>
        /// Идентификатор вопроса.
        /// </summary>
        public int QuestionId { get; set; }

        /// <summary>
        /// Время ответа.
        /// </summary>
        public DateTime AnsweredAt { get; set; }
    }
}