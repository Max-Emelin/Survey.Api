namespace Survey.Api.Entities
{
    /// <summary>
    /// Результат-ответ.
    /// </summary>
    public class ResultAnswer
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор результата.
        /// </summary>
        public int ResultId { get; set; }

        /// <summary>
        /// Идентификатор ответа.
        /// </summary>
        public int AnswerId { get; set; }
    }
}