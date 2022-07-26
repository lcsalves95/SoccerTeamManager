# API REST Soccer Manager

## Esta api foi desenvolvida para atender à disciplina de API's e Web Services, do curso de Pós Gradução de Anquitetura de Soluções. O objetivo da tarefa foi desenvolver uma API com nível 2 de maturidade REST, além de incluir a funcionalidade de mensageria.

### Para executar este projeto:</h2>

1 - Executar o arquivo docker-compose.yml presente neste diretório.

```
 docker-compose up -d --build
```

2 - Verificar se as strings de conexão estão corretas nos arquivo 'appsettings.json'.

3 - Abrir o projeto em seu `Visual Studio`, abrir o `Console de gerenciador de pacotes`, apontá-lo para a camada `SoccerTeamManager.Infra.Data` e executar o seguinte comando:

```
Update-Database
```

4 - Selecionar o projeto `SoccerTeamManager.Api` como projeto principal e estará pronto pra ser executada!

###### Obs: Por conta de alguns problemas enfrentados com o passo de migração do entity framework, não foi possível configurar todo o projeto no docker-compose, porém continuaremos tentando.
