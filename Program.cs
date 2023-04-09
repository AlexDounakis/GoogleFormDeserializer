

// See https://aka.ms/new-console-template for more information


using GoogleFormDeserializer;
using GoogleFormDeserializer.Models;
using GoogleFormDeserializer.Repository;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

string formData = @"{""formId"":""FORM_ID"",""info"":{""title"":""Famous Black Women"",""description"":""Please complete this quiz based off of this week's readings for class."",""documentTitle"":""API Example Quiz""},""settings"":{""quizSettings"":{""isQuiz"":true}},""revisionId"":""00000021"",""responderUri"":""https://docs.google.com/forms/d/e/1FAIpQLSd0iBLPh4suZoGW938EU1WIxzObQv_jXto0nT2U8HH2KsI5dg/viewform"",""items"":[{""itemId"":""5d9f9786"",""imageItem"":{""image"":{""contentUri"":""DIRECT_URL"",""properties"":{""alignment"":""LEFT""}}}},{""itemId"":""72b30353"",""title"":""Which African American woman authored \""I Know Why the Caged Bird Sings\""?"",""questionItem"":{""question"":{""questionId"":""25405d4e"",""required"":true,""grading"":{""pointValue"":2,""correctAnswers"":{""answers"":[{""value"":""Maya Angelou""}]}},""choiceQuestion"":{""type"":""RADIO"",""options"":[{""value"":""Maya Angelou""},{""value"":""bell hooks""},{""value"":""Alice Walker""},{""value"":""Roxane Gay""}]}}}},{""itemId"":""0a4859c8"",""title"":""Who was the first Dominican-American woman elected to state office?"",""questionItem"":{""question"":{""questionId"":""37fff47a"",""grading"":{""pointValue"":2,""correctAnswers"":{""answers"":[{""value"":""Grace Diaz""}]}},""choiceQuestion"":{""type"":""RADIO"",""options"":[{""value"":""Rosa Clemente""},{""value"":""Grace Diaz""},{""value"":""Juana Matias""},{""value"":""Sabrina Matos""}]}}}}]}";


// Deserialize the form data from JSON
var settings = new JsonSerializerSettings
{
    MissingMemberHandling = MissingMemberHandling.Ignore
};
Form _form = JsonConvert.DeserializeObject<Form>(formData, settings);


using var context = new GoogleFormsDbContext();
context.Database.EnsureCreated();
context.Forms.Add(_form);
await context.SaveChangesAsync();


//Eager loading
var form = context.Forms
                    .Include(x => x.info)
                    .Include(x => x.settings)
                        .ThenInclude(x => x.quizSettings)
                    .Include(x => x.items)
                        .ThenInclude(x => x.imageItem)
                            .ThenInclude(x => x.image)
                                .ThenInclude(x => x.properties)
                    .Include(x => x.items)
                        .ThenInclude(x => x.questionItem)
                            .ThenInclude(x => x.question)
                                .ThenInclude(x => x.choiceQuestion)
                                    .ThenInclude(x => x.options)
                    .Include(x => x.items)
                        .ThenInclude(x => x.questionItem)
                            .ThenInclude(x => x.question)
                                .ThenInclude(x => x.grading)
                                    .ThenInclude(x => x.correctAnswers)
                                        .ThenInclude(x => x.answers)
                    .FirstOrDefault();
//var _info = context.Information.Include(x=>x.form).FirstOrDefaultAsync();

//Console.WriteLine($"My Info Data: {}");
//Console.WriteLine($"My Info Data:{}");
//Console.WriteLine($"My Info Data:{}");
//Console.WriteLine($"My Info Data:{}");
//Explicit loading 
//var _form = context.Forms.Find(form.Id);
//var formWithRelatedEntities = context.Entry(form).Collection(x => x.info).Load();


Console.WriteLine("Form ID: " + form.formId);
Console.WriteLine("Title: " + form.info.title);
Console.WriteLine("Description: " + form.info.description);
Console.WriteLine("Document Title: " + form.info.documentTitle);
Console.WriteLine("Is Quiz: " + form.settings.quizSettings.isQuiz);
Console.WriteLine("Revision ID: " + form.revisionId);
Console.WriteLine("Responder URI: " + form.responderUri);

foreach (Item item in form.items)
{
    Console.WriteLine("Item ID: " + item.itemId);
    Console.WriteLine("Title: " + item.title);

    if (item.questionItem != null)
    {
        Console.WriteLine("Question ID: " + item.questionItem.question.questionId);
        Console.WriteLine("Required: " + item.questionItem.question.required);
        Console.WriteLine("Point Value: " + item.questionItem.question.grading.pointValue);

        foreach (Option option in item.questionItem.question.choiceQuestion.options)
        {
            Console.WriteLine("Option: " + option.value);
        }

        if (item.questionItem.question.grading.correctAnswers.answers != null)
        {
            foreach (Answer Answer in item.questionItem.question.grading.correctAnswers.answers)
            {
                Console.WriteLine("Correct Answer: " + Answer.value);
            }
            Console.WriteLine("Question Grading: " + item.questionItem.question.grading.pointValue);
        }
    }

    if (item.imageItem != null)
    {
        Console.WriteLine("Content URI: " + item.imageItem.image.contentUri);
        Console.WriteLine("Content URI: " + item.imageItem.image.properties.alignment);
    }
}
//foreach (Form _form in forms)
//{
//    Console.WriteLine($"Form ID: {_form.formId}");
//    Console.WriteLine($"Title: {_form.revisionId}");
//    Console.WriteLine($"Description: {_form.responderUri}");
//    Console.WriteLine("Questions:");
//    Console.WriteLine($"\tQuestion ID: {_form.info.formId}");
//    Console.WriteLine($"\tTitle: {_form.info.title}");
//    Console.WriteLine($"\tQuestion Type: {_form.info.documentTitle}");
//    Console.WriteLine("\tOptions:");
//}
Console.WriteLine("Ending");