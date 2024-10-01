CREATE TABLE "Survey" (
    "Id" SERIAL PRIMARY KEY,    
    "Title" VARCHAR(255) NOT NULL,    
    "Description" TEXT
);

CREATE TABLE "Question" (
    "Id" SERIAL PRIMARY KEY, 
    "SurveyId" INT REFERENCES "Survey"("Id") ON DELETE CASCADE,  
    "Text" TEXT NOT NULL         
);

CREATE TABLE "Answer" (
    "Id" SERIAL PRIMARY KEY,    
    "QuestionId" INT REFERENCES "Question"("Id") ON DELETE CASCADE,  
    "Text" TEXT NOT NULL
);

CREATE TABLE "Interview" (
    "Id" SERIAL PRIMARY KEY, 
    "SurveyId" INT REFERENCES "Survey"("Id") ON DELETE CASCADE,  
    "RespondentName" VARCHAR(255)
);


CREATE TABLE "Result" (
    "Id" SERIAL PRIMARY KEY,       
    "InterviewId" INT REFERENCES "Interview"("Id") ON DELETE CASCADE,  
    "QuestionId" INT REFERENCES "Question"("Id") ON DELETE CASCADE,  
    "AnsweredAt" TIMESTAMP
);

CREATE TABLE "ResultAnswer" (
    "Id" SERIAL PRIMARY KEY, 
    "ResultId" INT REFERENCES "Result"("Id") ON DELETE CASCADE,  
    "AnswerId" INT REFERENCES "Answer"("Id") ON DELETE CASCADE 
);




CREATE INDEX idx_interview_id ON "Interview"("Id");
CREATE INDEX idx_question_id ON "Question"("Id");
CREATE INDEX idx_answer_id ON "Answer"("Id");
CREATE INDEX idx_answer_question_id ON "Answer"("QuestionId");
CREATE INDEX idx_question_survey_id ON "Question"("SurveyId");
CREATE INDEX idx_interview_survey_id ON "Interview"("SurveyId");
CREATE INDEX idx_result_interview_id ON "Result"("InterviewId");
CREATE INDEX idx_result_question_id ON "Result"("QuestionId");
CREATE INDEX idx_result_answer_result_id ON "ResultAnswer"("ResultId");
CREATE INDEX idx_result_answer_answer_id ON "ResultAnswer"("AnswerId");





INSERT INTO "Survey" ("Title", "Description") VALUES
('Customer Satisfaction Survey', 'A survey to gather customer feedback on products and services.'),
('Employee Engagement Survey', 'A survey to assess employee satisfaction and engagement levels.');

INSERT INTO "Question" ("SurveyId", "Text") VALUES
(1, 'How satisfied are you with our products?'),
(1, 'How likely are you to recommend us to a friend?'),
(2, 'Do you feel valued at work?'),
(2, 'How would you rate your work-life balance?');

INSERT INTO "Answer" ("QuestionId", "Text") VALUES
(1, 'Very Satisfied'),
(1, 'Satisfied'),
(1, 'Neutral'),
(1, 'Dissatisfied'),
(1, 'Very Dissatisfied'),
(2, 'Very Likely'),
(2, 'Likely'),
(2, 'Unlikely'),
(2, 'Very Unlikely'),
(3, 'Yes'),
(3, 'No'),
(4, 'Excellent'),
(4, 'Good'),
(4, 'Average'),
(4, 'Poor');

INSERT INTO "Interview" ("SurveyId", "RespondentName") VALUES
(1, 'Alice Smith'),
(1, 'Bob Johnson'),
(2, 'Charlie Brown');

INSERT INTO "Result" ("InterviewId", "QuestionId", "AnsweredAt") VALUES
(1, 1, DEFAULT),
(1, 2, DEFAULT),
(2, 1, DEFAULT),
(2, 2, DEFAULT),
(3, 3, DEFAULT),
(3, 4, DEFAULT);

INSERT INTO "ResultAnswer" ("ResultId", "AnswerId") VALUES
(1, 1), 
(2, 6), 
(3, 3), 
(4, 7), 
(5, 10), 
(6, 14); 
