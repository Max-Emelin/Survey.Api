namespace Survey.Api.Dto
{
    /// <summary>
    /// Передача вопроса с вариантами ответа.
    /// </summary>
    public class QuestionResponseDto
    {
        /// <summary>
        /// Идентификатор вопроса.
        /// </summary>
        public int QuestionId { get; set; }

        /// <summary>
        /// Текст вопроса.
        /// </summary>
        public string QuestionText { get; set; }

        /// <summary>
        /// Варианты ответа.
        /// </summary>
        public List<AnswerDto> Answers { get; set; }
    }
}