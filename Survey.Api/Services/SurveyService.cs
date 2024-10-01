using Survey.Api.Dto;
using Survey.Api.Entities;
using Survey.Api.Interfaces;

namespace Survey.Api.Services
{
    /// <inheritdoc />
    public class SurveyService : ISurveyService
    {
        /// <summary>
        /// Контекст бд.
        /// </summary>
        private readonly ApplicationDbContext _context;

        public SurveyService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public QuestionResponseDto GetQuestion(int questionId)
        {
            var question = _context.Question
                .Where(q => q.Id == questionId)
                .Select(q => new QuestionResponseDto
                {
                    QuestionId = q.Id,
                    QuestionText = q.Text,
                    Answers = _context.Answer
                    .Where(a => a.QuestionId == q.Id)
                    .Select(a => new AnswerDto
                    {
                        AnswerId = a.Id,
                        AnswerText = a.Text
                    }).ToList()
                })
                .FirstOrDefault();

            return question;
        }

        /// <inheritdoc />
        public int? SaveAnswer(SaveAnswerRequestDto request)
        {
            var question = _context.Question
                .Where(q => q.Id == request.QuestionId)
                .FirstOrDefault();

            if (question == null)
            {
                throw new ArgumentException($"Вопроса с Id = {request.QuestionId} не существует");
            }

            var interview = _context.Interview
                .Where(i => i.Id == request.InterviewId)
                .FirstOrDefault();

            if (interview == null)
            {
                interview = new Interview
                {
                    Id = request.InterviewId,
                    SurveyId = question.SurveyId
                };

                _context.Interview.Add(interview);
                _context.SaveChanges();
            }

            var result = new Result
            {
                InterviewId = interview.Id,
                QuestionId = request.QuestionId,
                AnsweredAt = DateTime.UtcNow
            };

            _context.Result.Add(result);
            _context.SaveChanges();

            foreach (var answerId in request.SelectedAnswerIds)
            {
                var resultAnswer = new ResultAnswer
                {
                    ResultId = result.Id,
                    AnswerId = answerId
                };

                _context.ResultAnswer.Add(resultAnswer);
            }

            _context.SaveChanges();

            var nextQuestion = _context.Question
                .Where(q => q.Id > request.QuestionId && q.SurveyId == interview.SurveyId)
                .OrderBy(q => q.Id)
                .FirstOrDefault();

            return nextQuestion?.Id;
        }
    }
}