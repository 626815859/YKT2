
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/22/2018 12:21:09
-- Generated from EDMX file: F:\新建文件夹\net课堂项目\2018\YKT.Exam\YKT.Exam.Model\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [YKT.Exam];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CourseTestPaper]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestPaperSet] DROP CONSTRAINT [FK_CourseTestPaper];
GO
IF OBJECT_ID(N'[dbo].[FK_TeacherClass_Teacher]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeacherClass] DROP CONSTRAINT [FK_TeacherClass_Teacher];
GO
IF OBJECT_ID(N'[dbo].[FK_TeacherClass_Class]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeacherClass] DROP CONSTRAINT [FK_TeacherClass_Class];
GO
IF OBJECT_ID(N'[dbo].[FK_ClassStudent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentSet] DROP CONSTRAINT [FK_ClassStudent];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentCollection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CollectionSet] DROP CONSTRAINT [FK_StudentCollection];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentCourse_Student]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentCourse] DROP CONSTRAINT [FK_StudentCourse_Student];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentCourse_Course]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentCourse] DROP CONSTRAINT [FK_StudentCourse_Course];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseComment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CommentSet] DROP CONSTRAINT [FK_CourseComment];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentTestPaper]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestPaperSet] DROP CONSTRAINT [FK_StudentTestPaper];
GO
IF OBJECT_ID(N'[dbo].[FK_TestPaperStudentTestResult]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentTestResultSet] DROP CONSTRAINT [FK_TestPaperStudentTestResult];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentStudentTestResult]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentTestResultSet] DROP CONSTRAINT [FK_StudentStudentTestResult];
GO
IF OBJECT_ID(N'[dbo].[FK_TestQuestionCollection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CollectionSet] DROP CONSTRAINT [FK_TestQuestionCollection];
GO
IF OBJECT_ID(N'[dbo].[FK_TestQuestionStudentTestResult]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentTestResultSet] DROP CONSTRAINT [FK_TestQuestionStudentTestResult];
GO
IF OBJECT_ID(N'[dbo].[FK_TestQuestionPaperQuestion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaperQuestionSet] DROP CONSTRAINT [FK_TestQuestionPaperQuestion];
GO
IF OBJECT_ID(N'[dbo].[FK_TestPaperScore]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScoreSet] DROP CONSTRAINT [FK_TestPaperScore];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseScore]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScoreSet] DROP CONSTRAINT [FK_CourseScore];
GO
IF OBJECT_ID(N'[dbo].[FK_BaseTestPaperTestPaper]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestPaperSet] DROP CONSTRAINT [FK_BaseTestPaperTestPaper];
GO
IF OBJECT_ID(N'[dbo].[FK_BaseTestPaperPaperQuestion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaperQuestionSet] DROP CONSTRAINT [FK_BaseTestPaperPaperQuestion];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TestQuestionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TestQuestionSet];
GO
IF OBJECT_ID(N'[dbo].[TestPaperSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TestPaperSet];
GO
IF OBJECT_ID(N'[dbo].[TeacherSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TeacherSet];
GO
IF OBJECT_ID(N'[dbo].[StudentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentSet];
GO
IF OBJECT_ID(N'[dbo].[CourseSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourseSet];
GO
IF OBJECT_ID(N'[dbo].[ScoreSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScoreSet];
GO
IF OBJECT_ID(N'[dbo].[ClassSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClassSet];
GO
IF OBJECT_ID(N'[dbo].[CommentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CommentSet];
GO
IF OBJECT_ID(N'[dbo].[CollectionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CollectionSet];
GO
IF OBJECT_ID(N'[dbo].[StudentTestResultSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentTestResultSet];
GO
IF OBJECT_ID(N'[dbo].[PaperQuestionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaperQuestionSet];
GO
IF OBJECT_ID(N'[dbo].[BaseTestPaperSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BaseTestPaperSet];
GO
IF OBJECT_ID(N'[dbo].[TeacherClass]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TeacherClass];
GO
IF OBJECT_ID(N'[dbo].[StudentCourse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentCourse];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TestQuestionSet'
CREATE TABLE [dbo].[TestQuestionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TestQuestionType] nvarchar(10)  NULL,
    [TestQuestionName] nvarchar(200)  NULL,
    [TestQuestionQuestion] nvarchar(500)  NULL,
    [TestQuestionGrade] int  NULL,
    [TestQuestionResult] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TestPaperSet'
CREATE TABLE [dbo].[TestPaperSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TestPaperStartTime] datetime  NULL,
    [TestPaperEndTime] datetime  NULL,
    [Course_CourseId] int  NOT NULL,
    [Student_StudentId] int  NOT NULL,
    [BaseTestPaper_Id] int  NOT NULL
);
GO

-- Creating table 'TeacherSet'
CREATE TABLE [dbo].[TeacherSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TeacherName] nvarchar(10)  NULL,
    [TeacherPwd] nvarchar(100)  NULL
);
GO

-- Creating table 'StudentSet'
CREATE TABLE [dbo].[StudentSet] (
    [StudentId] int  NOT NULL,
    [StudentName] nvarchar(20)  NULL,
    [StudentPwd] nvarchar(100)  NULL,
    [Class_Id] int  NOT NULL
);
GO

-- Creating table 'CourseSet'
CREATE TABLE [dbo].[CourseSet] (
    [CourseId] int IDENTITY(1,1) NOT NULL,
    [CourseName] nvarchar(20)  NULL
);
GO

-- Creating table 'ScoreSet'
CREATE TABLE [dbo].[ScoreSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Grade] int  NULL,
    [TestPaper_Id] int  NOT NULL,
    [Course_CourseId] int  NOT NULL
);
GO

-- Creating table 'ClassSet'
CREATE TABLE [dbo].[ClassSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClassName] nvarchar(20)  NULL
);
GO

-- Creating table 'CommentSet'
CREATE TABLE [dbo].[CommentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CommentContent] nvarchar(100)  NULL,
    [CommentTime] datetime  NULL,
    [Course_CourseId] int  NOT NULL
);
GO

-- Creating table 'CollectionSet'
CREATE TABLE [dbo].[CollectionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CollectionName] nvarchar(50)  NULL,
    [Student_StudentId] int  NOT NULL,
    [TestQuestion_Id] int  NOT NULL
);
GO

-- Creating table 'StudentTestResultSet'
CREATE TABLE [dbo].[StudentTestResultSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [QuestionResult] nvarchar(max)  NOT NULL,
    [TestPaper_Id] int  NOT NULL,
    [Student_StudentId] int  NOT NULL,
    [TestQuestion_Id] int  NOT NULL
);
GO

-- Creating table 'PaperQuestionSet'
CREATE TABLE [dbo].[PaperQuestionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TestQuestion_Id] int  NOT NULL,
    [BaseTestPaper_Id] int  NOT NULL
);
GO

-- Creating table 'BaseTestPaperSet'
CREATE TABLE [dbo].[BaseTestPaperSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BaseTestPaperName] nvarchar(max)  NULL,
    [BaseTestPaperCreateTime] datetime  NULL,
    [BaseTestPaperType] nvarchar(max)  NULL
);
GO

-- Creating table 'TeacherClass'
CREATE TABLE [dbo].[TeacherClass] (
    [Teacher_Id] int  NOT NULL,
    [Class_Id] int  NOT NULL
);
GO

-- Creating table 'StudentCourse'
CREATE TABLE [dbo].[StudentCourse] (
    [Student_StudentId] int  NOT NULL,
    [Course_CourseId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'TestQuestionSet'
ALTER TABLE [dbo].[TestQuestionSet]
ADD CONSTRAINT [PK_TestQuestionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TestPaperSet'
ALTER TABLE [dbo].[TestPaperSet]
ADD CONSTRAINT [PK_TestPaperSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TeacherSet'
ALTER TABLE [dbo].[TeacherSet]
ADD CONSTRAINT [PK_TeacherSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [StudentId] in table 'StudentSet'
ALTER TABLE [dbo].[StudentSet]
ADD CONSTRAINT [PK_StudentSet]
    PRIMARY KEY CLUSTERED ([StudentId] ASC);
GO

-- Creating primary key on [CourseId] in table 'CourseSet'
ALTER TABLE [dbo].[CourseSet]
ADD CONSTRAINT [PK_CourseSet]
    PRIMARY KEY CLUSTERED ([CourseId] ASC);
GO

-- Creating primary key on [Id] in table 'ScoreSet'
ALTER TABLE [dbo].[ScoreSet]
ADD CONSTRAINT [PK_ScoreSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClassSet'
ALTER TABLE [dbo].[ClassSet]
ADD CONSTRAINT [PK_ClassSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CommentSet'
ALTER TABLE [dbo].[CommentSet]
ADD CONSTRAINT [PK_CommentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CollectionSet'
ALTER TABLE [dbo].[CollectionSet]
ADD CONSTRAINT [PK_CollectionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StudentTestResultSet'
ALTER TABLE [dbo].[StudentTestResultSet]
ADD CONSTRAINT [PK_StudentTestResultSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PaperQuestionSet'
ALTER TABLE [dbo].[PaperQuestionSet]
ADD CONSTRAINT [PK_PaperQuestionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BaseTestPaperSet'
ALTER TABLE [dbo].[BaseTestPaperSet]
ADD CONSTRAINT [PK_BaseTestPaperSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Teacher_Id], [Class_Id] in table 'TeacherClass'
ALTER TABLE [dbo].[TeacherClass]
ADD CONSTRAINT [PK_TeacherClass]
    PRIMARY KEY CLUSTERED ([Teacher_Id], [Class_Id] ASC);
GO

-- Creating primary key on [Student_StudentId], [Course_CourseId] in table 'StudentCourse'
ALTER TABLE [dbo].[StudentCourse]
ADD CONSTRAINT [PK_StudentCourse]
    PRIMARY KEY CLUSTERED ([Student_StudentId], [Course_CourseId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Course_CourseId] in table 'TestPaperSet'
ALTER TABLE [dbo].[TestPaperSet]
ADD CONSTRAINT [FK_CourseTestPaper]
    FOREIGN KEY ([Course_CourseId])
    REFERENCES [dbo].[CourseSet]
        ([CourseId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseTestPaper'
CREATE INDEX [IX_FK_CourseTestPaper]
ON [dbo].[TestPaperSet]
    ([Course_CourseId]);
GO

-- Creating foreign key on [Teacher_Id] in table 'TeacherClass'
ALTER TABLE [dbo].[TeacherClass]
ADD CONSTRAINT [FK_TeacherClass_Teacher]
    FOREIGN KEY ([Teacher_Id])
    REFERENCES [dbo].[TeacherSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Class_Id] in table 'TeacherClass'
ALTER TABLE [dbo].[TeacherClass]
ADD CONSTRAINT [FK_TeacherClass_Class]
    FOREIGN KEY ([Class_Id])
    REFERENCES [dbo].[ClassSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeacherClass_Class'
CREATE INDEX [IX_FK_TeacherClass_Class]
ON [dbo].[TeacherClass]
    ([Class_Id]);
GO

-- Creating foreign key on [Class_Id] in table 'StudentSet'
ALTER TABLE [dbo].[StudentSet]
ADD CONSTRAINT [FK_ClassStudent]
    FOREIGN KEY ([Class_Id])
    REFERENCES [dbo].[ClassSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClassStudent'
CREATE INDEX [IX_FK_ClassStudent]
ON [dbo].[StudentSet]
    ([Class_Id]);
GO

-- Creating foreign key on [Student_StudentId] in table 'CollectionSet'
ALTER TABLE [dbo].[CollectionSet]
ADD CONSTRAINT [FK_StudentCollection]
    FOREIGN KEY ([Student_StudentId])
    REFERENCES [dbo].[StudentSet]
        ([StudentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentCollection'
CREATE INDEX [IX_FK_StudentCollection]
ON [dbo].[CollectionSet]
    ([Student_StudentId]);
GO

-- Creating foreign key on [Student_StudentId] in table 'StudentCourse'
ALTER TABLE [dbo].[StudentCourse]
ADD CONSTRAINT [FK_StudentCourse_Student]
    FOREIGN KEY ([Student_StudentId])
    REFERENCES [dbo].[StudentSet]
        ([StudentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Course_CourseId] in table 'StudentCourse'
ALTER TABLE [dbo].[StudentCourse]
ADD CONSTRAINT [FK_StudentCourse_Course]
    FOREIGN KEY ([Course_CourseId])
    REFERENCES [dbo].[CourseSet]
        ([CourseId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentCourse_Course'
CREATE INDEX [IX_FK_StudentCourse_Course]
ON [dbo].[StudentCourse]
    ([Course_CourseId]);
GO

-- Creating foreign key on [Course_CourseId] in table 'CommentSet'
ALTER TABLE [dbo].[CommentSet]
ADD CONSTRAINT [FK_CourseComment]
    FOREIGN KEY ([Course_CourseId])
    REFERENCES [dbo].[CourseSet]
        ([CourseId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseComment'
CREATE INDEX [IX_FK_CourseComment]
ON [dbo].[CommentSet]
    ([Course_CourseId]);
GO

-- Creating foreign key on [Student_StudentId] in table 'TestPaperSet'
ALTER TABLE [dbo].[TestPaperSet]
ADD CONSTRAINT [FK_StudentTestPaper]
    FOREIGN KEY ([Student_StudentId])
    REFERENCES [dbo].[StudentSet]
        ([StudentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentTestPaper'
CREATE INDEX [IX_FK_StudentTestPaper]
ON [dbo].[TestPaperSet]
    ([Student_StudentId]);
GO

-- Creating foreign key on [TestPaper_Id] in table 'StudentTestResultSet'
ALTER TABLE [dbo].[StudentTestResultSet]
ADD CONSTRAINT [FK_TestPaperStudentTestResult]
    FOREIGN KEY ([TestPaper_Id])
    REFERENCES [dbo].[TestPaperSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestPaperStudentTestResult'
CREATE INDEX [IX_FK_TestPaperStudentTestResult]
ON [dbo].[StudentTestResultSet]
    ([TestPaper_Id]);
GO

-- Creating foreign key on [Student_StudentId] in table 'StudentTestResultSet'
ALTER TABLE [dbo].[StudentTestResultSet]
ADD CONSTRAINT [FK_StudentStudentTestResult]
    FOREIGN KEY ([Student_StudentId])
    REFERENCES [dbo].[StudentSet]
        ([StudentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentStudentTestResult'
CREATE INDEX [IX_FK_StudentStudentTestResult]
ON [dbo].[StudentTestResultSet]
    ([Student_StudentId]);
GO

-- Creating foreign key on [TestQuestion_Id] in table 'CollectionSet'
ALTER TABLE [dbo].[CollectionSet]
ADD CONSTRAINT [FK_TestQuestionCollection]
    FOREIGN KEY ([TestQuestion_Id])
    REFERENCES [dbo].[TestQuestionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestQuestionCollection'
CREATE INDEX [IX_FK_TestQuestionCollection]
ON [dbo].[CollectionSet]
    ([TestQuestion_Id]);
GO

-- Creating foreign key on [TestQuestion_Id] in table 'StudentTestResultSet'
ALTER TABLE [dbo].[StudentTestResultSet]
ADD CONSTRAINT [FK_TestQuestionStudentTestResult]
    FOREIGN KEY ([TestQuestion_Id])
    REFERENCES [dbo].[TestQuestionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestQuestionStudentTestResult'
CREATE INDEX [IX_FK_TestQuestionStudentTestResult]
ON [dbo].[StudentTestResultSet]
    ([TestQuestion_Id]);
GO

-- Creating foreign key on [TestQuestion_Id] in table 'PaperQuestionSet'
ALTER TABLE [dbo].[PaperQuestionSet]
ADD CONSTRAINT [FK_TestQuestionPaperQuestion]
    FOREIGN KEY ([TestQuestion_Id])
    REFERENCES [dbo].[TestQuestionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestQuestionPaperQuestion'
CREATE INDEX [IX_FK_TestQuestionPaperQuestion]
ON [dbo].[PaperQuestionSet]
    ([TestQuestion_Id]);
GO

-- Creating foreign key on [TestPaper_Id] in table 'ScoreSet'
ALTER TABLE [dbo].[ScoreSet]
ADD CONSTRAINT [FK_TestPaperScore]
    FOREIGN KEY ([TestPaper_Id])
    REFERENCES [dbo].[TestPaperSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestPaperScore'
CREATE INDEX [IX_FK_TestPaperScore]
ON [dbo].[ScoreSet]
    ([TestPaper_Id]);
GO

-- Creating foreign key on [Course_CourseId] in table 'ScoreSet'
ALTER TABLE [dbo].[ScoreSet]
ADD CONSTRAINT [FK_CourseScore]
    FOREIGN KEY ([Course_CourseId])
    REFERENCES [dbo].[CourseSet]
        ([CourseId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseScore'
CREATE INDEX [IX_FK_CourseScore]
ON [dbo].[ScoreSet]
    ([Course_CourseId]);
GO

-- Creating foreign key on [BaseTestPaper_Id] in table 'TestPaperSet'
ALTER TABLE [dbo].[TestPaperSet]
ADD CONSTRAINT [FK_BaseTestPaperTestPaper]
    FOREIGN KEY ([BaseTestPaper_Id])
    REFERENCES [dbo].[BaseTestPaperSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BaseTestPaperTestPaper'
CREATE INDEX [IX_FK_BaseTestPaperTestPaper]
ON [dbo].[TestPaperSet]
    ([BaseTestPaper_Id]);
GO

-- Creating foreign key on [BaseTestPaper_Id] in table 'PaperQuestionSet'
ALTER TABLE [dbo].[PaperQuestionSet]
ADD CONSTRAINT [FK_BaseTestPaperPaperQuestion]
    FOREIGN KEY ([BaseTestPaper_Id])
    REFERENCES [dbo].[BaseTestPaperSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BaseTestPaperPaperQuestion'
CREATE INDEX [IX_FK_BaseTestPaperPaperQuestion]
ON [dbo].[PaperQuestionSet]
    ([BaseTestPaper_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------