

using Microsoft.EntityFrameworkCore;
using QuizProject.Models;

namespace QuizProjectEF.DBEntity;

public class QuizDBContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<UserScore> UserScores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Quizz;Integrated Security=True;Trust Server Certificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .ToTable("Users")
            .HasKey(x => x.Id);

        modelBuilder.Entity<User>()
            .HasIndex(x => x.UserName)
            .IsUnique();

        modelBuilder.Entity<User>()
            .Property(x => x.UserName)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<Quiz>()
            .ToTable("Quizzes")
            .HasKey(x => x.QuizId);

        modelBuilder.Entity<Question>()
            .ToTable("Questions")
            .HasKey(x => x.QuestionId);

        modelBuilder.Entity<Question>()
            .HasOne(x => x.Quiz)
            .WithMany(q => q.Questions)
            .HasForeignKey(x => x.QuizId);

        modelBuilder.Entity<Answer>()
            .ToTable("Answers")
            .HasKey(x => x.AnswerId);

        modelBuilder.Entity<Answer>()
            .HasOne(x => x.Question)
            .WithMany(q => q.Answers)
            .HasForeignKey(x => x.QuestionId);

        modelBuilder.Entity<UserScore>()
            .ToTable("UserScores")
            .HasKey(x => x.Id);

        modelBuilder.Entity<UserScore>()
            .HasOne(x => x.User)
            .WithMany(u => u.Scores)
            .HasForeignKey(x => x.UserId);

        modelBuilder.Entity<UserScore>()
            .HasOne(x => x.Quiz)
            .WithMany(q => q.Scores)
            .HasForeignKey(x => x.QuizId);

        modelBuilder.Entity<UserScore>()
            .HasIndex(x => new { x.UserId, x.QuizId })
            .IsUnique();
    }


}
