using System.Text.Json.Serialization;

public class Form
{
    [JsonIgnore]
    public Guid Id { get; set; }
    [JsonPropertyName("formId")]
    public string formId { get; set; }
    public Info info { get; set; }
    public Settings settings { get; set; }
    public string revisionId { get; set; }
    public string responderUri { get; set; }
    public List<Item> items { get; set; }
}
public class Info
{
    [JsonIgnore]
    public Guid Id { get; set; }
    [JsonIgnore]
    public Guid formId { get; set; }
    [JsonIgnore]
    public Form form { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string documentTitle { get; set; }
}
public class Settings
{
    [JsonIgnore]
    public Guid Id { get; set; }

    //public QuizSettings quizSettings { get; set; }
    [JsonIgnore]
    public Guid formId { get; set; }
    [JsonIgnore]
    public Form form { get; set; }
    public QuizSettings quizSettings { get; set; }
}
public class QuizSettings
{
    [JsonIgnore]
    public Guid id { get; set; }
    [JsonIgnore]
    public Guid settingsId { get; set; }
    [JsonIgnore]
    public Settings setting { get; set; }
    public bool isQuiz { get; set; }
}
public class Item
{
    [JsonIgnore]
    public Guid id { get; set; }
    [JsonIgnore]
    public Guid formId { get; set; }
    [JsonIgnore]
    public Form form { get; set; }
    public string itemId { get; set; }
    public string? title { get; set; }
    public ImageItem imageItem { get; set; }
    public QuestionItem questionItem { get; set; }
}
public class ImageItem
{
    [JsonIgnore]
    public Guid id { get; set; }
    [JsonIgnore]
    public Guid itemId { get; set; }
    [JsonIgnore]
    public Item item { get; set; }
    public Image image { get; set; }
}
public class QuestionItem
{
    [JsonIgnore]
    public Guid id { get; set; }
    [JsonIgnore]
    public Guid itemId { get; set; }
    [JsonIgnore]
    public Item item { get; set; }
    public Question question { get; set; }
}
public class Question
{
    [JsonIgnore]
    public Guid id { get; set; }
    [JsonIgnore]
    public Guid questionItemId { get; set; }
    [JsonIgnore]
    public QuestionItem questionItem { get; set; }
    public string questionId { get; set; }
    public bool required { get; set; }
    public Grading grading { get; set; }
    public ChoiceQuestion choiceQuestion { get; set; }
}
public class ChoiceQuestion
{
    [JsonIgnore]
    public Guid id { get; set; }
    [JsonIgnore]
    public Guid questionId { get; set; }
    [JsonIgnore]
    public Question question { get; set; }
    public string type { get; set; }
    public List<Option> options { get; set; }
}
public class Option
{
    [JsonIgnore]
    public Guid id { get; set; }
    [JsonIgnore]
    public Guid choiceQuestionId { get; set; }
    [JsonIgnore]
    public ChoiceQuestion choiceQuestion { get; set; }
    public string value { get; set; }
}
public class Image
{
    [JsonIgnore]
    public Guid id { get; set; }
    [JsonIgnore]
    public Guid imageItemId { get; set; }
    [JsonIgnore]
    public ImageItem imageItem { get; set; }
    public string contentUri { get; set; }
    public Properties properties { get; set; }
}
public class Properties
{
    [JsonIgnore]
    public Guid id { get; set; }
    [JsonIgnore]
    public Guid imageId { get; set; }
    [JsonIgnore]
    public Image image { get; set; }
    public string alignment { get; set; }
}
public class Grading
{
    [JsonIgnore]
    public Guid id { get; set; }
    [JsonIgnore]
    public Guid questionId { get; set; }
    [JsonIgnore]
    public Question question { get; set; }
    public int pointValue { get; set; }
    public CorrectAnswers correctAnswers { get; set; }
}
public class CorrectAnswers
{
    [JsonIgnore]
    public Guid id { get; set; }
    [JsonIgnore]
    public Guid gradingId { get; set; }
    [JsonIgnore]
    public Grading grading { get; set; }
    public List<Answer> answers { get; set; }
}
public class Answer
{
    [JsonIgnore]
    public Guid id { get; set; }
    [JsonIgnore]
    public Guid correctAnswersId { get; set; }
    [JsonIgnore]
    public CorrectAnswers correctAnswers { get; set; }
    public string value { get; set; }
}