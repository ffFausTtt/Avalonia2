using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaTeachers.Models;

public partial class Mdk0101Context : DbContext
{
    public Mdk0101Context()
    {
    }

    public Mdk0101Context(DbContextOptions<Mdk0101Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Curse> Curses { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherCurse> TeacherCurses { get; set; }

    public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=edu.pg.ngknn.local;Port=5432;Database=43P_Kudryashov;Username=43P;Password=444444");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Curse>(entity =>
        {
            entity.HasKey(e => e.IdCurse).HasName("curses_pk");

            entity.ToTable("curses");

            entity.Property(e => e.IdCurse)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_curse");
            entity.Property(e => e.Curse1)
                .HasColumnType("character varying")
                .HasColumnName("curse");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.IdGender).HasName("gender_pk");

            entity.ToTable("gender");

            entity.HasIndex(e => e.IdGender, "gender_id_gender_idx").IsUnique();

            entity.Property(e => e.IdGender)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_gender");
            entity.Property(e => e.Gender1)
                .HasColumnType("character varying")
                .HasColumnName("gender");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.IdSubject).HasName("subjects_pk");

            entity.ToTable("subjects");

            entity.Property(e => e.IdSubject)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_subject");
            entity.Property(e => e.Subject1)
                .HasColumnType("character varying")
                .HasColumnName("subject");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.IdTeacher).HasName("teachers_pk");

            entity.ToTable("teachers");

            entity.Property(e => e.IdTeacher)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_teacher");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.EMail)
                .HasColumnType("character varying")
                .HasColumnName("e_mail");
            entity.Property(e => e.Experience).HasColumnName("experience");
            entity.Property(e => e.IdGender).HasColumnName("id_gender");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
            entity.Property(e => e.Softname)
                .HasColumnType("character varying")
                .HasColumnName("softname");
            entity.Property(e => e.Surname)
                .HasColumnType("character varying")
                .HasColumnName("surname");

            entity.HasOne(d => d.IdGenderNavigation).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.IdGender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("teachers_fk");
        });

        modelBuilder.Entity<TeacherCurse>(entity =>
        {
            entity.HasKey(e => e.IdTeacherCurses).HasName("teacher_curses_pk");

            entity.ToTable("teacher_curses");

            entity.Property(e => e.IdTeacherCurses)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_teacher_curses");
            entity.Property(e => e.Hours).HasColumnName("hours");
            entity.Property(e => e.IdCurse).HasColumnName("id_curse");
            entity.Property(e => e.IdTeacher).HasColumnName("id_teacher");

            entity.HasOne(d => d.IdCurseNavigation).WithMany(p => p.TeacherCurses)
                .HasForeignKey(d => d.IdCurse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("teacher_curses_fk_1");

            entity.HasOne(d => d.IdTeacherNavigation).WithMany(p => p.TeacherCurses)
                .HasForeignKey(d => d.IdTeacher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("teacher_curses_fk");
        });

        modelBuilder.Entity<TeacherSubject>(entity =>
        {
            entity.HasKey(e => e.IdTeacherSubjects).HasName("teacher_subjects_pk");

            entity.ToTable("teacher_subjects");

            entity.Property(e => e.IdTeacherSubjects)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_teacher_subjects");
            entity.Property(e => e.IdSubject).HasColumnName("id_subject");
            entity.Property(e => e.IdTeacher).HasColumnName("id_teacher");

            entity.HasOne(d => d.IdSubjectNavigation).WithMany(p => p.TeacherSubjects)
                .HasForeignKey(d => d.IdSubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("teacher_subjects_fk_1");

            entity.HasOne(d => d.IdTeacherNavigation).WithMany(p => p.TeacherSubjects)
                .HasForeignKey(d => d.IdTeacher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("teacher_subjects_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
