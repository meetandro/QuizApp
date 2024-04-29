﻿using QuizApp.Entities;
using QuizApp.Exceptions;
using QuizApp.Models;
using QuizApp.Repositories;

namespace QuizApp.Services;

public class QuestionService(IQuestionRepository questionRepository) : IQuestionService
{
    private readonly IQuestionRepository _questionRepository = questionRepository;

    public List<Question> GetAllQuestions()
    {
        return _questionRepository.GetAllQuestions();
    }

    public Question AddQuestion(QuestionViewModel questionViewModel)
    {
        var question = questionViewModel.Question ?? throw new EntityNotFoundException("Question does not exist.");

        if (string.IsNullOrEmpty(question.QuestionText))
        {
            throw new EmptyInputException("Question text is required.");
        }
        if (question.Answers.Any(a => string.IsNullOrEmpty(a.AnswerText)))
        {
            throw new EmptyInputException("All answers must be filled.");
        }

        int correctAnswerIndex = questionViewModel.CorrectAnswerIndex;
        question.Answers[correctAnswerIndex].IsCorrect = true;

        return _questionRepository.AddQuestion(question);
    }

    public Question DeleteQuestion(int id)
    {
        return _questionRepository.DeleteQuestion(id);
    }
}