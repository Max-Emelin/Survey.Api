using Microsoft.AspNetCore.Mvc;
using Survey.Api.Dto;
using Survey.Api.Interfaces;

namespace Survey.Api.Controllers
{
    /// <summary>
    /// Контроллер для анкет.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SurveyController : ControllerBase
    {
        /// <summary>
        /// Сервис для анкет.
        /// </summary>
        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        /// <summary>
        /// Получение данных вопроса.
        /// </summary>
        /// <param name="questionId"> Идентификатор вопроса. </param>
        /// <returns> Вопрос с ответами. </returns>
        [HttpGet("question/{questionId}")]
        public IActionResult GetQuestion(int questionId)
        {
            var question = _surveyService.GetQuestion(questionId);
            if (question == null)
            {
                return NotFound("Вопрос не найден");
            }

            return Ok(question);
        }

        /// <summary>
        /// Сохранить ответ на вопрос.
        /// </summary>
        /// <param name="request"> Выбор ответов на вопрос. </param>
        /// <returns> Идентификатор следующего вопроса. </returns>
        [HttpPost("answer")]
        public IActionResult SaveAnswer([FromBody] SaveAnswerRequestDto request)
        {
            var nextQuestionId = _surveyService.SaveAnswer(request);
            if (nextQuestionId == null)
            {
                return Ok(new { Message = "Survey completed" });
            }

            return Ok(new { NextQuestionId = nextQuestionId });
        }
    }
}