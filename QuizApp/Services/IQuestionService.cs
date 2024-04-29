﻿using QuizApp.Entities;
using QuizApp.Models;

namespace QuizApp.Services;

public interface IQuestionService
{
    public List<Question> GetAllQuestions();

    public Question AddQuestion(QuestionViewModel questionViewModel);

    public Question DeleteQuestion(int id);
}