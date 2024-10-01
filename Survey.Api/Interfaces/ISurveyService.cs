using Survey.Api.Dto;

namespace Survey.Api.Interfaces
{
    /// <summary>
    /// Для анкет.
    /// </summary>
    public interface ISurveyService
    {
        /// <summary>
        /// Получение данных вопроса.
        /// </summary>
        /// <param name="questionId"> Идентификатор вопроса. </param>
        /// <returns> Вопрос с ответами. </returns>
        QuestionResponseDto GetQuestion(int questionId);

        /// <summary>
        /// Сохранить ответ на вопрос.
        /// </summary>
        /// <param name="request"> Выбор ответов на вопрос. </param>
        /// <returns> Идентификатор следующего вопроса. </returns>
        int? SaveAnswer(SaveAnswerRequestDto request);
    }
}