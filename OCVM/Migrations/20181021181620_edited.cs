using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OCVM.Migrations
{
    public partial class edited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalDetail",
                columns: table => new
                {
                    PersonalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true),
                    FathersName = table.Column<string>(nullable: true),
                    MothersName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    Religion = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    MaritalStatus = table.Column<string>(nullable: true),
                    UserPicture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalDetail", x => x.PersonalID);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Objective = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    LinkdInUrl = table.Column<string>(nullable: true),
                    PersonalID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactID);
                    table.ForeignKey(
                        name: "FK_Contacts_PersonalDetail_PersonalID",
                        column: x => x.PersonalID,
                        principalTable: "PersonalDetail",
                        principalColumn: "PersonalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    ExperienceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Company_Name = table.Column<string>(nullable: true),
                    Company_Business = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    start_Date = table.Column<DateTime>(nullable: true),
                    End_Date = table.Column<DateTime>(nullable: true),
                    Skill = table.Column<string>(nullable: true),
                    PersonalID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.ExperienceID);
                    table.ForeignKey(
                        name: "FK_Experiences_PersonalDetail_PersonalID",
                        column: x => x.PersonalID,
                        principalTable: "PersonalDetail",
                        principalColumn: "PersonalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    TrainingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Training_Title = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Topics_Covered = table.Column<string>(nullable: true),
                    Training_Year = table.Column<int>(nullable: true),
                    Institute = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    PersonalID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.TrainingID);
                    table.ForeignKey(
                        name: "FK_Trainings_PersonalDetail_PersonalID",
                        column: x => x.PersonalID,
                        principalTable: "PersonalDetail",
                        principalColumn: "PersonalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    EduID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Exam_Degree_Title = table.Column<string>(nullable: true),
                    Group_Major_Subject = table.Column<string>(nullable: true),
                    Institute_University = table.Column<string>(nullable: true),
                    Result = table.Column<string>(nullable: true),
                    CGPA = table.Column<decimal>(nullable: true),
                    Scale = table.Column<decimal>(nullable: true),
                    Year_Of_Passing = table.Column<int>(nullable: true),
                    Duration = table.Column<int>(nullable: true),
                    Achievement = table.Column<string>(nullable: true),
                    PersonalID = table.Column<int>(nullable: false),
                    TrainingDetailsTrainingID = table.Column<int>(nullable: true),
                    TraningID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.EduID);
                    table.ForeignKey(
                        name: "FK_Educations_PersonalDetail_PersonalID",
                        column: x => x.PersonalID,
                        principalTable: "PersonalDetail",
                        principalColumn: "PersonalID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Educations_Trainings_TrainingDetailsTrainingID",
                        column: x => x.TrainingDetailsTrainingID,
                        principalTable: "Trainings",
                        principalColumn: "TrainingID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_PersonalID",
                table: "Contacts",
                column: "PersonalID");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_PersonalID",
                table: "Educations",
                column: "PersonalID");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_TrainingDetailsTrainingID",
                table: "Educations",
                column: "TrainingDetailsTrainingID");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_PersonalID",
                table: "Experiences",
                column: "PersonalID");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_PersonalID",
                table: "Trainings",
                column: "PersonalID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "PersonalDetail");
        }
    }
}
