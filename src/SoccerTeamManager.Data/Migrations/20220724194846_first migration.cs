using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoccerTeamManager.Infra.Data.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "manager");

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "manager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                schema: "manager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Location = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tournament",
                schema: "manager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Prize = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournament", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                schema: "manager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "manager",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Player_Team_CurrentTeamId",
                        column: x => x.CurrentTeamId,
                        principalSchema: "manager",
                        principalTable: "Team",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Match",
                schema: "manager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HomeTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Team_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalSchema: "manager",
                        principalTable: "Team",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Match_Team_VisitorTeamId",
                        column: x => x.VisitorTeamId,
                        principalSchema: "manager",
                        principalTable: "Team",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Match_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalSchema: "manager",
                        principalTable: "Tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TounamentTeam",
                schema: "manager",
                columns: table => new
                {
                    TournamentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TounamentTeam", x => new { x.TeamId, x.TournamentId });
                    table.ForeignKey(
                        name: "FK_TounamentTeam_Team_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "manager",
                        principalTable: "Team",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TounamentTeam_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalSchema: "manager",
                        principalTable: "Tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transfer",
                schema: "manager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OriginTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DestinationTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ammount = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transfer_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "manager",
                        principalTable: "Player",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transfer_Team_DestinationTeamId",
                        column: x => x.DestinationTeamId,
                        principalSchema: "manager",
                        principalTable: "Team",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transfer_Team_OriginTeamId",
                        column: x => x.OriginTeamId,
                        principalSchema: "manager",
                        principalTable: "Team",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MatchEvent",
                schema: "manager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventType = table.Column<int>(type: "int", nullable: false),
                    TimeOfOccurrence = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchEvent_Match_MatchId",
                        column: x => x.MatchId,
                        principalSchema: "manager",
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchEvent_Team_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "manager",
                        principalTable: "Team",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "manager",
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00991368-53d0-4330-9c8e-845255f75528"), "Islândia" },
                    { new Guid("00e5d5b8-8068-4b71-b845-b2ba31844372"), "Albânia" },
                    { new Guid("013de31c-4205-45eb-9ff5-f1e37f1585c1"), "Turquemenistão" },
                    { new Guid("02b2f401-c49b-49c2-a0ca-dee20ad4e914"), "Ucrânia" },
                    { new Guid("02fb11d6-44a3-4d83-8dab-cfef104d8a65"), "São Vicente e Granadinas" },
                    { new Guid("070f5e16-3097-4a1d-a0aa-575d072f6c0f"), "Lituânia" },
                    { new Guid("0879c72a-509f-4ff8-9115-bc753b0d617e"), "Quirguistão" },
                    { new Guid("095d2bd6-a470-466b-9f69-28688c321135"), "Etiópia" },
                    { new Guid("0cd4f6f1-ac99-4e35-a250-7289079705b3"), "Eslováquia" },
                    { new Guid("0d1f3ead-0262-43bf-b813-0eadac337814"), "Guiné" },
                    { new Guid("0f244428-36e9-4cf6-8657-d369a2f09a3a"), "Nova Zelândia" },
                    { new Guid("0f3f4548-9509-46eb-9560-2a05acc167df"), "Kiribati" },
                    { new Guid("0f43e3c9-4aef-4b9d-80ba-39625d4fe57c"), "Tunísia" },
                    { new Guid("119d39bc-4ac7-405c-9afd-3de2fc1aeb41"), "Guiné-Bissau" },
                    { new Guid("13de203a-ff82-42c9-9161-df6239db79b1"), "Botswana" },
                    { new Guid("14472b5b-2f1d-4918-b93f-d78c117ac5ba"), "Síria" },
                    { new Guid("147d8fd0-aaf5-4b6b-9293-7da24b3755e6"), "Liechtenstein" },
                    { new Guid("1679fe4c-aa38-4133-84a2-d5bfbba8d2cc"), "Congo" },
                    { new Guid("168a1966-44b5-42ab-915d-f38fd98ed15f"), "Azerbaijão" },
                    { new Guid("1a8014e6-ee2a-47b4-b068-d02e42e20f56"), "Tonga" },
                    { new Guid("1b085c81-6f84-4565-be4c-2b58a6726846"), "Nepal" },
                    { new Guid("1d30f1a5-be50-42ff-aa27-817625af4d3a"), "Gana" },
                    { new Guid("1f22ccc9-5c01-4822-878e-3667b42ef45a"), "Nigéria" },
                    { new Guid("1f654aa3-ccff-49b9-b707-c4a5770f46fe"), "Roménia" },
                    { new Guid("21fe3f6e-8afa-4dcb-9046-246eb944933f"), "Taiwan" },
                    { new Guid("220d14c3-1e13-435b-b61c-c9e550efc78d"), "Argentina" },
                    { new Guid("2230da33-01dc-4943-acc8-db864c689aaf"), "Mongólia" },
                    { new Guid("24689ab8-5446-4343-b328-977f7359ee22"), "Sudão" },
                    { new Guid("25d5922a-10e5-4033-9e5d-3de96c26bdf9"), "Tuvalu" },
                    { new Guid("27ae81d9-9bf4-4195-8655-1ad6f492252d"), "Níger" },
                    { new Guid("27b43733-4a18-457b-b351-24bf9342c85e"), "África do Sul" },
                    { new Guid("2911f66f-2387-4f47-bbf4-c5b9b7914061"), "Grécia" },
                    { new Guid("2bedc06b-9c54-4bd0-a386-74efb3a0f7a6"), "Egito" },
                    { new Guid("2d30360d-4ac7-425c-9ebd-d926bd689ac8"), "Eritreia" },
                    { new Guid("2e03c212-8790-449f-9214-011911071547"), "Paquistão" },
                    { new Guid("2f96fbcf-5b3d-4c11-9622-84e2c4dd4f16"), "Mali" },
                    { new Guid("315c6b66-92aa-492c-b9e7-1d54646d7b5a"), "Moldova" },
                    { new Guid("31e01861-302e-4043-8053-93e657283e0b"), "China" },
                    { new Guid("32a7dfb7-9c6b-422a-8ed1-f517779a35ae"), "Chile" },
                    { new Guid("336d26bd-0fd8-472f-9a56-cd86cf3a4ea3"), "Equador" },
                    { new Guid("33ad93ac-da3b-4774-bfc4-11bb1263c748"), "Singapura" },
                    { new Guid("33f80a4e-94de-4d30-9271-feec67dec0a3"), "Bielorrússia" }
                });

            migrationBuilder.InsertData(
                schema: "manager",
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("342fc316-d2df-4496-a86e-45a594a1dcd3"), "São Tomé e Príncipe" },
                    { new Guid("36d61e9e-8e62-4082-bec6-6211c5f4d18b"), "Letónia" },
                    { new Guid("36fc336a-c3ba-4994-a1f3-5cc9c1c0c046"), "Suíça" },
                    { new Guid("391cebd1-0f01-4e6c-bf83-a6525de95d9f"), "Granada" },
                    { new Guid("396be8ae-0580-4689-a8ed-17d3a3f03317"), "Trinidad e Tobago" },
                    { new Guid("3bfa7236-e0d8-4a84-8597-f21d20650c68"), "Geórgia" },
                    { new Guid("3c897ea8-ca5d-4b21-b17d-7de8a9eaaedf"), "Uganda" },
                    { new Guid("43229c73-1bb4-41f5-8c97-f6ab98fd27ca"), "Jamaica" },
                    { new Guid("45075423-6f2b-48b3-9c2d-d742e3e49ce8"), "Líbano" },
                    { new Guid("45dac392-0617-4aa3-9b89-b1f9111a15e2"), "Andorra" },
                    { new Guid("45eb3af2-2179-49c4-9229-62fac06d15f1"), "Portugal" },
                    { new Guid("46b43b0f-b112-459a-bd6c-db23b5b1b6f0"), "Antígua e Barbuda" },
                    { new Guid("4764f32d-6cc2-4d8a-ab01-e91f1f63367d"), "Emirados Árabes Unidos" },
                    { new Guid("48914052-1b5a-4f14-ad89-1ae4acc632ab"), "Luxemburgo" },
                    { new Guid("49c235e4-0edf-40d3-9e6f-a7ff3793a3b3"), "Turquia" },
                    { new Guid("49c91c4f-d494-41ee-b055-e3e05b1ef387"), "Índia" },
                    { new Guid("4bc4f063-d2f0-404f-b9be-aded85e8fb70"), "Domínica" },
                    { new Guid("4cbadb5d-b125-455d-b6e9-a0529c6a43a1"), "França" },
                    { new Guid("4ce69068-1117-4084-a741-283fec883afb"), "Israel" },
                    { new Guid("4dd7774d-54a6-4ba7-8bdd-4ba994015c5f"), "Reino Unido" },
                    { new Guid("4ebaddd0-fc98-43fb-ae6d-f79898597bab"), "México" },
                    { new Guid("4f1bf909-02f5-418b-80bf-d96e4d69c5bf"), "Líbia" },
                    { new Guid("4f690532-b31e-4849-a101-fe3dc4721729"), "Costa Rica" },
                    { new Guid("4ff84a83-5a5f-430f-8ae5-be22f276ad01"), "Togo" },
                    { new Guid("50391ece-28cb-4229-8538-15ccdf7e0f69"), "Ruanda" },
                    { new Guid("515b4eaf-5bd4-458e-8adb-65fdf8531ebd"), "Suriname" },
                    { new Guid("51c134e3-fe74-4784-84df-ab6505c13c81"), "Cuba" },
                    { new Guid("51dd00bc-7eb0-4051-8933-f205ce9cb86c"), "Guiana" },
                    { new Guid("528ba571-103a-4281-bd6b-14b5497a9fbb"), "Iraque" },
                    { new Guid("540e51a9-ad3f-41e2-a43c-ccea29e00e29"), "Áustria" },
                    { new Guid("54b2e832-0b62-49a5-9115-3e711616a28e"), "Kuwait" },
                    { new Guid("55f1d300-d8de-41ab-a4ae-428a4b97e92b"), "Malta" },
                    { new Guid("57be866b-ec21-48eb-b2f7-df09a4c32bb6"), "Países Baixos" },
                    { new Guid("584082a4-d598-4213-bd5d-d6169129c148"), "Bahrein" },
                    { new Guid("5a582021-4c94-4850-95ba-9ae51d227fdf"), "Iémen" },
                    { new Guid("5aa48457-e238-4d83-9a43-0b66621617ac"), "Jordânia" },
                    { new Guid("5db97174-312a-4a03-9fae-43dc53263729"), "Libéria" },
                    { new Guid("5e033453-5b83-4018-aab2-c45d247d332a"), "Coreia do Sul" },
                    { new Guid("62fd3f65-35b8-4fe7-b589-fefa18acc66c"), "Maldivas" },
                    { new Guid("633590bc-fba7-4ae5-80b0-7f27b8eb14ec"), "Hungria" },
                    { new Guid("64497306-3478-43e8-aee1-e147f23c29ac"), "São Cristóvão e Nevis" },
                    { new Guid("6481e21b-e815-40fd-997a-a3baa82bdb45"), "Palau" }
                });

            migrationBuilder.InsertData(
                schema: "manager",
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("65016704-8a3a-4158-8554-be4c32419e5c"), "Vaticano" },
                    { new Guid("68607d3c-5c75-49d5-b10f-3000e00f62f4"), "Tajiquistão" },
                    { new Guid("68e160ff-fc89-4487-b9df-d29f3561a21d"), "San Marino" },
                    { new Guid("6bd09f91-560f-47ae-8634-f643f42cebd6"), "Catar" },
                    { new Guid("6bdc3ea6-af88-47c8-8c13-c6a1e1cda841"), "Gâmbia" },
                    { new Guid("6e5f6a44-0c70-4ae8-9fd3-fa65ff101648"), "Finlândia" },
                    { new Guid("6e7c53b0-e03f-4a79-9381-5ebb8c96ff60"), "Peru" },
                    { new Guid("6ea03f9b-68d7-4f97-b53b-067517633830"), "Palestina" },
                    { new Guid("70dd5979-a466-4434-8168-680b80fb9952"), "Djibouti" },
                    { new Guid("70f36751-e881-426e-85f0-975575604047"), "Arménia" },
                    { new Guid("7137cbb1-e693-4e4b-b113-ffe6ffbfdcd2"), "Honduras" },
                    { new Guid("74c835cf-e427-4a39-8056-025a1cf26ed8"), "Namíbia" },
                    { new Guid("74f976f5-97d3-4829-9066-039fb574938b"), "Afeganistão" },
                    { new Guid("76565a86-479c-417a-99fe-ab1e86e1da0c"), "Bangladesh" },
                    { new Guid("775c47e5-f7a1-4d7f-ac0f-be458553d8cb"), "Costa do Marfim" },
                    { new Guid("77e0c6eb-0513-4bc6-b98b-941f21a599bf"), "Haiti" },
                    { new Guid("7b9f3378-9969-4870-a065-76f385b99b95"), "Myanmar" },
                    { new Guid("7c6bd35c-e9a8-4341-a194-b34802723ce0"), "Ilhas Cook" },
                    { new Guid("7c7f0231-1f8f-4204-abde-42e90805aa10"), "Indonésia" },
                    { new Guid("7cb4aba3-d2b4-4f8e-bc62-9e67684b2d72"), "Croácia" },
                    { new Guid("7eef5b51-1ad9-4672-8477-5b7c4c6fd149"), "Uzbequistão" },
                    { new Guid("7fa01317-dbdb-4de8-92c7-3d93b4aec9b6"), "Chéquia" },
                    { new Guid("7ff8f1a0-8597-41a1-a6f9-a9804c1ba17b"), "Bósnia e Herzegovina" },
                    { new Guid("83b30064-8abb-4dd3-9fc6-d2010e70dad9"), "Ilhas Marshall" },
                    { new Guid("879ca88f-ec5f-47b5-8afb-8440fca390aa"), "Coreia do Norte" },
                    { new Guid("882c73fb-bd56-4a8e-a4f6-d5052a48c11b"), "Malawi" },
                    { new Guid("8a1ea897-03a1-493e-bc9e-87c25e7967cd"), "Timor-Leste" },
                    { new Guid("8ab75f0e-0112-419f-b438-251de1fabaac"), "Tanzânia" },
                    { new Guid("8bc3a114-d23c-4c82-aae5-51839147fdf3"), "Malásia" },
                    { new Guid("8c3b3c6d-3a92-4521-af49-63b8f5beac2f"), "Colômbia" },
                    { new Guid("8d698e06-11c6-4bf3-97ff-89abd73c0378"), "Burquina Fasso" },
                    { new Guid("8fe39b2c-8b61-4b8a-b98d-39153828d198"), "El Salvador" },
                    { new Guid("93510797-3613-4d63-ae5a-12263bac31dd"), "Sérvia" },
                    { new Guid("936d1675-d34c-4bc1-8ad5-85380c607142"), "Panamá" },
                    { new Guid("966e2fa6-c405-465c-a309-dba8726bba1a"), "Nauru" },
                    { new Guid("98b524af-9652-42f9-93cb-029a2dac6b93"), "Barbados" },
                    { new Guid("99ef42d7-c2e2-46fb-961b-c15b80ec1a90"), "Venezuela" },
                    { new Guid("9b93607b-eea9-4f5d-9e12-2cdf881dca2f"), "Butão" },
                    { new Guid("9bb2b900-51a8-42ba-8afc-fd341a26e71c"), "Eswatini" },
                    { new Guid("9bb6d729-bc7c-426e-bc20-29cd7094c13e"), "República Dominicana" },
                    { new Guid("9c758af6-f29e-4467-bbd3-1914777af329"), "Canadá" },
                    { new Guid("9d19150a-3031-4d2a-bde4-5c85791c7d20"), "Austrália" }
                });

            migrationBuilder.InsertData(
                schema: "manager",
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("9ef4b377-17cf-4df7-989e-81c5d9efd5ce"), "Madagascar" },
                    { new Guid("9f1bb5b2-43dc-4283-aec5-0965eb5f6541"), "Montenegro" },
                    { new Guid("a1003dd4-69db-4554-83ea-491a1bff0966"), "Noruega" },
                    { new Guid("a1bf80cb-5e25-4810-8606-84d2b02f58a9"), "Marrocos" },
                    { new Guid("a22f7f05-1e70-432b-83c8-1ca9f0c02e8f"), "Senegal" },
                    { new Guid("a37b3dec-cb00-4134-aadf-caf98947aab2"), "Samoa" },
                    { new Guid("a5e572bb-42bc-49e3-b81d-c3ba66d9dbb5"), "Eslovénia" },
                    { new Guid("a68a38fc-4bd4-44be-a497-b6d2a232eacb"), "Camboja" },
                    { new Guid("a6f038bc-9b31-4aff-ba95-06f8deee54d3"), "Niue" },
                    { new Guid("a81660ef-71ea-4d5f-b692-65c908ba0b3d"), "Camarões" },
                    { new Guid("a9a601d0-0815-4db1-b936-4599159d8611"), "Mónaco" },
                    { new Guid("aafa7339-c327-4be7-8e5c-172a64d2bd13"), "Zâmbia" },
                    { new Guid("b1da1d6d-918a-46de-b58a-a00de674c394"), "Argélia" },
                    { new Guid("b3bb3865-f7ac-4ddc-9d1e-e60a85ed42b8"), "Burundi" },
                    { new Guid("b4270269-9b71-41eb-be5b-9758b9d6f584"), "Paraguai" },
                    { new Guid("b5072123-2daa-4af2-aab3-f889e90de30e"), "Belize" },
                    { new Guid("b56be92f-26cd-4b70-8684-9e8fe72d4614"), "Vanuatu" },
                    { new Guid("b5b16750-b2a8-4463-95b7-9434027ce17b"), "Oman" },
                    { new Guid("b8fa010a-af34-4112-9141-3a8913398ae7"), "Bahamas" },
                    { new Guid("b994a324-b7ef-4ed5-9d49-dabf071acc7c"), "Kosovo" },
                    { new Guid("b9f4148a-5de9-42c7-bfed-50a4b7fb10c6"), "Chipre" },
                    { new Guid("ba24229a-dd47-4991-98dc-2450913655f2"), "Zimbabwe" },
                    { new Guid("bb367dca-a3a0-4901-8d9f-d33713a3d717"), "Sudão do Sul" },
                    { new Guid("bcd73797-ab01-4980-bff3-743a0893554a"), "Estados Federados da Micronésia" },
                    { new Guid("bea3d1ae-5911-413c-bdfd-2c004fcf9cd8"), "Macedônia do Norte" },
                    { new Guid("bf6b9bf9-f374-4081-a581-a47d50ae454f"), "Ilhas Salomão" },
                    { new Guid("c0163725-b0ab-4975-9b99-cc39fca83ac1"), "Brunei" },
                    { new Guid("c090c589-8723-4c07-9451-eae5cc7ac14e"), "Maurícia" },
                    { new Guid("c10f30f5-c5f2-4763-823e-5add75e5a22f"), "Guatemala" },
                    { new Guid("c3ff1054-b6b1-4d10-a69d-4ab584c6bf6c"), "Brasil" },
                    { new Guid("c455146b-19aa-45f9-b5e1-869f4512300c"), "Laos" },
                    { new Guid("c7b51974-e637-433a-a6c4-e81a6323418f"), "Bolívia" },
                    { new Guid("c8113511-b443-48f3-a056-4b24fa60b1e4"), "Japão" },
                    { new Guid("ca071d1e-47ce-403e-94c8-5d9a226eccf7"), "República Democrática do Congo" },
                    { new Guid("ca7c396c-b782-44b1-adee-0b84f2782108"), "Guiné Equatorial" },
                    { new Guid("cb141323-8763-4884-8793-9439663dc4e6"), "Somália" },
                    { new Guid("cc9b146c-72d9-42b7-88c1-69c4463153d0"), "Moçambique" },
                    { new Guid("cd8a4f9a-a3d0-4a44-8a24-355fbba96f3b"), "Filipinas" },
                    { new Guid("d01de4da-8832-4690-873d-10c935aefd2a"), "Cabo Verde" },
                    { new Guid("d0f1febc-1b4b-42d5-8896-d9e65e2f1605"), "Uruguai" },
                    { new Guid("d3e9c4d3-f026-45b1-8918-257b83e83c07"), "Chade" },
                    { new Guid("d4d83b4b-7617-4b50-9069-e55792b6cba3"), "Nicarágua" }
                });

            migrationBuilder.InsertData(
                schema: "manager",
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("d57bd05d-8fa3-4860-b32d-7df88b10fc25"), "Benim" },
                    { new Guid("d5b3a5ea-717c-4a26-bff4-502b6fc80dc4"), "Espanha" },
                    { new Guid("d663bffe-8ec4-4b9c-b399-5bfe5d3f2daa"), "Lesoto" },
                    { new Guid("d9c80cbd-d856-400a-bab0-7434c9724f26"), "Gabão" },
                    { new Guid("da6fdeb8-4d1a-47e6-a29a-bed08bb4d806"), "Seicheles" },
                    { new Guid("db0ce644-0ace-483c-83bb-1e7a2ace9f1e"), "Irlanda" },
                    { new Guid("db155c1b-5c28-46d3-8f37-5752f938b822"), "Tailândia" },
                    { new Guid("db2d7dcd-217a-42b0-ba60-e297418aa5fc"), "Polónia" },
                    { new Guid("dc88c5d7-c207-4887-bf11-f90b21e18d1e"), "Estónia" },
                    { new Guid("e14140f6-030c-428f-9daa-d8a19bd7134c"), "Dinamarca" },
                    { new Guid("e2f19816-b102-49ef-8621-98f62417ab79"), "Angola" },
                    { new Guid("e30d86b3-d072-4223-8257-d574d96c72f4"), "Bulgária" },
                    { new Guid("e7885114-20fd-4341-aa23-7a0256b6763f"), "Itália" },
                    { new Guid("e7efd9b9-1510-4ca5-85cb-b339851eb29f"), "Irã" },
                    { new Guid("e9a95b4b-c527-45c4-acae-87a05f1c621e"), "Rússia" },
                    { new Guid("ea73113f-8da6-4c5d-80d2-425f0fd6687f"), "Sri Lanka" },
                    { new Guid("ea8ea1c2-50c3-49f9-bb20-94f7c36146f4"), "República Centro-Africana" },
                    { new Guid("ebb552ee-8f95-48d6-a897-56c17d1379c8"), "Mauritânia" },
                    { new Guid("ec396596-10a3-4b11-a855-3a23a884002f"), "Papua-Nova Guiné" },
                    { new Guid("ef80fdca-b078-4f14-9261-1ff1df966d1a"), "Bélgica" },
                    { new Guid("f2079f97-7806-45cc-a134-96fa9768efb5"), "Suécia" },
                    { new Guid("f2b93b1c-fe13-459d-bee1-bb0217cb73db"), "Estados Unidos" },
                    { new Guid("f6044414-e105-447a-8e6e-23305312bdf4"), "Alemanha" },
                    { new Guid("f687ba94-af29-457e-9be5-026fc7cc5145"), "Serra Leoa" },
                    { new Guid("f9dd348b-ec92-410b-84ea-fcce72d6ebf0"), "Fiji" },
                    { new Guid("fb2c3e0a-7840-4a0f-bc3e-6d0f3f2cf7d7"), "Vietname" },
                    { new Guid("fd47067b-30d1-459b-95e0-e5dbea643f50"), "Comores" },
                    { new Guid("fd6f11e7-38fc-48f7-9295-c298c528388c"), "Quénia" },
                    { new Guid("fdcfe383-1ae4-4a1a-a13d-e549dda731c2"), "Cazaquistão" },
                    { new Guid("ff124944-1857-4966-846b-1b383fc52108"), "Arábia Saudita" }
                });

            migrationBuilder.InsertData(
                schema: "manager",
                table: "Tournament",
                columns: new[] { "Id", "CreatedAt", "Name", "Prize", "UpdatedAt" },
                values: new object[] { new Guid("4ca3cc49-f22d-4cce-aaf6-61011dea48fd"), new DateTime(2022, 7, 24, 16, 48, 45, 876, DateTimeKind.Local).AddTicks(2329), "Amistoso", 0.0, null });

            migrationBuilder.CreateIndex(
                name: "IX_Match_HomeTeamId",
                schema: "manager",
                table: "Match",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_TournamentId",
                schema: "manager",
                table: "Match",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_VisitorTeamId",
                schema: "manager",
                table: "Match",
                column: "VisitorTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchEvent_MatchId",
                schema: "manager",
                table: "MatchEvent",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchEvent_TeamId",
                schema: "manager",
                table: "MatchEvent",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_CountryId",
                schema: "manager",
                table: "Player",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Cpf",
                schema: "manager",
                table: "Player",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_CurrentTeamId",
                schema: "manager",
                table: "Player",
                column: "CurrentTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_Cnpj",
                schema: "manager",
                table: "Team",
                column: "Cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TounamentTeam_TournamentId",
                schema: "manager",
                table: "TounamentTeam",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_DestinationTeamId",
                schema: "manager",
                table: "Transfer",
                column: "DestinationTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_OriginTeamId",
                schema: "manager",
                table: "Transfer",
                column: "OriginTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_PlayerId",
                schema: "manager",
                table: "Transfer",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchEvent",
                schema: "manager");

            migrationBuilder.DropTable(
                name: "TounamentTeam",
                schema: "manager");

            migrationBuilder.DropTable(
                name: "Transfer",
                schema: "manager");

            migrationBuilder.DropTable(
                name: "Match",
                schema: "manager");

            migrationBuilder.DropTable(
                name: "Player",
                schema: "manager");

            migrationBuilder.DropTable(
                name: "Tournament",
                schema: "manager");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "manager");

            migrationBuilder.DropTable(
                name: "Team",
                schema: "manager");
        }
    }
}
