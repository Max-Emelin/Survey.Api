namespace Survey.Api.Dto
{
    /// <summary>
    /// Передача ответа.
    /// </summary>
    public class AnswerDto
    {
        /// <summary>
        /// Идентификатор ответа.
        /// </summary>
        public int AnswerId { get; set; }

        /// <summary>
        /// Текст ответа.
        /// </summary>
        public string AnswerText { get; set; }
    }
}