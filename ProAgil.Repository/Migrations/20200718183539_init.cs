﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProAgil.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Local = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Theme = table.Column<string>(nullable: true),
                    AmountPeople = table.Column<int>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    ResumeCurriculum = table.Column<string>(nullable: true),
                    ImageURL = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    price = table.Column<decimal>(nullable: false),
                    InitialDate = table.Column<DateTime>(nullable: true),
                    FinalDate = table.Column<DateTime>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lots_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialNetworks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    EventId = table.Column<int>(nullable: true),
                    SpeakerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialNetworks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialNetworks_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SocialNetworks_Speakers_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "Speakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "speakerEvents",
                columns: table => new
                {
                    SpeakerId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_speakerEvents", x => new { x.EventId, x.SpeakerId });
                    table.ForeignKey(
                        name: "FK_speakerEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_speakerEvents_Speakers_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "Speakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lots_EventId",
                table: "Lots",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialNetworks_EventId",
                table: "SocialNetworks",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialNetworks_SpeakerId",
                table: "SocialNetworks",
                column: "SpeakerId");

            migrationBuilder.CreateIndex(
                name: "IX_speakerEvents_SpeakerId",
                table: "speakerEvents",
                column: "SpeakerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lots");

            migrationBuilder.DropTable(
                name: "SocialNetworks");

            migrationBuilder.DropTable(
                name: "speakerEvents");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Speakers");
        }
    }
}
