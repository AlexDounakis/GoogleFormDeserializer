using GoogleFormDeserializer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormDeserializer.Repository
{
    public class GoogleFormsDbContext : DbContext
    {
        //public DbSet<Response> Responses { get; set; }
        //public GoogleFormsDbContext(DbContextOptions<GoogleFormsDbContext> options) : base(options)
        //{
        //}

        public DbSet<Form> Forms { get; set; }
        public DbSet<Info> Info { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<QuizSettings> QuizSettings { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ImageItem> ImageItems { get; set; }
        public DbSet<QuestionItem> QuestionItems { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<ChoiceQuestion> ChoiceQuestions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Properties> Properties { get; set; }
        public DbSet<Grading> Gradings { get; set; }
        public DbSet<CorrectAnswers> CorrectAnswers { get; set; }
        public DbSet<Answer> Answers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost; database=GoogleFormsDB; Integrated Security=true ; TrustServerCertificate=True"); // Specifies the database provider and connection string
            //optionsBuilder.EnableSensitiveDataLogging(); // Enables logging of sensitive data
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); // Sets the default query tracking behavior to NoTracking
            //optionsBuilder.LogTo(Console.WriteLine); // Logs SQL commands to the console
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Form>()
                .HasAlternateKey("formId");

            //One to One with dependand side beeing imageitem
            modelBuilder.Entity<ImageItem>()
                .HasOne(i => i.item)
                .WithOne(i => i.imageItem)
                .HasForeignKey<ImageItem>(i => i.itemId);
            modelBuilder.Entity<QuestionItem>()
                .HasOne(i => i.item)
                .WithOne(i => i.questionItem)
                .HasForeignKey<QuestionItem>(i => i.itemId);
            //modelBuilder.Query<Form>()
            //    .Include(x => x.info);
            //this works!!!
            //modelBuilder.Entity<Form>()
            //    .HasOne(f => f.info)
            //    .WithOne(i => i.form)
            //    .HasForeignKey<Info>(i => i.formId)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Info>()
            //    .HasOne(i => i.form)
            //    .WithOne(f => f.info)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Cascade);
            // Correct way to perform 1-1


            //modelBuilder.Entity<Settings>()
            //modelBuilder.Entity<Answer>()
            //    .HasKey(x => x.Id);
            //modelBuilder.Entity<Answer>()
            //    .HasOne(a => a.Question)
            //    .WithMany(q => q.Answers)
            //    .HasForeignKey(a => a.CorrectAnswersId);

            //modelBuilder.Entity<ChoiceQuestion>()
            //    .HasMany(c => c.Options)
            //    .WithOne()
            //    .HasForeignKey("ChoiceQuestionId")
            //    .IsRequired();

            //modelBuilder.Entity<CorrectAnswers>()
            //    .HasMany(c => c.Answers)
            //    .WithOne()
            //    .IsRequired();

            //modelBuilder.Entity<Grading>()
            //    .HasOne(g => g.CorrectAnswers)
            //    .WithOne()
            //    .HasForeignKey<CorrectAnswers>("GradingId");

            //modelBuilder.Entity<Image>()
            //    .HasOne(i => i.Properties)
            //    .WithOne()
            //    .HasForeignKey<Properties>("ImageId");

            //modelBuilder.Entity<ImageItem>()
            //    .HasKey(i => i.Id);

            //modelBuilder.Entity<ImageItem>()
            //    .HasOne(i => i.Image)
            //    .WithOne()
            //    .HasForeignKey<ImageItem>("ImageId");

            //modelBuilder.Entity<Item>()
            //    .HasKey(i => i.Id);

            //modelBuilder.Entity<Item>()
            //    .HasOne(i => i.ImageItem)
            //    .WithOne()
            //    .HasForeignKey<Item>("ImageItemId");

            //modelBuilder.Entity<Item>()
            //    .HasOne(i => i.QuestionItem)
            //    .WithOne()
            //    .HasForeignKey<Item>("QuestionItemId");

            //modelBuilder.Entity<Option>()
            //    .HasOne(o => o.ChoiceQuestion)
            //    .WithMany(c => c.Options)
            //    .HasForeignKey("ChoiceQuestionId")
            //    .IsRequired();

            //modelBuilder.Entity<Properties>()
            //    .HasKey(p => p.Id);

            //modelBuilder.Entity<Question>()
            //    .HasOne(q => q.Grading)
            //    .WithOne()
            //    .HasForeignKey<Grading>("QuestionId");

            //modelBuilder.Entity<Question>()
            //    .HasMany(q => q.Answers)
            //    .WithOne(a => a.Question)
            //    .IsRequired();

            //modelBuilder.Entity<QuestionItem>()
            //    .HasKey(qi => qi.Id);

            //modelBuilder.Entity<QuestionItem>()
            //    .HasOne(qi => qi.Question)
            //    .WithOne()
            //    .HasForeignKey<QuestionItem>("QuestionId");

            //modelBuilder.Entity<Root>()
            //    .HasKey(r => r.Id);

            //modelBuilder.Entity<Root>()
            //    .HasMany(r => r.Items)
            //    .WithOne(i => i.Root)
            //    .HasForeignKey(i => i.RootId);

            //modelBuilder.Entity<Settings>()
            //    .HasKey(s => s.Id);

            //modelBuilder.Entity<Settings>()
            //    .HasOne(s => s.Root)
            //    .WithOne(r => r.Settings)
            //    .HasForeignKey<Settings>("RootId");

            //modelBuilder.Entity<Settings>()
            //    .HasOne(s => s.QuizSettings)
            //    .WithOne(qs => qs.Settings)
            //    .HasForeignKey<QuizSettings>("SettingsId");

            //modelBuilder.Entity<QuizSettings>()
            //    .HasKey(qs => qs.Id);
        }



    }
}
