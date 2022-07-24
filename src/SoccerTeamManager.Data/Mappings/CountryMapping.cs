using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManager.Domain.Entities;

namespace SoccerTeamManager.Infra.Data.Mappings
{
    public class CountryMapping : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(256).IsRequired();
            builder.Ignore(c => c.CreatedAt);
            builder.Ignore(c => c.UpdatedAt);

            builder.HasMany<Player>()
                .WithOne()
                .HasForeignKey(p => p.CountryId);

            builder.HasData(
                new Country(Guid.Parse("65eb81f8-db1e-4163-9c90-bb4fd9b65f94"), "Papua-Nova Guiné"),
                new Country(Guid.Parse("670e56c4-d7e6-44ce-ac37-a88b55abdc21"), "Kosovo"),
                new Country(Guid.Parse("67e75916-9db0-4623-bcfc-1ee3ef225029"), "Quénia"),
                new Country(Guid.Parse("68636bfc-ed88-4023-89b3-03e2383e860d"), "Líbia"),
                new Country(Guid.Parse("69a7d8ea-dd3d-4800-a478-a3c4975ae04b"), "Islândia"),
                new Country(Guid.Parse("69fbcd91-5fdd-4398-ade6-74df53dad48b"), "Estados Federados da Micronésia"),
                new Country(Guid.Parse("6a151a4c-567c-400d-aa4a-2d0750058a53"), "Arábia Saudita"),
                new Country(Guid.Parse("6ad0f8f0-aee4-4fd5-92d9-d445de116ad5"), "Uganda"),
                new Country(Guid.Parse("6b460187-bd37-4f7a-96aa-2d3980dc8418"), "Luxemburgo"),
                new Country(Guid.Parse("6eec0fb5-a995-4ade-a1f0-8cca506252b7"), "Bahamas"),
                new Country(Guid.Parse("702ee59c-5c61-454f-a02e-16f82ad4eb9f"), "Eswatini"),
                new Country(Guid.Parse("724dbf2f-6109-4485-9d82-15c5ca43a0f7"), "Malta"),
                new Country(Guid.Parse("73e37f95-c007-4241-9ab0-88c38f65fdae"), "Montenegro"),
                new Country(Guid.Parse("74e11c70-9ee3-4489-9ec1-08fcaea6c657"), "Mauritânia"),
                new Country(Guid.Parse("78b121a9-8ac7-4f56-b957-cb05c025a406"), "Domínica"),
                new Country(Guid.Parse("7da4a0de-602e-438c-833f-c6b50800cb21"), "Austrália"),
                new Country(Guid.Parse("7f1a9f2e-f553-43d2-998b-e36179c9cbca"), "Bangladesh"),
                new Country(Guid.Parse("7fa499d5-9d50-4b6c-a02f-27c26c1dd40f"), "Somália"),
                new Country(Guid.Parse("810ea211-0535-4288-8067-0466f9550310"), "China"),
                new Country(Guid.Parse("828d09b5-187b-4415-a979-ee691962bc8a"), "Bolívia"),
                new Country(Guid.Parse("84d9fa82-b5b6-47c0-9690-16e5f265007e"), "Nicarágua"),
                new Country(Guid.Parse("853efbe3-75cb-41b7-96e7-b466a3bd9ba2"), "Djibouti"),
                new Country(Guid.Parse("85ec7243-657e-40a1-9ea5-a342da6a4083"), "Chade"),
                new Country(Guid.Parse("86f31fb5-9863-4849-beae-83dacc7c478c"), "Belize"),
                new Country(Guid.Parse("88913b51-73a3-4114-a1b5-594c106b6a1c"), "Ilhas Marshall"),
                new Country(Guid.Parse("89069f8b-147a-4ab8-ad56-b4e58a4dc88b"), "Turquemenistão"),
                new Country(Guid.Parse("8d53cbcf-af1d-4cdf-ab4e-ef2ef2d873a4"), "Angola"),
                new Country(Guid.Parse("8f339194-7212-44d6-935e-70c239cdf6de"), "Venezuela"),
                new Country(Guid.Parse("902d4625-119b-491c-a289-2ccb9b860383"), "Arménia"),
                new Country(Guid.Parse("9080fd90-c32d-4207-b3f0-ec37ae5f10e9"), "Catar"),
                new Country(Guid.Parse("911bfb62-c7b0-463f-bf1d-acb1d6f54efa"), "Eslovénia"),
                new Country(Guid.Parse("92b07193-e02a-4f31-8f5f-5804c521402d"), "Moçambique"),
                new Country(Guid.Parse("93810913-c821-4250-8946-6149203c786e"), "Alemanha"),
                new Country(Guid.Parse("9654f610-391c-45f9-bcfe-2a5018bf159b"), "Guiana"),
                new Country(Guid.Parse("9672c08a-66b1-4c00-ad35-d9fdf958ba7f"), "Oman"),
                new Country(Guid.Parse("98cbe07c-effd-4b45-853f-663ba2ca9ac4"), "Senegal"),
                new Country(Guid.Parse("99b07b59-2568-4856-9bf4-1aed5e4aaaa3"), "Reino Unido"),
                new Country(Guid.Parse("99c265f2-dc54-4f7b-bdf8-9bc9fd6d45a7"), "Azerbaijão"),
                new Country(Guid.Parse("9da337b0-c7ef-461a-adec-f672fd63261a"), "Barbados"),
                new Country(Guid.Parse("9e714b0c-b8e8-4c92-9c05-d60c87e63202"), "Noruega"),
                new Country(Guid.Parse("9f132130-9d2e-4422-aa4c-2977fc79cd3f"), "Namíbia"),
                new Country(Guid.Parse("9ff26cde-3920-4c4c-8b52-16eaf64ff41f"), "Mongólia"),
                new Country(Guid.Parse("a0610786-55f3-49ef-8b42-90c840cfc0f1"), "Ilhas Cook"),
                new Country(Guid.Parse("a109ce39-d9d8-48fd-ab09-6cfabe84402e"), "Zâmbia"),
                new Country(Guid.Parse("a192071f-7dc8-459d-adc5-a8ecd6abe87a"), "Cabo Verde"),
                new Country(Guid.Parse("a313d8ee-2b67-4fd0-bd42-6bfabadd062d"), "Albânia"),
                new Country(Guid.Parse("a439886c-ac36-480b-afd4-7b4146320a8b"), "Cazaquistão"),
                new Country(Guid.Parse("a45db52c-f4b9-4854-b345-ac91dd7e8978"), "Canadá"),
                new Country(Guid.Parse("a5d3c095-e950-49df-a91a-cd52c6af77ef"), "África do Sul"),
                new Country(Guid.Parse("a7436dcd-63c3-42fb-accf-3f1b4bf5f788"), "Suriname"),
                new Country(Guid.Parse("a8cc6803-cdf6-4172-b8ac-00dad15c08a5"), "Burundi"),
                new Country(Guid.Parse("ab0a1443-3fd5-4ad7-a67f-550caa494d87"), "Palau"),
                new Country(Guid.Parse("ae42b335-56a1-4243-a1e3-413de97e2e65"), "Filipinas"),
                new Country(Guid.Parse("ae8a66e0-79e0-4f7c-b53a-b27ee47c3f41"), "Maldivas"),
                new Country(Guid.Parse("aeed0177-8054-4e01-b031-dba6d1ceb061"), "San Marino"),
                new Country(Guid.Parse("af0d09ae-3e6a-49e7-89c9-63c3dc95d794"), "Chipre"),
                new Country(Guid.Parse("b3a1b75b-ae10-4ef1-b722-dcfedac8e1f8"), "Países Baixos"),
                new Country(Guid.Parse("b4786c96-85a8-4d31-ba03-8b4ea4a327ce"), "Líbano"),
                new Country(Guid.Parse("ba37c99f-5ce7-40dc-8808-d492d696771e"), "Comores"),
                new Country(Guid.Parse("bb58f66f-8e07-4031-925e-dad25ff607aa"), "Suécia"),
                new Country(Guid.Parse("beef65e9-1d57-4048-b3b1-1b3497b88d72"), "Sudão do Sul"),
                new Country(Guid.Parse("bf073adc-e649-46b9-927c-64e362ac2a61"), "El Salvador"),
                new Country(Guid.Parse("bfa9e3ed-2413-4bd6-b873-54d9bf1aa51d"), "Peru"),
                new Country(Guid.Parse("c0ffd262-5410-43be-ac27-81b6f182d9ce"), "Coreia do Norte"),
                new Country(Guid.Parse("c1a05781-5fa1-4c48-a3bd-8948e2b3fee2"), "Timor-Leste"),
                new Country(Guid.Parse("c27ca064-04ce-4f33-9387-95546168b3cc"), "Guiné Equatorial"),
                new Country(Guid.Parse("c6662ba8-1278-467e-bc28-779c9b68a9dd"), "Fiji"),
                new Country(Guid.Parse("c791ca16-c456-4aee-bc90-bcb229cb664e"), "Irã"),
                new Country(Guid.Parse("c97fa5d6-9ab2-4eaa-8ada-6ae182e7279f"), "Uzbequistão"),
                new Country(Guid.Parse("cb42b93b-9c64-4c8e-823c-a018a6a7507c"), "Nova Zelândia"),
                new Country(Guid.Parse("cbd6b824-5339-4c90-9845-7a69c6def54c"), "Bahrein"),
                new Country(Guid.Parse("cc426405-6c23-4170-8679-07fad2b3712a"), "São Tomé e Príncipe"),
                new Country(Guid.Parse("ccbc3b65-c324-4a0b-8749-2f04b23b8a57"), "Sérvia"),
                new Country(Guid.Parse("d11cd9e0-48a3-4e3b-a725-ddf221c53012"), "Espanha"),
                new Country(Guid.Parse("d1d23014-eb3c-4e5d-b6fc-81910dd61d92"), "Índia"),
                new Country(Guid.Parse("d29b1936-84ba-4525-8a26-438153a954f3"), "Emirados Árabes Unidos"),
                new Country(Guid.Parse("d3547eeb-e657-471f-b406-696f4a170ffc"), "Seicheles"),
                new Country(Guid.Parse("d83a9f01-65ed-4245-9f10-c2340303719f"), "Benim"),
                new Country(Guid.Parse("d8eb5be3-31f8-40af-89e7-587e0a1a4b7a"), "Malásia"),
                new Country(Guid.Parse("d8fde566-a8d3-4021-a54d-37c091f4b9f2"), "Uruguai"),
                new Country(Guid.Parse("d9b8afb9-bf71-404a-90af-68fd183ea6c8"), "Vaticano"),
                new Country(Guid.Parse("d9c7aa53-c4b9-457e-b8fa-35096b512958"), "Argentina"),
                new Country(Guid.Parse("da0f9045-4a83-41c2-932e-2a1f42b8c74b"), "Costa Rica"),
                new Country(Guid.Parse("db74db6a-9c68-4ba1-aace-7e707f4a3435"), "Nepal"),
                new Country(Guid.Parse("dbb55a9c-8b4e-4d4a-817a-2704b198606e"), "Croácia"),
                new Country(Guid.Parse("dc3eab46-cb02-4938-a7c8-3e9442fe864c"), "Dinamarca"),
                new Country(Guid.Parse("de0195cb-2f61-4a7e-912e-da5e2337a789"), "Quirguistão"),
                new Country(Guid.Parse("de4995e4-fcc8-4274-954b-be47b0fc337b"), "Myanmar"),
                new Country(Guid.Parse("df31ba5c-7ea2-476f-8616-ed9c218eaefe"), "Sudão"),
                new Country(Guid.Parse("df6ebe2d-7f68-4437-930d-d67a22277ec9"), "Haiti"),
                new Country(Guid.Parse("dfbf5ed1-f594-478a-b348-ee8761318ed4"), "Gana"),
                new Country(Guid.Parse("e4270be8-4f5f-4037-85ca-79599c178279"), "Israel"),
                new Country(Guid.Parse("e5e3059b-a0f2-4893-840b-bb308c99fc29"), "Roménia"),
                new Country(Guid.Parse("e79c80e3-d3a4-49c4-ae97-3a2282a06c99"), "Equador"),
                new Country(Guid.Parse("e816859a-4759-4ac7-bf49-fcd87c1709e1"), "Portugal"),
                new Country(Guid.Parse("e8930d06-bc98-434d-a67c-a1d297acd08d"), "São Vicente e Granadinas"),
                new Country(Guid.Parse("edd65bcf-f19a-45dd-93b5-1d67980de152"), "Malawi"),
                new Country(Guid.Parse("ee9a08ef-25c8-4f3a-b4b8-bbdea8fd1865"), "França"),
                new Country(Guid.Parse("f00bdbba-998c-4d7d-a413-779727c30d2e"), "Palestina"),
                new Country(Guid.Parse("f09c4904-cefb-454c-94a6-f4fe586284f2"), "Tonga"),
                new Country(Guid.Parse("f13d445b-5818-40a2-815d-32b6fa32bbfd"), "Lituânia"),
                new Country(Guid.Parse("f3059846-17a9-4529-ba55-d7c0eb4685eb"), "Bielorrússia"),
                new Country(Guid.Parse("f443f7e8-c28d-44cd-b300-90fff99e85f0"), "Grécia"),
                new Country(Guid.Parse("f4846f4a-edb0-4a90-9fb2-e440d48aa558"), "Brasil"),
                new Country(Guid.Parse("f5bce299-1208-4c26-926e-54493a9413bb"), "Mónaco"),
                new Country(Guid.Parse("f685545b-7087-4491-b699-736b9dd7c2cd"), "Cuba"),
                new Country(Guid.Parse("f920bff0-6e56-43fb-8566-be40e957c108"), "Libéria"),
                new Country(Guid.Parse("fa893500-1221-4c38-a933-7bbec8edba7a"), "Letónia"),
                new Country(Guid.Parse("fad9f424-d2c8-4298-bf30-ec9ce4aceb27"), "Indonésia"),
                new Country(Guid.Parse("fb39f682-213b-4553-932a-f489c541ef9c"), "Estónia"),
                new Country(Guid.Parse("fbe6790b-d0ec-4390-9851-80f7a9f7ec84"), "Guiné"),
                new Country(Guid.Parse("fdaeec10-a43f-4965-985a-d8591c5a4800"), "Iraque"),
                new Country(Guid.Parse("ff44b793-f0e2-4c32-bb2a-30a89a849cad"), "Tanzânia"),
                new Country(Guid.Parse("ffb7b733-2fc2-43e8-8efc-7d67317497ed"), "Madagascar")
                );

            builder.ToTable("Country", "manager");
        }
    }
}
