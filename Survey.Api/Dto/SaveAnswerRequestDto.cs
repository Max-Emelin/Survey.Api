namespace Survey.Api.Dto
{
    /// <summary>
    /// Передача выбора ответов на вопрос.
    /// </summary>
    public class SaveAnswerRequestDto
    {
        /// <summary>
        /// Идентификатор вопроса.
        /// </summary>
        public int QuestionId { get; set; }

        /// <summary>
        /// Выбранные ответы.
        /// </summary>
        public List<int> SelectedAnswerIds { get; set; }

        /// <summary>
        /// Идентификатор интервью.
        /// </summary>
        public int InterviewId { get; set; }
    }
}